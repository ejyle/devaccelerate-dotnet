using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF;
using Ejyle.DevAccelerate.Facades.Security.Tests.Properties;
using Ejyle.DevAccelerate.Identity;
using Ejyle.DevAccelerate.Identity.EF;
using Ejyle.DevAccelerate.List.Culture;
using Ejyle.DevAccelerate.List.EF;
using Ejyle.DevAccelerate.List.EF.Culture;
using Ejyle.DevAccelerate.Mail;
using Ejyle.DevAccelerate.Sms;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Facades.Security.Tests
{
    [TestClass]
    public class DaSecurityFacadeTestSuite
    {
        private static DaIdentityDbContext identityDbContext = null;
        private static DaEnterpriseSecurityDbContext enterpriseSecurityDbContext = null;
        private static DaListsDbContext listsDbContext = null;

        public static DaIdentityDbContext IdentityDbContext
        {
            get
            {
                return identityDbContext;
            }
        }

        public static DaEnterpriseSecurityDbContext EnterpriseSecurityDbContext
        {
            get
            {
                return enterpriseSecurityDbContext;
            }
        }

        public static DaListsDbContext ListsDbContext
        {
            get
            {
                return listsDbContext;
            }
        }

        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            var configSource = new DaDefaultConfigurationSource();

            DaInitializationManager.AddModuleInitializer(new DaDefaultDataInitializer(configSource));
            DaInitializationManager.AddModuleInitializer(new DaDefaultAppsInitializer(configSource));
            DaInitializationManager.AddModuleInitializer(new DaDefaultIdentityInitializer(configSource));
            DaInitializationManager.AddModuleInitializer(new DaDefaultMailInitializer(configSource));
            DaInitializationManager.AddModuleInitializer(new DaDefaultSmsInitializer(configSource));

            DaInitializationManager.Execute();

            identityDbContext = new DaIdentityDbContext();
            enterpriseSecurityDbContext = new DaEnterpriseSecurityDbContext();
            listsDbContext = new DaListsDbContext();

            identityDbContext.Database.CreateIfNotExists();
            enterpriseSecurityDbContext.Database.CreateIfNotExists();
            listsDbContext.Database.CreateIfNotExists();

            CreateSystemRoles();
            CreateGlobalSuperAdminUser();

            var userManager = new DaUserManager(new DaUserRepository(identityDbContext));
            var user = userManager.FindByName(DaUser.GLOBAL_SUPER_ADMIN);

            CreateDefaultLists();
            LoadEnterpriseSecurityData(user.Id);
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            identityDbContext.Database.Delete();
            enterpriseSecurityDbContext.Database.Delete();
            listsDbContext.Database.Delete();

            identityDbContext.Dispose();
            enterpriseSecurityDbContext.Dispose();
            listsDbContext.Dispose();

            identityDbContext = null;
            enterpriseSecurityDbContext = null;
            listsDbContext = null;
        }

        private static void CreateSystemRoles()
        {
            string[] systemRoles = { DaRole.GLOBAL_SUPER_ADMIN, DaRole.TENANT_SUPER_ADMIN, DaRole.USER };

            var roleManager = new DaRoleManager(new DaRoleRepository(identityDbContext));
            DaRole role = null;

            foreach (var systemRole in systemRoles)
            {
                role = new DaRole();
                role.Name = systemRole;

                var result = DaAsyncHelper.RunSync<IdentityResult>(() => roleManager.CreateAsync(role));

                if (!result.Succeeded)
                {
                    if (result.Errors != null && result.Errors.Count() > 0)
                    {
                        StringBuilder sbMessages = new StringBuilder();

                        foreach (var err in result.Errors)
                        {
                            sbMessages.Append(err + " ");
                        }

                        throw new Exception(sbMessages.ToString());
                    }
                }
            }
        }

        private static void CreateGlobalSuperAdminUser()
        {
            IdentityResult result = null;

            var userManager = new DaUserManager(new DaUserRepository(identityDbContext));

            var user = new DaUser();
            user.UserName = DaUser.GLOBAL_SUPER_ADMIN;
            user.Email = "email@example.com";
            user.Status = DaAccountStatus.Active;

            result = userManager.Create(user, "Password#321");

            if (!result.Succeeded)
            {
                if (result.Errors != null && result.Errors.Count() > 0)
                {
                    StringBuilder sbMessage = new StringBuilder();

                    foreach (var err in result.Errors)
                    {
                        sbMessage.Append(err + " ");
                    }

                    throw new Exception(sbMessage.ToString());
                }
            }
        }

        public static void CreateDefaultLists()
        {
            var currenciesManager = new DaCurrencyManager(new DaCurrencyRepository(listsDbContext));
            var currencies = currenciesManager.FindAll();

            if (currencies == null || currencies.Count <= 0)
            {
                var currenciesList = NMoneys.Currency.FindAll().Distinct();
                var processedCurrencies = new List<string>();

                foreach (var c in currenciesList)
                {
                    var processedCurrency = processedCurrencies.Where(m => m == c.EnglishName).ToList();

                    if (processedCurrency == null || processedCurrency.Count <= 0)
                    {
                        currenciesManager.Create(new List.Culture.DaCurrency()
                        {
                            Name = c.EnglishName,
                            NativeName = c.NativeName,
                            CurrencyCode = c.AlphabeticCode,
                            CurrencySymbol = c.IsoSymbol,
                            IsActive = true
                        });

                        processedCurrencies.Add(c.EnglishName);
                    }
                }
            }

            var countryManager = new DaCountryManager(new DaCountryRepository(listsDbContext));
            var countries = countryManager.FindAll();

            if (countries == null || countries.Count <= 0)
            {
                var countriesList = GetCountries();

                foreach (var c in countriesList)
                {
                    countryManager.Create(c);
                }
            }

            var timeZonesManager = new DaTimeZoneManager(new DaTimeZoneRepository(listsDbContext));
            var timeZones = timeZonesManager.FindAll();

            if (timeZones == null || timeZones.Count <= 0)
            {
                foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
                {
                    timeZonesManager.Create(new List.Culture.DaTimeZone()
                    {
                        SystemTimeZoneId = z.Id,
                        Name = z.StandardName,
                        DisplayName = z.DisplayName,
                        DaylightName = z.DaylightName,
                        SupportsDaylightSavingTime = z.SupportsDaylightSavingTime,
                        IsActive = true
                    });
                }
            }

            var dateFormatsManager = new DaDateFormatManager(new DaDateFormatRepository(listsDbContext));
            var dateFormats = dateFormatsManager.FindAll();

            if (dateFormats == null || dateFormats.Count <= 0)
            {
                // Fil up date formats
            }

            var sysLanguagesManager = new DaSystemLanguageManager(new DaSystemLanguageRepository(listsDbContext));
            var sysLanguages = sysLanguagesManager.FindAll();

            if (sysLanguages == null || sysLanguages.Count <= 0)
            {
                var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

                foreach (CultureInfo culture in cultures)
                {
                    if (!string.IsNullOrEmpty(culture.Name))
                    {
                        sysLanguagesManager.Create(new List.Culture.DaSystemLanguage()
                        {
                            Name = culture.Name,
                            DisplayName = culture.DisplayName,
                            IsActive = true
                        });
                    }
                }
            }
        }

        private static void LoadEnterpriseSecurityData(int userId)
        {
            var paramUserId = new SqlParameter()
            {
                ParameterName = "@UserId",
                Direction = System.Data.ParameterDirection.Input,
                SqlDbType = System.Data.SqlDbType.Int,
                Value = userId
            };

            enterpriseSecurityDbContext.Database.ExecuteSqlCommand(Resources.InsertEnterpriseSecurityData, paramUserId);
        }

        private static IEnumerable<DaCountry> GetCountries()
        {
            return new[] {
                new DaCountry("Afghanistan", "AF", "AFG", 4, new[] { "93" }),
                new DaCountry("Åland Islands", "AX", "ALA", 248, new[] { "358" }),
                new DaCountry("Albania", "AL", "ALB", 8, new[] { "355" }),
                new DaCountry("Algeria", "DZ", "DZA", 12, new[] { "213" }),
                new DaCountry("American Samoa", "AS", "ASM", 16, new[] { "1 684" }),
                new DaCountry("Andorra", "AD", "AND", 20, new[] { "376" }),
                new DaCountry("Angola", "AO", "AGO", 24, new[] { "244" }),
                new DaCountry("Anguilla", "AI", "AIA", 660, new[] { "1 264" }),
                new DaCountry("Antarctica", "AQ", "ATA", 10, new[] { "672" }),
                new DaCountry("Antigua and Barbuda", "AG", "ATG", 28, new[] { "1 268" }),
                new DaCountry("Argentina", "AR", "ARG", 32, new[] { "54" }),
                new DaCountry("Armenia", "AM", "ARM", 51, new[] { "374" }),
                new DaCountry("Aruba", "AW", "ABW", 533, new[] { "297" }),
                new DaCountry("Australia", "AU", "AUS", 36, new[] { "61" }),
                new DaCountry("Austria", "AT", "AUT", 40, new[] { "43" }),
                new DaCountry("Azerbaijan", "AZ", "AZE", 31, new[] { "994" }),
                new DaCountry("Bahamas", "BS", "BHS", 44, new[] { "1 242" }),
                new DaCountry("Bahrain", "BH", "BHR", 48, new[] { "973" }),
                new DaCountry("Bangladesh", "BD", "BGD", 50, new[] { "880" }),
                new DaCountry("Barbados", "BB", "BRB", 52, new[] { "1 246" }),
                new DaCountry("Belarus", "BY", "BLR", 112, new[] { "375" }),
                new DaCountry("Belgium", "BE", "BEL", 56, new[] { "32" }),
                new DaCountry("Belize", "BZ", "BLZ", 84, new[] { "501" }),
                new DaCountry("Benin", "BJ", "BEN", 204, new[] { "229" }),
                new DaCountry("Bermuda", "BM", "BMU", 60, new[] { "1 441" }),
                new DaCountry("Bhutan", "BT", "BTN", 64, new[] { "975" }),
                new DaCountry("Bolivia (Plurinational State of)", "BO", "BOL", 68, new[] { "591" }),
                new DaCountry("Bonaire, Sint Eustatius and Saba", "BQ", "BES", 535, new[] { "599" }),
                new DaCountry("Bosnia and Herzegovina", "BA", "BIH", 70, new[] { "387" }),
                new DaCountry("Botswana", "BW", "BWA", 72, new[] { "267" }),
                new DaCountry("Bouvet Island", "BV", "BVT", 74),
                new DaCountry("Brazil", "BR", "BRA", 76, new[] { "55" }),
                new DaCountry("British Indian Ocean Territory", "IO", "IOT", 86, new[] { "246" }),
                new DaCountry("Brunei Darussalam", "BN", "BRN", 96, new[] { "673" }),
                new DaCountry("Bulgaria", "BG", "BGR", 100, new[] { "359" }),
                new DaCountry("Burkina Faso", "BF", "BFA", 854, new[] { "226" }),
                new DaCountry("Burundi", "BI", "BDI", 108, new[] { "257" }),
                new DaCountry("Cabo Verde", "CV", "CPV", 132, new[] { "238" }),
                new DaCountry("Cambodia", "KH", "KHM", 116, new[] { "855" }),
                new DaCountry("Cameroon", "CM", "CMR", 120, new[] { "237" }),
                new DaCountry("Canada", "CA", "CAN", 124, new[] { "1" }),
                new DaCountry("Cayman Islands", "KY", "CYM", 136, new[] { "1 345" }),
                new DaCountry("Central African Republic", "CF", "CAF", 140, new[] { "236" }),
                new DaCountry("Chad", "TD", "TCD", 148, new[] { "235" }),
                new DaCountry("Chile", "CL", "CHL", 152, new[] { "56" }),
                new DaCountry("China", "CN", "CHN", 156, new[] { "86" }),
                new DaCountry("Christmas Island", "CX", "CXR", 162, new[] { "61" }),
                new DaCountry("Cocos (Keeling) Islands", "CC", "CCK", 166, new[] { "61" }),
                new DaCountry("Colombia", "CO", "COL", 170, new[] { "57" }),
                new DaCountry("Comoros", "KM", "COM", 174, new[] { "269" }),
                new DaCountry("Congo", "CG", "COG", 178, new[] { "242" }),
                new DaCountry("Congo (Democratic Republic of the)", "CD", "COD", 180, new[] { "243" }),
                new DaCountry("Cook Islands", "CK", "COK", 184, new[] { "682" }),
                new DaCountry("Costa Rica", "CR", "CRI", 188, new[] { "506" }),
                new DaCountry("Côte d'Ivoire", "CI", "CIV", 384, new[] { "225" }),
                new DaCountry("Croatia", "HR", "HRV", 191, new[] { "385" }),
                new DaCountry("Cuba", "CU", "CUB", 192, new[] { "53" }),
                new DaCountry("Curaçao", "CW", "CUW", 531, new[] { "599" }),
                new DaCountry("Cyprus", "CY", "CYP", 196, new[] { "357" }),
                new DaCountry("Czech Republic", "CZ", "CZE", 203, new[] { "420" }),
                new DaCountry("Denmark", "DK", "DNK", 208, new[] { "45" }),
                new DaCountry("Djibouti", "DJ", "DJI", 262, new[] { "253" }),
                new DaCountry("Dominica", "DM", "DMA", 212, new[] { "1 767" }),
                new DaCountry("Dominican Republic", "DO", "DOM", 214, new[] { "1 809", "1 829", "1 849" }),
                new DaCountry("Ecuador", "EC", "ECU", 218, new[] { "593" }),
                new DaCountry("Egypt", "EG", "EGY", 818, new[] { "20" }),
                new DaCountry("El Salvador", "SV", "SLV", 222, new[] { "503" }),
                new DaCountry("Equatorial Guinea", "GQ", "GNQ", 226, new[] { "240" }),
                new DaCountry("Eritrea", "ER", "ERI", 232, new[] { "291" }),
                new DaCountry("Estonia", "EE", "EST", 233, new[] { "372" }),
                new DaCountry("Ethiopia", "ET", "ETH", 231, new[] { "251" }),
                new DaCountry("Falkland Islands (Malvinas)", "FK", "FLK", 238, new[] { "500" }),
                new DaCountry("Faroe Islands", "FO", "FRO", 234, new[] { "298" }),
                new DaCountry("Fiji", "FJ", "FJI", 242, new[] { "679" }),
                new DaCountry("Finland", "FI", "FIN", 246, new[] { "358" }),
                new DaCountry("France", "FR", "FRA", 250, new[] { "33" }),
                new DaCountry("French Guiana", "GF", "GUF", 254, new[] { "594" }),
                new DaCountry("French Polynesia", "PF", "PYF", 258, new[] { "689" }),
                new DaCountry("French Southern Territories", "TF", "ATF", 260, new[] { "262" }),
                new DaCountry("Gabon", "GA", "GAB", 266, new[] { "241" }),
                new DaCountry("Gambia", "GM", "GMB", 270, new[] { "220" }),
                new DaCountry("Georgia", "GE", "GEO", 268, new[] { "995" }),
                new DaCountry("Germany", "DE", "DEU", 276, new[] { "49" }),
                new DaCountry("Ghana", "GH", "GHA", 288, new[] { "233" }),
                new DaCountry("Gibraltar", "GI", "GIB", 292, new[] { "350" }),
                new DaCountry("Greece", "GR", "GRC", 300, new[] { "30" }),
                new DaCountry("Greenland", "GL", "GRL", 304, new[] { "299" }),
                new DaCountry("Grenada", "GD", "GRD", 308, new[] { "1 473" }),
                new DaCountry("Guadeloupe", "GP", "GLP", 312, new[] { "590" }),
                new DaCountry("Guam", "GU", "GUM", 316, new[] { "1 671" }),
                new DaCountry("Guatemala", "GT", "GTM", 320, new[] { "502" }),
                new DaCountry("Guernsey", "GG", "GGY", 831, new[] { "44 1481" }),
                new DaCountry("Guinea", "GN", "GIN", 324, new[] { "224" }),
                new DaCountry("Guinea-Bissau", "GW", "GNB", 624, new[] { "245" }),
                new DaCountry("Guyana", "GY", "GUY", 328, new[] { "592" }),
                new DaCountry("Haiti", "HT", "HTI", 332, new[] { "509" }),
                new DaCountry("Heard Island and McDonald Islands", "HM", "HMD", 334),
                new DaCountry("Holy See", "VA", "VAT", 336, new[] { "379" }),
                new DaCountry("Honduras", "HN", "HND", 340, new[] { "504" }),
                new DaCountry("Hong Kong", "HK", "HKG", 344, new[] { "852" }),
                new DaCountry("Hungary", "HU", "HUN", 348, new[] { "36" }),
                new DaCountry("Iceland", "IS", "ISL", 352, new[] { "354" }),
                new DaCountry("India", "IN", "IND", 356, new[] { "91" }),
                new DaCountry("Indonesia", "ID", "IDN", 360, new[] { "62" }),
                new DaCountry("Iran (Islamic Republic of)", "IR", "IRN", 364, new[] { "98" }),
                new DaCountry("Iraq", "IQ", "IRQ", 368, new[] { "964" }),
                new DaCountry("Ireland", "IE", "IRL", 372, new[] { "353" }),
                new DaCountry("Isle of Man", "IM", "IMN", 833, new[] { "44 1624" }),
                new DaCountry("Israel", "IL", "ISR", 376, new[] { "972" }),
                new DaCountry("Italy", "IT", "ITA", 380, new[] { "39" }),
                new DaCountry("Jamaica", "JM", "JAM", 388, new[] { "1 876" }),
                new DaCountry("Japan", "JP", "JPN", 392, new[] { "81" }),
                new DaCountry("Jersey", "JE", "JEY", 832, new[] { "44 1534" }),
                new DaCountry("Jordan", "JO", "JOR", 400, new[] { "962" }),
                new DaCountry("Kazakhstan", "KZ", "KAZ", 398, new[] { "7" }),
                new DaCountry("Kenya", "KE", "KEN", 404, new[] { "254" }),
                new DaCountry("Kiribati", "KI", "KIR", 296, new[] { "686" }),
                new DaCountry("Korea (Democratic People's Republic of)", "KP", "PRK", 408, new[] { "850" }),
                new DaCountry("Korea (Republic of)", "KR", "KOR", 410, new[] { "82" }),
                new DaCountry("Kuwait", "KW", "KWT", 414, new[] { "965" }),
                new DaCountry("Kyrgyzstan", "KG", "KGZ", 417, new[] { "996" }),
                new DaCountry("Lao People's Democratic Republic", "LA", "LAO", 418, new[] { "856" }),
                new DaCountry("Latvia", "LV", "LVA", 428, new[] { "371" }),
                new DaCountry("Lebanon", "LB", "LBN", 422, new[] { "961" }),
                new DaCountry("Lesotho", "LS", "LSO", 426, new[] { "266" }),
                new DaCountry("Liberia", "LR", "LBR", 430, new[] { "231" }),
                new DaCountry("Libya", "LY", "LBY", 434, new[] { "218" }),
                new DaCountry("Liechtenstein", "LI", "LIE", 438, new[] { "423" }),
                new DaCountry("Lithuania", "LT", "LTU", 440, new[] { "370" }),
                new DaCountry("Luxembourg", "LU", "LUX", 442, new[] { "352" }),
                new DaCountry("Macao", "MO", "MAC", 446, new[] { "853" }),
                new DaCountry("Macedonia (the former Yugoslav Republic of)", "MK", "MKD", 807, new[] { "389" }),
                new DaCountry("Madagascar", "MG", "MDG", 450, new[] { "261" }),
                new DaCountry("Malawi", "MW", "MWI", 454, new[] { "265" }),
                new DaCountry("Malaysia", "MY", "MYS", 458, new[] { "60" }),
                new DaCountry("Maldives", "MV", "MDV", 462, new[] { "960" }),
                new DaCountry("Mali", "ML", "MLI", 466, new[] { "223" }),
                new DaCountry("Malta", "MT", "MLT", 470, new[] { "356" }),
                new DaCountry("Marshall Islands", "MH", "MHL", 584, new[] { "692" }),
                new DaCountry("Martinique", "MQ", "MTQ", 474, new[] { "596" }),
                new DaCountry("Mauritania", "MR", "MRT", 478, new[] { "222" }),
                new DaCountry("Mauritius", "MU", "MUS", 480, new[] { "230" }),
                new DaCountry("Mayotte", "YT", "MYT", 175, new[] { "262" }),
                new DaCountry("Mexico", "MX", "MEX", 484, new[] { "52" }),
                new DaCountry("Micronesia (Federated States of)", "FM", "FSM", 583, new[] { "691" }),
                new DaCountry("Moldova (Republic of)", "MD", "MDA", 498, new[] { "373" }),
                new DaCountry("Monaco", "MC", "MCO", 492, new[] { "377" }),
                new DaCountry("Mongolia", "MN", "MNG", 496, new[] { "976" }),
                new DaCountry("Montenegro", "ME", "MNE", 499, new[] { "382" }),
                new DaCountry("Montserrat", "MS", "MSR", 500, new[] { "1 664" }),
                new DaCountry("Morocco", "MA", "MAR", 504, new[] { "212" }),
                new DaCountry("Mozambique", "MZ", "MOZ", 508, new[] { "258" }),
                new DaCountry("Myanmar", "MM", "MMR", 104, new[] { "95" }),
                new DaCountry("Namibia", "NA", "NAM", 516, new[] { "264" }),
                new DaCountry("Nauru", "NR", "NRU", 520, new[] { "674" }),
                new DaCountry("Nepal", "NP", "NPL", 524, new[] { "977" }),
                new DaCountry("Netherlands", "NL", "NLD", 528, new[] { "31" }),
                new DaCountry("New Caledonia", "NC", "NCL", 540, new[] { "687" }),
                new DaCountry("New Zealand", "NZ", "NZL", 554, new[] { "64" }),
                new DaCountry("Nicaragua", "NI", "NIC", 558, new[] { "505" }),
                new DaCountry("Niger", "NE", "NER", 562, new[] { "227" }),
                new DaCountry("Nigeria", "NG", "NGA", 566, new[] { "234" }),
                new DaCountry("Niue", "NU", "NIU", 570, new[] { "683" }),
                new DaCountry("Norfolk Island", "NF", "NFK", 574, new[] { "672" }),
                new DaCountry("Northern Mariana Islands", "MP", "MNP", 580, new[] { "1 670" }),
                new DaCountry("Norway", "NO", "NOR", 578, new[] { "47" }),
                new DaCountry("Oman", "OM", "OMN", 512, new[] { "968" }),
                new DaCountry("Pakistan", "PK", "PAK", 586, new[] { "92" }),
                new DaCountry("Palau", "PW", "PLW", 585, new[] { "680" }),
                new DaCountry("Palestine, State of", "PS", "PSE", 275, new[] { "970" }),
                new DaCountry("Panama", "PA", "PAN", 591, new[] { "507" }),
                new DaCountry("Papua New Guinea", "PG", "PNG", 598, new[] { "675" }),
                new DaCountry("Paraguay", "PY", "PRY", 600, new[] { "595" }),
                new DaCountry("Peru", "PE", "PER", 604, new[] { "51" }),
                new DaCountry("Philippines", "PH", "PHL", 608, new[] { "63" }),
                new DaCountry("Pitcairn", "PN", "PCN", 612, new[] { "64" }),
                new DaCountry("Poland", "PL", "POL", 616, new[] { "48" }),
                new DaCountry("Portugal", "PT", "PRT", 620, new[] { "351" }),
                new DaCountry("Puerto Rico", "PR", "PRI", 630, new[] { "1 787", "1 939" }),
                new DaCountry("Qatar", "QA", "QAT", 634, new[] { "974" }),
                new DaCountry("Réunion", "RE", "REU", 638, new[] { "262" }),
                new DaCountry("Romania", "RO", "ROU", 642, new[] { "40" }),
                new DaCountry("Russian Federation", "RU", "RUS", 643, new[] { "7" }),
                new DaCountry("Rwanda", "RW", "RWA", 646, new[] { "250" }),
                new DaCountry("Saint Barthélemy", "BL", "BLM", 652, new[] { "590" }),
                new DaCountry("Saint Helena, Ascension and Tristan da Cunha", "SH", "SHN", 654, new[] { "290" }),
                new DaCountry("Saint Kitts and Nevis", "KN", "KNA", 659, new[] { "1 869" }),
                new DaCountry("Saint Lucia", "LC", "LCA", 662, new[] { "1 758" }),
                new DaCountry("Saint Martin (French part)", "MF", "MAF", 663, new[] { "590" }),
                new DaCountry("Saint Pierre and Miquelon", "PM", "SPM", 666, new[] { "508" }),
                new DaCountry("Saint Vincent and the Grenadines", "VC", "VCT", 670, new[] { "1 784" }),
                new DaCountry("Samoa", "WS", "WSM", 882, new[] { "685" }),
                new DaCountry("San Marino", "SP", "SMR", 674),
                new DaCountry("Sao Tome and Principe", "ST", "STP", 678, new[] { "239" }),
                new DaCountry("Saudi Arabia", "SA", "SAU", 682, new[] { "966" }),
                new DaCountry("Senegal", "SN", "SEN", 686, new[] { "221" }),
                new DaCountry("Serbia", "RS", "SRB", 688, new[] { "381" }),
                new DaCountry("Seychelles", "SC", "SYC", 690, new[] { "248" }),
                new DaCountry("Sierra Leone", "SL", "SLE", 694, new[] { "232" }),
                new DaCountry("Singapore", "SG", "SGP", 702, new[] { "65" }),
                new DaCountry("Sint Maarten (Dutch part)", "SX", "SXM", 534, new[] { "1 721" }),
                new DaCountry("Slovakia", "SK", "SVK", 703, new[] { "421" }),
                new DaCountry("Slovenia", "SI", "SVN", 705, new[] { "386" }),
                new DaCountry("Solomon Islands", "SB", "SLB", 90, new[] { "677" }),
                new DaCountry("Somalia", "SO", "SOM", 706, new[] { "252" }),
                new DaCountry("South Africa", "ZA", "ZAF", 710, new[] { "27" }),
                new DaCountry("South Georgia and the South Sandwich Islands", "GS", "SGS", 239, new[] { "500" }),
                new DaCountry("South Sudan", "SS", "SSD", 728, new[] { "211" }),
                new DaCountry("Spain", "ES", "ESP", 724, new[] { "34" }),
                new DaCountry("Sri Lanka", "LK", "LKA", 144, new[] { "94" }),
                new DaCountry("Sudan", "SD", "SDN", 729, new[] { "249" }),
                new DaCountry("Suriname", "SR", "SUR", 740, new[] { "597" }),
                new DaCountry("Svalbard and Jan Mayen", "SJ", "SJM", 744, new[] { "47" }),
                new DaCountry("Swaziland", "SZ", "SWZ", 748, new[] { "268" }),
                new DaCountry("Sweden", "SE", "SWE", 752, new[] { "46" }),
                new DaCountry("Switzerland", "CH", "CHE", 756, new[] { "41" }),
                new DaCountry("Syrian Arab Republic", "SY", "SYR", 760, new[] { "963" }),
                new DaCountry("Taiwan, Province of China[a]", "TW", "TWN", 158, new[] { "886" }),
                new DaCountry("Tajikistan", "TJ", "TJK", 762, new[] { "992" }),
                new DaCountry("Tanzania, United Republic of", "TZ", "TZA", 834, new[] { "255" }),
                new DaCountry("Thailand", "TH", "THA", 764, new[] { "66" }),
                new DaCountry("Timor-Leste", "TL", "TLS", 626, new[] { "670" }),
                new DaCountry("Togo", "TG", "TGO", 768, new[] { "228" }),
                new DaCountry("Tokelau", "TK", "TKL", 772, new[] { "690" }),
                new DaCountry("Tonga", "TO", "TON", 776, new[] { "676" }),
                new DaCountry("Trinidad and Tobago", "TT", "TTO", 780, new[] { "1 868" }),
                new DaCountry("Tunisia", "TN", "TUN", 788, new[] { "216" }),
                new DaCountry("Turkey", "TR", "TUR", 792, new[] { "90" }),
                new DaCountry("Turkmenistan", "TM", "TKM", 795, new[] { "993" }),
                new DaCountry("Turks and Caicos Islands", "TC", "TCA", 796, new[] { "1 649" }),
                new DaCountry("Tuvalu", "TV", "TUV", 798, new[] { "688" }),
                new DaCountry("Uganda", "UG", "UGA", 800, new[] { "256" }),
                new DaCountry("Ukraine", "UA", "UKR", 804, new[] { "380" }),
                new DaCountry("United Arab Emirates", "AE", "ARE", 784, new[] { "971" }),
                new DaCountry("United Kingdom of Great Britain and Northern Ireland", "GB", "GBR", 826, new[] { "44" }),
                new DaCountry("United States of America", "US", "USA", 840, new[] { "1" }),
                new DaCountry("United States Minor Outlying Islands", "UM", "UMI", 581),
                new DaCountry("Uruguay", "UY", "URY", 858, new[] { "598" }),
                new DaCountry("Uzbekistan", "UZ", "UZB", 860, new[] { "998" }),
                new DaCountry("Vanuatu", "VU", "VUT", 548, new[] { "678" }),
                new DaCountry("Venezuela (Bolivarian Republic of)", "VE", "VEN", 862, new[] { "58" }),
                new DaCountry("Viet Nam", "VN", "VNM", 704, new[] { "84" }),
                new DaCountry("Virgin Islands (British)", "VG", "VGB", 92, new[] { "1 284" }),
                new DaCountry("Virgin Islands (U.S.)", "VI", "VIR", 850, new[] { "1 340" }),
                new DaCountry("Wallis and Futuna", "WF", "WLF", 876, new[] { "681" }),
                new DaCountry("Western Sahara", "EH", "ESH", 732, new[] { "212" }),
                new DaCountry("Yemen", "YE", "YEM", 887, new[] { "967" }),
                new DaCountry("Zambia", "ZM", "ZMB", 894, new[] { "260" }),
                new DaCountry("Zimbabwe", "ZW", "ZWE", 716, new[] { "263" })
             };
        }
    }
}
