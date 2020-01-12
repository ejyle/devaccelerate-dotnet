// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;
using Ejyle.DevAccelerate.List.Culture;
using Ejyle.DevAccelerate.Profiles.Addresses;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Financials.Payment.Stripe
{
    public class DaStripePaymentMethod<TKey, TNullableKey, TPaymentMethod, TPaymentMethodAttribute, TTransaction, TTenant, TTenantUser, TTenantAttribute, TSubscription, TAddressProfile, TUserAddress, TCountry, TCountryRegion>
        where TKey : IEquatable<TKey>
        where TPaymentMethod : DaPaymentMethod<TKey, TNullableKey, TPaymentMethodAttribute, TTransaction>, new()
        where TPaymentMethodAttribute : IDaPaymentMethodAttribute<TKey>
        where TTransaction : IDaTransaction<TKey, TNullableKey>
        where TTenant : DaTenant<TKey, TNullableKey, TTenantUser, TTenantAttribute>
        where TTenantUser : DaTenantUser<TKey, TNullableKey, TTenant>
        where TTenantAttribute : DaTenantAttribute<TKey, TNullableKey, TTenant>, new()
        where TSubscription : IDaSubscription<TKey, TNullableKey>
        where TAddressProfile : DaAddressProfile<TKey, TNullableKey, TUserAddress>
        where TUserAddress : DaUserAddress<TKey, TNullableKey, TAddressProfile>
        where TCountry : IDaCountry<TKey, TNullableKey>
        where TCountryRegion : IDaCountryRegion<TKey, TNullableKey>
    {
        private DaPaymentMethodManager<TKey, TPaymentMethod> _paymentMethodManager;
        private DaSubscriptionManager<TKey, TNullableKey, TSubscription> _subscriptionManager;
        private DaTenantManager<TKey, TNullableKey, TTenant> _tenantManager;
        private DaAddressProfileManager<TKey, TNullableKey, TAddressProfile> _addressProfileManager;
        private DaCountryManager<TKey, TNullableKey, TCountry, TCountryRegion> _countryManager;
        
        public DaStripePaymentMethod(
            DaPaymentMethodManager<TKey, TPaymentMethod> paymentMethodManager,
            DaTenantManager<TKey, TNullableKey, TTenant> tenantManager,
            DaAddressProfileManager<TKey, TNullableKey, TAddressProfile> addressProfileManager,
            DaSubscriptionManager<TKey, TNullableKey, TSubscription> subscriptionManager,
            DaCountryManager<TKey, TNullableKey, TCountry, TCountryRegion> countryManager)
        {
            if (paymentMethodManager == null)
            {
                throw new ArgumentNullException(nameof(paymentMethodManager));
            }

            if (addressProfileManager == null)
            {
                throw new ArgumentNullException(nameof(addressProfileManager));
            }

            if(tenantManager == null)
            {
                throw new ArgumentNullException(nameof(tenantManager));
            }

            if (subscriptionManager == null)
            {
                throw new ArgumentNullException(nameof(subscriptionManager));
            }

            if (countryManager == null)
            {
                throw new ArgumentNullException(nameof(countryManager));
            }

            _paymentMethodManager = paymentMethodManager;
            _tenantManager = tenantManager;
            _addressProfileManager = addressProfileManager;
            _subscriptionManager = subscriptionManager;
            _countryManager = countryManager;

            StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["Stripe:TestSecretKey"];
        }

        public async Task<string> CreateClientSecretAsync()
        {
            var options = new SetupIntentCreateOptions { 
                PaymentMethodTypes = new List<string> { "card" }                 
            };

            var service = new SetupIntentService();
            SetupIntent intent = await service.CreateAsync(options);
            return intent.ClientSecret;
        }

        public async Task SavePaymentMethodsAsync(string nativePaymentMethodId, TKey userId)
        {
            var service = new PaymentMethodService();
            var stripePaymentMethod = await service.GetAsync(nativePaymentMethodId);

            var paymentMethod = await _paymentMethodManager.FindByNativeIdAsync(nativePaymentMethodId);

            if (paymentMethod == null)
            {
                paymentMethod = new TPaymentMethod();

                paymentMethod.NativePaymentMethodId = stripePaymentMethod.Id;

                if (stripePaymentMethod.Card != null)
                {
                    if (stripePaymentMethod.Card.Wallet != null)
                    {
                        paymentMethod.PaymentGateway = stripePaymentMethod.Card.Wallet.ToString();
                    }

                    paymentMethod.Name = stripePaymentMethod.Card.Last4;
                }
                else
                {
                    paymentMethod.Name = stripePaymentMethod.Type;
                }

                paymentMethod.PaymentMethodType = PaymentMethodType.Card;
                paymentMethod.OwnerUserId = userId;
                paymentMethod.IsActive = true;
                paymentMethod.CreatedDateUtc = DateTime.UtcNow;
                paymentMethod.LastUpdatedDateUtc = DateTime.UtcNow;

                await _paymentMethodManager.CreateAsync(paymentMethod);
            }
        }

        public async Task CreateCustomerAsync(string nativePaymentMethodId, TKey subscriptionId)
        {
            var subscription = await _subscriptionManager.FindByIdAsync(subscriptionId);
            var tenant = await _tenantManager.FindByIdAsync(subscription.TenantId);
            var addresses = await _addressProfileManager.FindByTenantIdAsync(tenant.Id);

            TAddressProfile address = null;

            foreach(var addr in addresses)
            {
                var userAddress = addr.UserAddresses.FirstOrDefault();

                if(userAddress.AddressType == DaAddressType.Billing)
                {
                    address = addr;
                    break;
                }
            }

            if(address == null)
            {
                address = addresses.FirstOrDefault();
            }

            if(address == null)
            {
                throw new InvalidOperationException("No address found.");
            }

            var country = await _countryManager.FindByIdAsync(tenant.CountryId);

            var addressOption = new AddressOptions()
            {
                Line1 = address.Address1,
                Line2 = address.Address2,
                Country = country.Name,
                PostalCode = address.ZipCode,
                State = address.State,
                City = address.City
            };

            var options = new CustomerCreateOptions
            {                 
                PaymentMethod = nativePaymentMethodId,
                Email = tenant.BillingEmail,
                Name = tenant.Name,
                Address = addressOption
            };

            var service = new CustomerService();
            var customer = await service.CreateAsync(options);

            var tenantAttribute = tenant.Attributes.Where(m => m.AttributeName == "StripeCustomerId").SingleOrDefault();

            bool newAttribute = false;

            if (tenantAttribute == null)
            {
                tenantAttribute = new TTenantAttribute()
                {
                    Tenant = tenant,
                    AttributeName = "StripeCustomerId",
                    CreatedDateUtc = DateTime.UtcNow
                };

                newAttribute = true;
            }

            tenantAttribute.AttributeValue = customer.Id;
            tenantAttribute.LastUpdatedDateUtc = DateTime.UtcNow;

            if(newAttribute)
            {
                if(tenant.Attributes == null)
                {
                    tenant.Attributes = new List<TTenantAttribute>();
                }

                tenant.Attributes.Add(tenantAttribute);
            }

            await _tenantManager.UpdateAsync(tenant);
        }

        private Task<StripeList<PaymentMethod>> GetStripePaymentMethodsAsync(string customerId)
        {
            var options = new PaymentMethodListOptions
            {
                Customer = customerId,
                Type = "card",
            };

            var service = new PaymentMethodService();
            return service.ListAsync(options);
        }
    }
}
