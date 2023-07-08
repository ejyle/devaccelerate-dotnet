// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Identity;
using Ejyle.DevAccelerate.Identity.EF;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Microsoft.AspNetCore.Identity;
using Ejyle.DevAccelerate.Core.Utils;
using System.Text.RegularExpressions;
using Ejyle.DevAccelerate.Lists.Countries;
using Ejyle.DevAccelerate.Lists.Currencies;
using Ejyle.DevAccelerate.Lists.DateFormats;
using Ejyle.DevAccelerate.Lists.SystemLanguages;
using Ejyle.DevAccelerate.Lists.TimeZones;
using Ejyle.DevAccelerate.Lists.EF.Countries;
using Ejyle.DevAccelerate.Lists.EF.Currencies;
using Ejyle.DevAccelerate.Lists.EF.DateFormats;
using Ejyle.DevAccelerate.Lists.EF.SystemLanguages;
using Ejyle.DevAccelerate.Lists.EF.TimeZones;
using Ejyle.DevAccelerate.Identity.Groups;
using Ejyle.DevAccelerate.Platform.Apps;
using Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans;
using Ejyle.DevAccelerate.Platform.Features;
using Ejyle.DevAccelerate.Subscriptions.Subscriptions;
using Ejyle.DevAccelerate.MultiTenancy.Tenants;
using Ejyle.DevAccelerate.Identity.UserAgreements;
using Ejyle.DevAccelerate.Identity.EF.Groups;
using Ejyle.DevAccelerate.Platform.EF.Apps;
using Ejyle.DevAccelerate.Subscriptions.EF.SubscriptionPlans;
using Ejyle.DevAccelerate.Platform.EF.Features;
using Ejyle.DevAccelerate.Subscriptions.EF.Subscriptions;
using Ejyle.DevAccelerate.MultiTenancy.EF.Tenants;
using Ejyle.DevAccelerate.Identity.EF.UserAgreements;
using Ejyle.DevAccelerate.Identity.UserProfiles;
using Ejyle.DevAccelerate.Identity.EF.UserProfiles;
using Ejyle.DevAccelerate.MultiTenancy.Organizations;
using Ejyle.DevAccelerate.MultiTenancy.EF.Organizations;
using Ejyle.DevAccelerate.MultiTenancy.Addresses;
using Ejyle.DevAccelerate.MultiTenancy.EF.Addresses;

namespace Ejyle.DevAccelerate.Facades.Security.Registration
{
    public class DaRegistrationFacade : DaRegistrationFacade<string, DaRegistrationInfo, DaAddressRegistrationInfo, DaOrganizationRegistrationInfo, DaTenantRegistrationInfo, DaSubscriptionRegistrationInfo, UserManager<DaUser>, DaUser, DaUserProfileManager, DaUserProfile, DaUserProfileAttribute, DaOrganizationManager, DaOrganization, DaOrganizationAttribute, DaOrganizationGroup, DaTenantManager, DaTenant, DaTenantUser, DaTenantAttribute, DaMTPTenant, DaAddressProfileManager, DaAddressProfile, DaUserAddress, DaUserAgreementManager, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DaAppManager, DaApp, DaAppAttribute, DaFeatureManager, DaFeature, DaAppFeature, DaFeatureAction, DaSubscriptionPlanManager, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscriptionManager, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage, DaCurrencyManager, DaCurrency, DaCountryManager, DaCountry, DaCountryRegion, DaCountryDateFormat, DaCountrySystemLanguage, DaCountryTimeZone, DaDateFormatManager, DaDateFormat, DaTimeZoneManager, DaTimeZone, DaSystemLanguageManager, DaSystemLanguage>
    {        
        public DaRegistrationFacade(UserManager<DaUser> userManager, DaUserProfileManager userProfileManager, DaOrganizationManager organizationProfileManager,  DaTenantManager tenantManager, DaAddressProfileManager addressProfileManager,  DaAppManager appManager, DaFeatureManager featureManager, DaUserAgreementManager userAgreementManager, DaSubscriptionPlanManager subscriptionPlanManager, DaSubscriptionManager subscriptionManager, DaCurrencyManager currencyManager, DaCountryManager countryManager, DaDateFormatManager dateformatManager, DaTimeZoneManager timeZoneManager, DaSystemLanguageManager systemLanguageManager)
            : base(userManager, userProfileManager, organizationProfileManager, tenantManager, addressProfileManager, appManager, featureManager, userAgreementManager, subscriptionPlanManager, subscriptionManager, currencyManager, countryManager, dateformatManager, timeZoneManager, systemLanguageManager)
        {
        }
    }

    public class DaRegistrationFacade<TKey, TRegistrationInfo, TAddressProfileRegistrationInfo,TOrganizationRegistrationInfo,TTenantRegistrationInfo,TSubscriptionRegistrationInfo, TUserManager, TUser, TUserProfileManager, TUserProfile, TUserProfileAttribute, TOrganizationProfileManager, TOrganizationProfile, TOrganizationProfileAttribute, TOrganizationGroup, TTenantManager, TTenant, TTenantUser, TTenantAttribute, TMTPTenant, TAddressProfileManager, TAddressProfile, TUserAddress, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TAppAttribute, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionManager, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TCountryDateFormat, TCountrySystemLanguage, TCountryTimeZone, TDateFormatManager, TDateFormat, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage>
        where TKey : IEquatable<TKey>
        where TRegistrationInfo : DaRegistrationInfo<TKey, TAddressProfileRegistrationInfo, TOrganizationRegistrationInfo, TTenantRegistrationInfo, TSubscriptionRegistrationInfo>
        where TAddressProfileRegistrationInfo : IDaAddressRegistrationInfo<TKey>
        where TTenantRegistrationInfo : IDaTenantRegistrationInfo
        where TOrganizationRegistrationInfo : IDaOrganizationRegistrationInfo
        where TSubscriptionRegistrationInfo : IDaSubscriptionRegistrationInfo<TKey>
        where TUserManager : UserManager<TUser>
        where TUser : DaUser<TKey>, new()
        where TUserProfile : DaUserProfile<TKey, TUserProfileAttribute>, new()
        where TUserProfileAttribute : DaUserProfileAttribute<TKey, TUserProfile>, new()
        where TUserProfileManager : DaUserProfileManager<TKey, TUserProfile>
        where TOrganizationProfile : DaOrganization<TKey, TOrganizationProfile, TOrganizationProfileAttribute, TOrganizationGroup>, new()
        where TOrganizationProfileAttribute : DaOrganizationAttribute<TKey, TOrganizationProfile>, new()
        where TOrganizationGroup : DaOrganizationGroup<TKey, TOrganizationGroup, TOrganizationProfile>
        where TOrganizationProfileManager : DaOrganizationManager<TKey, TOrganizationProfile, TOrganizationGroup>
        where TAddressProfileManager : DaAddressProfileManager<TKey, TAddressProfile>
        where TAddressProfile : DaAddressProfile<TKey, TUserAddress>, new()
        where TUserAddress : DaUserAddress<TKey, TAddressProfile>, new()
        where TAppManager : DaAppManager<TKey, TApp>
        where TApp : DaApp<TKey, TAppAttribute, TFeature, TAppFeature>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TBillingCycleOption : DaBillingCycleOption<TKey, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<TKey, TFeature>
        where TFeatureManager : DaFeatureManager<TKey, TFeature>
        where TFeature : DaFeature<TKey, TApp, TAppFeature, TFeatureAction>
        where TSubscriptionManager : DaSubscriptionManager<TKey, TSubscription>
        where TSubscriptionAppRole : DaSubscriptionAppRole<TKey, TSubscriptionApp>
        where TSubscriptionApp : DaSubscriptionApp<TKey, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser>, new()
        where TSubscriptionAppUser : DaSubscriptionAppUser<TKey, TSubscriptionApp>
        where TSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<TKey, TSubscriptionFeature>, new()
        where TSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<TKey, TSubscriptionFeatureRole>
        where TSubscriptionFeatureRole : DaSubscriptionFeatureRole<TKey, TSubscriptionFeatureRoleAction, TSubscriptionFeature>
        where TSubscriptionFeature : DaSubscriptionFeature<TKey, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser, TBillingCycleFeatureUsage>, new()
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<TKey, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanManager : DaSubscriptionPlanManager<TKey, TSubscriptionPlan>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<TKey, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<TKey, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<TKey, TSubscriptionPlan>
        where TSubscription : DaSubscription<TKey, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle>, new()
        where TBillingCycle : DaBillingCycle<TKey, TBillingCycleAttribute, TSubscription, TBillingCycleFeatureUsage>, new()
        where TBillingCycleAttribute : DaBillingCycleAttribute<TKey, TBillingCycle>, new()
        where TBillingCycleFeatureUsage : DaBillingCycleFeatureUsage<TKey, TBillingCycle, TSubscriptionFeature>, new()
        where TSubscriptionAttribute : DaSubscriptionAttribute<TKey, TSubscription>, new()
        where TTenantManager : DaTenantManager<TKey, TTenant, TTenantUser, TMTPTenant>
        where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute, TMTPTenant>, new()
        where TMTPTenant : DaMTPTenant<TKey, TTenant>
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>, new()
        where TTenantUser : DaTenantUser<TKey, TTenant>, new()
        where TUserAgreementManager : DaUserAgreementManager<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>
        where TUserAgreement : DaUserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : DaUserAgreementVersion<TKey, TUserAgreement, TUserAgreementVersionAction>
        where TUserAgreementVersionAction : DaUserAgreementVersionAction<TKey, TUserAgreementVersion>
        where TCurrencyManager : DaCurrencyManager<TKey, TCurrency>
        where TCurrency : DaCurrency<TKey, TCountry>
        where TCountryManager : DaCountryManager<TKey, TCountry, TCountryRegion>
        where TCountry : DaCountry<TKey, TCurrency, TCountryTimeZone, TCountryRegion, TCountrySystemLanguage, TCountryDateFormat>
        where TCountryRegion : DaCountryRegion<TKey, TCountryRegion, TCountry>
        where TCountryDateFormat : DaCountryDateFormat<TKey, TCountry, TDateFormat>
        where TCountrySystemLanguage : DaCountrySystemLanguage<TKey, TCountry, TSystemLanguage>
        where TCountryTimeZone : DaCountryTimeZone<TKey, TCountry, TTimeZone>
        where TDateFormatManager : DaDateFormatManager<TKey, TDateFormat>
        where TDateFormat : DaDateFormat<TKey, TCountryDateFormat>
        where TTimeZoneManager : DaTimeZoneManager<TKey, TTimeZone>
        where TTimeZone : DaTimeZone<TKey, TCountryTimeZone>
        where TSystemLanguageManager : DaSystemLanguageManager<TKey, TSystemLanguage>
        where TSystemLanguage : DaSystemLanguage<TKey, TCountrySystemLanguage>
    {
        public DaRegistrationFacade(TUserManager userManager, TUserProfileManager userProfileManager, TOrganizationProfileManager organizationProfileManager, TTenantManager tenantManager, TAddressProfileManager addressProfileManager, TAppManager appManager, TFeatureManager featureManager, TUserAgreementManager userAgreementManager, TSubscriptionPlanManager subscriptionPlanManager, TSubscriptionManager subscriptionManager, TCurrencyManager currencyManager, TCountryManager countryManager, TDateFormatManager dateformatManager, TTimeZoneManager timeZoneManager, TSystemLanguageManager systemLanguageManager)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            UserProfileManager = userProfileManager ?? throw new ArgumentNullException(nameof(userProfileManager));
            OrganizationProfileManager = organizationProfileManager ?? throw new ArgumentNullException(nameof(organizationProfileManager));
            AddressProfileManager = addressProfileManager ?? throw new ArgumentNullException(nameof(addressProfileManager));
            TenantManager = tenantManager ?? throw new ArgumentNullException(nameof(tenantManager));
            AppManager = appManager ?? throw new ArgumentNullException(nameof(appManager));
            FeatureManager = featureManager ?? throw new ArgumentNullException(nameof(featureManager));
            UserAgreementManager = userAgreementManager ?? throw new ArgumentNullException(nameof(userAgreementManager));
            SubscriptionManager = subscriptionManager ?? throw new ArgumentNullException(nameof(subscriptionManager));
            SubscriptionPlanManager = subscriptionPlanManager ?? throw new ArgumentNullException(nameof(subscriptionPlanManager));
            CurrencyManager = currencyManager ?? throw new ArgumentNullException(nameof(currencyManager));
            DateFormatManager = dateformatManager ?? throw new ArgumentNullException(nameof(dateformatManager));
            CountryManager = countryManager ?? throw new ArgumentNullException(nameof(countryManager));
            TimeZoneManager = timeZoneManager ?? throw new ArgumentNullException(nameof(timeZoneManager));
            SystemLanguageManager = systemLanguageManager ?? throw new ArgumentNullException(nameof(systemLanguageManager));
        }

        public TSubscriptionManager SubscriptionManager
        {
            get;
            private set;
        }

        public TUserManager UserManager
        {
            get;
            private set;
        }

        public TTenantManager TenantManager
        {
            get;
            private set;
        }

        public TUserProfileManager UserProfileManager
        {
            get;
            private set;
        }

        public TOrganizationProfileManager OrganizationProfileManager
        {
            get;
            private set;
        }

        public TAddressProfileManager AddressProfileManager
        {
            get;
            private set;
        }

        public TAppManager AppManager
        {
            get;
            private set;
        }

        public TFeatureManager FeatureManager
        {
            get;
            private set;
        }

        public TUserAgreementManager UserAgreementManager
        {
            get;
            private set;
        }

        public TSubscriptionPlanManager SubscriptionPlanManager
        {
            get;
            private set;
        }

        public TCurrencyManager CurrencyManager
        {
            get;
            private set;
        }

        public TCountryManager CountryManager
        {
            get;
            private set;
        }

        public TTimeZoneManager TimeZoneManager
        {
            get;
            private set;
        }

        public TDateFormatManager DateFormatManager
        {
            get;
            private set;
        }

        public TSystemLanguageManager SystemLanguageManager
        {
            get;
            private set;
        }

        public DaRegistrationResult<TKey> Register(TRegistrationInfo registrationInfo, string password)
        {
            return DaAsyncHelper.RunSync<DaRegistrationResult<TKey>>(() => RegisterAsync(registrationInfo, password));
        }

        public virtual async Task<DaRegistrationResult<TKey>> RegisterAsync(TRegistrationInfo registrationInfo, string password)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (registrationInfo.Tenant == null)
            {
                if (registrationInfo.Organization != null)
                {
                    throw new InvalidOperationException("Tenant object cannot be null when organization object is provided.");
                }

                if (registrationInfo.Subscription != null)
                {
                    throw new InvalidOperationException("Tenant object cannot be null when subscription object is provided.");
                }
            }
            else
            {
                if (registrationInfo.Tenant.TenantType == DaTenantType.Organization)
                {
                    if (registrationInfo.Organization == null)
                    {
                        throw new InvalidOperationException("Organization object cannot be null when tenant type is organization.");
                    }
                }
            }

            if(registrationInfo.Subscription != null)
            {
                if(registrationInfo.Address == null)
                {
                    throw new InvalidOperationException("Address object cannot be null when subscription object is provided.");
                }
            }

            if (string.IsNullOrEmpty(registrationInfo.UserName))
            {
                return new DaRegistrationResult<TKey>(
                    new DaRegistrationError(DaRegistrationError.INVALID_USER_NAME, "Username is invalid."));
            }

            if (string.IsNullOrEmpty(registrationInfo.Email))
            {
                return new DaRegistrationResult<TKey>(
                    new DaRegistrationError(DaRegistrationError.INVALID_EMAIL, "Email is invalid."));
            }

            var user = await UserManager.FindByNameAsync(registrationInfo.UserName);

            if (user != null)
            {
                return new DaRegistrationResult<TKey>(
                    new DaRegistrationError(DaRegistrationError.DUPLICATE_USER_NAME, "Another account with the same username already exists."));
            }

            user = await UserManager.FindByEmailAsync(registrationInfo.Email);

            if (user != null)
            {
                return new DaRegistrationResult<TKey>(
                    new DaRegistrationError(DaRegistrationError.DUPLICATE_EMAIL, "Another account with the same email address already exists."));
            }

            TCountry country = default(TCountry);

            if (registrationInfo.Address != null)
            {
                country = await CountryManager.FindByIdAsync(registrationInfo.Address.CountryId);

                if (country == null)
                {
                    return new DaRegistrationResult<TKey>(
                        new DaRegistrationError(DaRegistrationError.INVALID_COUNTRY, "Country ID / name is invalid"));
                }
            }

            TSubscriptionPlan subscriptionPlan = null;

            if (registrationInfo.Subscription != null)
            {
                subscriptionPlan = await SubscriptionPlanManager.FindByIdAsync(registrationInfo.Subscription.SubscriptionPlanId);

                if (subscriptionPlan == null)
                {
                    throw new InvalidOperationException("Invalid subscription plan.");
                }
            }

            user = new TUser
            {
                UserName = registrationInfo.UserName,
                Email = registrationInfo.Email,
                EmailConfirmed = false,
                PhoneNumber = registrationInfo.UserPhoneNumber,
                PhoneNumberConfirmed = false,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedDateUtc = DateTime.UtcNow
            };

            var result = await UserManager.CreateAsync(user, password);

            List<DaRegistrationError> errors = null;

            if (result.Errors != null)
            {
                errors = new List<DaRegistrationError>();
                foreach (var error in errors)
                {
                    errors.Add(new DaRegistrationError(error.Code, error.Description));
                }
            }

            if (!result.Succeeded)
            {
                return new DaRegistrationResult<TKey>(errors);
            }

            if (registrationInfo.Roles != null)
            {
                await UserManager.AddToRolesAsync(user, registrationInfo.Roles);
            }

            var userProfile = new TUserProfile()
            {
                Salutation = registrationInfo.Salutation,
                FirstName = registrationInfo.FirstName,
                MiddleName = registrationInfo.MiddleName,
                LastName = registrationInfo.LastName,
                Dob = registrationInfo.Dob,
                Gender = registrationInfo.Gender,
                JobTitle = registrationInfo.JobTitle,
                OwnerUserId = user.Id,
                CreatedBy = user.Id.ToString(),
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedBy = user.Id.ToString(),
                LastUpdatedDateUtc = DateTime.UtcNow
            };

            if (registrationInfo.UserProfileAttributes != null && registrationInfo.UserProfileAttributes.Count > 0)
            {
                foreach (var key in registrationInfo.UserProfileAttributes.Keys)
                {
                    var attribute = new TUserProfileAttribute()
                    {
                        AttributeName = key,
                        AttributeValue = registrationInfo.UserProfileAttributes[key],
                        UserProfileId = userProfile.Id,
                        UserProfile = userProfile
                    };

                    userProfile.Attributes.Add(attribute);
                }
            }

            await UserProfileManager.CreateAsync(userProfile);

            TTenant tenant = null;

            if (registrationInfo.Tenant != null)
            {
                tenant = new TTenant()
                {
                    OwnerUserId = user.Id.ToString(),
                    Status = DaTenantStatus.Active,
                    TenantType = DaTenantType.Organization,
                    Domain = null,
                    IsDomainOwnershipVerified = false,
                    Country = country.Id.ToString(),
                    Currency = country.CurrencyId.ToString(),
                    BillingEmail = registrationInfo.Email,
                    CreatedDateUtc = DateTime.UtcNow,
                    CreatedBy = user.Id.ToString(),
                    LastUpdatedBy = user.Id.ToString(),
                    LastUpdatedDateUtc = DateTime.UtcNow
                };

                if (registrationInfo.Tenant.TenantType == DaTenantType.Organization)
                {
                    var name = registrationInfo.Organization.OrganizationName;
                    name = Regex.Replace(name, @"[^\w]", "");

                    name = name.Trim().ToLower() + "-" + DaRandomNumberUtil.GenerateInt().ToString();
                    tenant.Name = name;
                }
                else
                {
                    tenant.Name = registrationInfo.UserName;
                }

                var tenantUser = new TTenantUser
                {
                    Tenant = tenant,
                    IsActive = true,
                    UserId = user.Id.ToString(),
                    TenantId = tenant.Id
                };

                tenant.TenantUsers.Add(tenantUser);

                if (registrationInfo.Tenant.TenantAttributes != null && registrationInfo.Tenant.TenantAttributes.Count > 0)
                {
                    foreach (var attribute in registrationInfo.Tenant.TenantAttributes)
                    {
                        tenant.Attributes.Add(new TTenantAttribute()
                        {
                            TenantId = tenant.Id,
                            Tenant = tenant,
                            AttributeName = attribute.Key,
                            AttributeValue = attribute.Value
                        });
                    }
                }

                await TenantManager.CreateAsync(tenant);

                if (registrationInfo.Tenant.TenantType == DaTenantType.Organization)
                {
                    var organizationProfile = new TOrganizationProfile()
                    {
                        OrganizationName = registrationInfo.Organization.OrganizationName,
                        OrganizationType = registrationInfo.Organization.OrganizationType,
                        TenantId = tenant.Id,
                        CreatedBy = user.Id.ToString(),
                        CreatedDateUtc = DateTime.UtcNow,
                        LastUpdatedBy = user.Id.ToString(),
                        LastUpdatedDateUtc = DateTime.UtcNow
                    };

                    if (registrationInfo.Organization.OrganizationProfileAttributes != null && registrationInfo.Organization.OrganizationProfileAttributes.Count > 0)
                    {
                        foreach (var key in registrationInfo.Organization.OrganizationProfileAttributes.Keys)
                        {
                            var attribute = new TOrganizationProfileAttribute()
                            {
                                AttributeName = key,
                                AttributeValue = registrationInfo.Organization.OrganizationProfileAttributes[key],
                                Organization = organizationProfile,
                                OrganizationId = organizationProfile.Id
                            };

                            organizationProfile.Attributes.Add(attribute);
                        }
                    }

                    await OrganizationProfileManager.CreateAsync(organizationProfile);
                }
            }

            if (registrationInfo.Address != null)
            {
                var addressProfile = new TAddressProfile()
                {
                    Address1 = registrationInfo.Address.Address1,
                    Address2 = registrationInfo.Address.Address2,
                    PhoneNumber = registrationInfo.Address.PhoneNumber,
                    ZipCode = registrationInfo.Address.ZipCode,
                    Extension = registrationInfo.Address.Extension,
                    State = registrationInfo.Address.State,
                    FaxNumber = registrationInfo.Address.FaxNumber,
                    AreaCode = registrationInfo.Address.AreaCode,
                    City = registrationInfo.Address.City,
                    Country = registrationInfo.Address.CountryId.ToString(),
                    OwnerUserId = user.Id.ToString(),
                    CreatedBy = user.Id.ToString(),
                    CreatedDateUtc = DateTime.UtcNow,
                    LastUpdatedBy = user.Id.ToString(),
                    LastUpdatedDateUtc = DateTime.UtcNow
                };

                var billingAddress = new TUserAddress()
                {
                    AddressProfile = addressProfile,
                    Name = "Billing",
                    UserId = user.Id.ToString(),
                    AddressType = DaAddressType.Billing,
                    TenantId = tenant == null ? default(TKey) : tenant.Id,
                    CreatedBy = user.Id.ToString(),
                    CreatedDateUtc = DateTime.UtcNow,
                    LastUpdatedBy = user.Id.ToString(),
                    LastUpdatedDateUtc = DateTime.UtcNow,
                    AddressProfileId = addressProfile.Id
                };

                var shippingAddress = new TUserAddress()
                {
                    AddressProfile = addressProfile,
                    Name = "Shipping",
                    UserId = user.Id.ToString(),
                    AddressType = DaAddressType.Shipping,
                    TenantId = billingAddress.TenantId,
                    CreatedBy = user.Id.ToString(),
                    CreatedDateUtc = DateTime.UtcNow,
                    LastUpdatedBy = user.Id.ToString(),
                    LastUpdatedDateUtc = DateTime.UtcNow,
                    AddressProfileId = addressProfile.Id
                };

                addressProfile.UserAddresses.Add(billingAddress);
                addressProfile.UserAddresses.Add(shippingAddress);

                await AddressProfileManager.CreateAsync(addressProfile);
            }

            if(registrationInfo.Subscription == null)
            {
                if(tenant != null)
                {
                    return new DaRegistrationResult<TKey>(user.Id, userProfile.Id, tenant.Id);
                }

                return new DaRegistrationResult<TKey>(user.Id, userProfile.Id);
            }

            var subscription = new TSubscription
            {
                Name = subscriptionPlan.Name,
                IsCurrentlyInTrial = false,
                OwnerUserId = user.Id.ToString(),
                SubscriptionPlanId = subscriptionPlan.Id,
                ExpiryDateUtc = DateTime.UtcNow.AddDays(30),
                Country = registrationInfo.Address.CountryId.ToString(),
                TenantId = tenant.Id.ToString(),
                IsAutoRenewUntilCanceled = subscriptionPlan.IsAutoRenewUntilCanceled,
                UserAgreementVersionId = null,
                Currency = null,
                CreatedDateUtc = DateTime.UtcNow,
                LastTransactionId = null,
                LastUpdatedDateUtc = DateTime.UtcNow,
                BillingAmount = 0,
                IsFree = subscriptionPlan.IsFree,
                Level = subscriptionPlan.Level,
                BillingInterval = DaBillingInterval.Monthly,
                StartDateUtc = DateTime.UtcNow,
                TrialStartDateUtc = null,
                CreatedBy = user.Id.ToString(),
                LastUpdatedBy = user.Id.ToString()
            };

            DateTime subscriptionDate = DateTime.UtcNow;

            if ((subscriptionPlan.AllowTrial && subscriptionPlan.StartOnlyWithTrial) || (subscriptionPlan.AllowTrial && registrationInfo.Subscription.StartWithTrial))
            {
                subscriptionDate.AddDays((double)subscriptionPlan.TrialDays);
                subscription.StartDateUtc = DateTime.UtcNow.AddDays((double)subscriptionPlan.TrialDays);
                subscription.TrialStartDateUtc = DateTime.UtcNow;
            }

            if (subscriptionPlan.ValidityInMonths == null)
            {
                subscription.ExpiryDateUtc = null;
            }
            else
            {
                subscription.ExpiryDateUtc = subscription.StartDateUtc.AddMonths((int)subscriptionPlan.ValidityInMonths);
            }

            TBillingCycleOption billingCycleOption = null;

            if (registrationInfo.Subscription.BillingCycleOptionId != null)
            {
                billingCycleOption = subscriptionPlan.BillingCycleOptions.Where(m => m.Id.Equals(registrationInfo.Subscription.BillingCycleOptionId)).SingleOrDefault();
            }
            else
            {
                billingCycleOption = subscriptionPlan.BillingCycleOptions.Where(m => m.Id.Equals(subscriptionPlan.DefaultBillingCycleId)).SingleOrDefault();
            }

            if (billingCycleOption != null)
            {
                var billingCycle = new TBillingCycle()
                {
                    Amount = billingCycleOption.Amount,
                    FromDateUtc = subscription.StartDateUtc,
                    Currency = null,
                    IsPaid = false,
                    Subscription = subscription,
                    InvoiceId = null,
                    TransactionId = null,
                    CreatedBy = user.Id.ToString(),
                    CreatedDateUtc = DateTime.UtcNow,
                    LastUpdatedBy = user.Id.ToString(),
                    LastUpdatedDateUtc = DateTime.UtcNow
                };

                subscription.BillingAmount = billingCycleOption.Amount;
                subscription.BillingInterval = billingCycleOption.BillingInterval;

                if (billingCycleOption.BillingInterval == DaBillingInterval.Monthly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddMonths(1);
                }
                else if (billingCycleOption.BillingInterval == DaBillingInterval.Yearly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddYears(1);
                }
                else if (billingCycleOption.BillingInterval == DaBillingInterval.Weekly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddDays(7);
                }
                else if (billingCycleOption.BillingInterval == DaBillingInterval.Quarterly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddMonths(3);
                }

                subscription.BillingCycles.Add(billingCycle);
            }

            if (subscriptionPlan.SubscriptionPlanApps != null && subscriptionPlan.SubscriptionPlanApps.Count > 0)
            {
                subscription.SubscriptionApps = new List<TSubscriptionApp>();

                foreach (var subscriptionPlanApp in subscriptionPlan.SubscriptionPlanApps)
                {
                    var subscriptionApp = new TSubscriptionApp();
                    subscriptionApp.AppId = subscriptionPlanApp.AppId;
                    subscriptionApp.Subscription = subscription;

                    subscription.SubscriptionApps.Add(subscriptionApp);
                }
            }

            if (subscriptionPlan.SubscriptionPlanFeatures != null && subscriptionPlan.SubscriptionPlanFeatures.Count > 0)
            {
                subscription.SubscriptionFeatures = new List<TSubscriptionFeature>();

                foreach (var subscriptionPlanFeature in subscriptionPlan.SubscriptionPlanFeatures)
                {
                    var subscriptionFeature = new TSubscriptionFeature();
                    subscriptionFeature.FeatureId = subscriptionPlanFeature.FeatureId;
                    subscriptionFeature.Subscription = subscription;
                    subscriptionFeature.MaximumQuantity = subscriptionPlanFeature.MaximumQuantity;
                    subscriptionFeature.IsPremium = subscriptionPlanFeature.IsPremium;
                    subscriptionFeature.SubscriptionPlanFeatureType = subscriptionPlanFeature.SubscriptionPlanFeatureType;
                    subscriptionFeature.IsActive = true;

                    if (subscriptionFeature.SubscriptionPlanFeatureType == DaSubscriptionPlanFeatureType.MeteredUsage)
                    {
                        if (subscription.BillingCycles != null && subscription.BillingCycles.Count > 0)
                        {
                            var billingCycle = subscription.BillingCycles.FirstOrDefault();
                            var billingCycleFeatureUsage = new TBillingCycleFeatureUsage()
                            {
                                BillingCycleId = billingCycle.Id,
                                Quantity = 0,
                                SubscriptionFeature = subscriptionFeature,
                            };

                            subscriptionFeature.FeatureUsage.Add(billingCycleFeatureUsage);
                        }
                    }

                    if (subscriptionPlanFeature.SubscriptionPlanFeatureAttributes != null && subscriptionPlanFeature.SubscriptionPlanFeatureAttributes.Count > 0)
                    {
                        subscriptionFeature.SubscriptionFeatureAttributes = new List<TSubscriptionFeatureAttribute>();

                        foreach (var subscriptionPlanFeatureAttribute in subscriptionPlanFeature.SubscriptionPlanFeatureAttributes)
                        {
                            var subscriptionFeatureAttribute = new TSubscriptionFeatureAttribute();

                            subscriptionFeatureAttribute.AttributeName = subscriptionPlanFeatureAttribute.AttributeName;
                            subscriptionFeatureAttribute.AttributeValue = subscriptionPlanFeatureAttribute.AttributeValue;
                            subscriptionFeatureAttribute.SubscriptionFeature = subscriptionFeature;

                            subscriptionFeature.SubscriptionFeatureAttributes.Add(subscriptionFeatureAttribute);
                        }
                    }
                    subscription.SubscriptionFeatures.Add(subscriptionFeature);
                }
            }

            if (subscriptionPlan.Attributes != null && subscriptionPlan.Attributes.Count > 0)
            {
                TBillingCycle billingCycle = null;

                if (subscription.BillingCycles != null)
                {
                    billingCycle = subscription.BillingCycles.SingleOrDefault();
                }

                subscription.Attributes = new List<TSubscriptionAttribute>();

                foreach (var subscriptionPlanAttribute in subscriptionPlan.Attributes)
                {
                    if (subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToSubscription || subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToSubscriptionAndBillingCycle)
                    {
                        var attribute = new TSubscriptionAttribute();
                        attribute.AttributeName = subscriptionPlanAttribute.AttributeName;
                        attribute.AttributeValue = subscriptionPlanAttribute.AttributeValue;
                        attribute.Subscription = subscription;

                        subscription.Attributes.Add(attribute);
                    }
                    if (billingCycle != null)
                    {
                        if (subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToBillingCycle || subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToSubscriptionAndBillingCycle)
                        {
                            var bcAttribute = new TBillingCycleAttribute();
                            bcAttribute.AttributeName = subscriptionPlanAttribute.AttributeName;
                            bcAttribute.AttributeValue = subscriptionPlanAttribute.AttributeValue;
                            bcAttribute.BillingCycle = billingCycle;

                            billingCycle.Attributes.Add(bcAttribute);
                        }
                    }
                }
            }

            if (registrationInfo.Subscription.SubscriptionAttributes != null && registrationInfo.Subscription.SubscriptionAttributes.Count > 0)
            {
                foreach (var key in registrationInfo.Subscription.SubscriptionAttributes.Keys)
                {
                    var attribute = new TSubscriptionAttribute()
                    {
                        AttributeName = key,
                        AttributeValue = registrationInfo.Subscription.SubscriptionAttributes[key],
                        Subscription = subscription
                    };

                    subscription.Attributes.Add(attribute);
                }
            }

            await SubscriptionManager.CreateAsync(subscription);
            return new DaRegistrationResult<TKey>(user.Id, userProfile.Id, tenant.Id, subscription.Id);
        }
    }
}
