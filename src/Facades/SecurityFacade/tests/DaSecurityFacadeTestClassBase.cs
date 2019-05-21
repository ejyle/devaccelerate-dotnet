using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.SubscriptionPlans;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Tenants;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.UserAgreements;
using Ejyle.DevAccelerate.Facades.Security.Subscriptions;
using Ejyle.DevAccelerate.Identity.EF;
using Ejyle.DevAccelerate.List.EF.Culture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ejyle.DevAccelerate.Facades.Security.Tests
{
    public abstract class DaSecurityFacadeTestClassBase
    {
        protected DaSubscriptionFacade GetSubscriptionFacade()
        {
            var userManager = new DaUserManager(new DaUserRepository(DaSecurityFacadeTestSuite.IdentityDbContext));
            var tenantManager = new DaTenantManager(new DaTenantRepository(DaSecurityFacadeTestSuite.EnterpriseSecurityDbContext));
            var appManager = new DaAppManager(new DaAppRepository(DaSecurityFacadeTestSuite.EnterpriseSecurityDbContext));
            var featureManager = new DaFeatureManager(new DaFeatureRepository(DaSecurityFacadeTestSuite.EnterpriseSecurityDbContext));
            var userAgreementManager = new DaUserAgreementManager(new DaUserAgreementRepository(DaSecurityFacadeTestSuite.EnterpriseSecurityDbContext));
            var subscriptionPlanManager = new DaSubscriptionPlanManager(new DaSubscriptionPlanRepository(DaSecurityFacadeTestSuite.EnterpriseSecurityDbContext));
            var subscriptionManager = new DaSubscriptionManager(new DaSubscriptionRepository(DaSecurityFacadeTestSuite.EnterpriseSecurityDbContext));

            var currencyManager = new DaCurrencyManager(new DaCurrencyRepository(DaSecurityFacadeTestSuite.ListsDbContext));
            var countryManager = new DaCountryManager(new DaCountryRepository(DaSecurityFacadeTestSuite.ListsDbContext));
            var timeZoneManager = new DaTimeZoneManager(new DaTimeZoneRepository(DaSecurityFacadeTestSuite.ListsDbContext));
            var systemLanguageManager = new DaSystemLanguageManager(new DaSystemLanguageRepository(DaSecurityFacadeTestSuite.ListsDbContext));

            return new DaSubscriptionFacade(userManager, tenantManager, appManager, featureManager, userAgreementManager, subscriptionPlanManager, subscriptionManager, currencyManager, countryManager, timeZoneManager, systemLanguageManager);
        }

        [TestInitialize]
        public virtual void Initialize()
        {
        }

        [TestCleanup]
        public virtual void Cleanup()
        {

        }
    }
}
