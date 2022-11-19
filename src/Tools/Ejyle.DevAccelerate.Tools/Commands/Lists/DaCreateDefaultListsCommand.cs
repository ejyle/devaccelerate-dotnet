// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.EF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CommandLine;
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

namespace Ejyle.DevAccelerate.Tools.Commands.Lists
{
    [Verb("createlists", HelpText = "Creates default DevAccelerate lists.")]
    public class DaCreateDefaultListsCommand : DaDatabaseCommand
    {
        public override void Execute()
        {
            EnsureConnectionIsValid();

            using (var context = new DaListsDbContext(GetConnectionString()))
            {
                var currenciesManager = new DaCurrencyManager(new DaCurrencyRepository(context));
                var currencies = currenciesManager.FindAll();

                if(currencies == null)
                {
                    currencies = new List<DaCurrency>();
                }

                var systemCurrencies = NMoneys.Currency.FindAll().Distinct();
                var processedCurrencies = new List<string>();

                foreach (var c in systemCurrencies)
                {
                    var processedCurrency = processedCurrencies.Where(m => m == c.EnglishName).ToList();

                    if (processedCurrency == null || processedCurrency.Count <= 0)
                    {
                        var currency = currencies.Where(m => m.Name == c.EnglishName).SingleOrDefault();

                        if (currency == null)
                        {
                            currenciesManager.Create(new DaCurrency()
                            {
                                DisplayName = c.EnglishName,
                                Name = c.EnglishName,
                                NumericCode = c.NumericCode,
                                AlphabeticCode = c.AlphabeticCode,
                                CurrencySymbol = c.IsoSymbol,
                                IsVerified = true,
                                IsActive = true
                            });
                        }

                        processedCurrencies.Add(c.EnglishName);
                    }
                }

                var countryManager = new DaCountryManager(new DaCountryRepository(context));
                var countries = countryManager.FindAll();

                if (countries == null)
                {
                    countries = new List<DaCountry>();
                }

                var countriesList = GetCountries();

                foreach (var c in countriesList)
                {
                    var country = countries.Where(m => m.Name == c.Name).SingleOrDefault();

                    if (country == null)
                    {
                        countryManager.Create(c);
                    }
                }

                var timeZonesManager = new DaTimeZoneManager(new DaTimeZoneRepository(context));
                var timeZones = timeZonesManager.FindAll();

                if (timeZones == null)
                {
                    timeZones = new List<DaTimeZone>();
                }

                foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
                {
                    var timeZone = timeZones.Where(m => m.Name == z.StandardName).SingleOrDefault();

                    if (timeZone == null)
                    {
                        timeZonesManager.Create(new DaTimeZone()
                        {
                            SystemTimeZoneId = z.Id,
                            Name = z.StandardName,
                            DisplayName = z.DisplayName,
                            DaylightName = z.DaylightName,
                            SupportsDaylightSavingTime = z.SupportsDaylightSavingTime,
                            IsVerified = true,
                            IsActive = true
                        });
                    }
                }

                var dateFormatsManager = new DaDateFormatManager(new DaDateFormatRepository(context));
                var dateFormats = dateFormatsManager.FindAll();

                if (dateFormats == null)
                {
                    dateFormats = new List<DaDateFormat>();
                }

                var dataFormat = dateFormats.Where(m => m.Name == "MM/dd/yyyy").SingleOrDefault();
                if (dataFormat == null)
                {
                    dateFormatsManager.Create(new DaDateFormat()
                    {
                        DisplayName = "MM/dd/yyyy",
                        Name = "MM/dd/yyyy",
                        DateFormatExpression = "MM/dd/yyyy",
                        IsActive = true,
                        IsVerified = true
                    });
                }

                dataFormat = dateFormats.Where(m => m.Name == "dd/MM/yyyy").SingleOrDefault();
                if (dataFormat == null)
                {
                    dateFormatsManager.Create(new DaDateFormat()
                    {
                        DisplayName = "dd/MM/yyyy",
                        Name = "dd/MM/yyyy",
                        DateFormatExpression = "dd/MM/yyyy",
                        IsActive = true,
                        IsVerified = true
                    });
                }

                dataFormat = dateFormats.Where(m => m.Name == "dddd, dd MMMM yyyy").SingleOrDefault();
                if (dataFormat == null)
                {
                    dateFormatsManager.Create(new DaDateFormat()
                    {
                        DisplayName = "dddd, dd MMMM yyyy",
                        Name = "dddd, dd MMMM yyyy",
                        DateFormatExpression = "dddd, dd MMMM yyyy",
                        IsActive = true,
                        IsVerified = true
                    });
                }

                var sysLanguagesManager = new DaSystemLanguageManager(new DaSystemLanguageRepository(context));
                var sysLanguages = sysLanguagesManager.FindAll();

                if (sysLanguages == null)
                {
                    sysLanguages = new List<DaSystemLanguage>();
                }

                var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

                foreach (CultureInfo culture in cultures)
                {
                    if (!string.IsNullOrEmpty(culture.Name))
                    {
                        var systemLanguage = sysLanguages.Where(m => m.Name == culture.Name).SingleOrDefault();

                        if (systemLanguage == null)
                        {
                            sysLanguagesManager.Create(new DaSystemLanguage()
                            {
                                Name = culture.Name,
                                DisplayName = culture.DisplayName,
                                IsActive = true,
                                IsVerified = true
                            });
                        }
                    }
                }
            }

            Console.Write("Default set of lists created.");
        }

        private IEnumerable<DaCountry> GetCountries()
        {
            return new[] {
                new DaCountry("Afghanistan", "AF", "AFG", 4, "93"),
                new DaCountry("Åland Islands", "AX", "ALA", 248, "358"),
                new DaCountry("Albania", "AL", "ALB", 8, "355"),
                new DaCountry("Algeria", "DZ", "DZA", 12, "213"),
                new DaCountry("American Samoa", "AS", "ASM", 16, "1 684"),
                new DaCountry("Andorra", "AD", "AND", 20, "376"),
                new DaCountry("Angola", "AO", "AGO", 24, "244"),
                new DaCountry("Anguilla", "AI", "AIA", 660, "1 264"),
                new DaCountry("Antarctica", "AQ", "ATA", 10, "672"),
                new DaCountry("Antigua and Barbuda", "AG", "ATG", 28, "1 268"),
                new DaCountry("Argentina", "AR", "ARG", 32, "54"),
                new DaCountry("Armenia", "AM", "ARM", 51, "374"),
                new DaCountry("Aruba", "AW", "ABW", 533, "297"),
                new DaCountry("Australia", "AU", "AUS", 36, "61"),
                new DaCountry("Austria", "AT", "AUT", 40, "43"),
                new DaCountry("Azerbaijan", "AZ", "AZE", 31, "994"),
                new DaCountry("Bahamas", "BS", "BHS", 44, "1 242"),
                new DaCountry("Bahrain", "BH", "BHR", 48, "973"),
                new DaCountry("Bangladesh", "BD", "BGD", 50, "880"),
                new DaCountry("Barbados", "BB", "BRB", 52, "1 246"),
                new DaCountry("Belarus", "BY", "BLR", 112, "375"),
                new DaCountry("Belgium", "BE", "BEL", 56, "32"),
                new DaCountry("Belize", "BZ", "BLZ", 84, "501"),
                new DaCountry("Benin", "BJ", "BEN", 204, "229"),
                new DaCountry("Bermuda", "BM", "BMU", 60, "1 441"),
                new DaCountry("Bhutan", "BT", "BTN", 64, "975"),
                new DaCountry("Bolivia", "BO", "BOL", 68, "591"),
                new DaCountry("Bonaire, Sint Eustatius and Saba", "BQ", "BES", 535, "599"),
                new DaCountry("Bosnia and Herzegovina", "BA", "BIH", 70, "387"),
                new DaCountry("Botswana", "BW", "BWA", 72, "267"),
                new DaCountry("Brazil", "BR", "BRA", 76, "55"),
                new DaCountry("British Indian Ocean Territory", "IO", "IOT", 86, "246"),
                new DaCountry("Brunei Darussalam", "BN", "BRN", 96, "673"),
                new DaCountry("Bulgaria", "BG", "BGR", 100, "359"),
                new DaCountry("Burkina Faso", "BF", "BFA", 854, "226"),
                new DaCountry("Burundi", "BI", "BDI", 108, "257"),
                new DaCountry("Cabo Verde", "CV", "CPV", 132, "238"),
                new DaCountry("Cambodia", "KH", "KHM", 116, "855"),
                new DaCountry("Cameroon", "CM", "CMR", 120, "237"),
                new DaCountry("Canada", "CA", "CAN", 124, "1"),
                new DaCountry("Cayman Islands", "KY", "CYM", 136, "1 345"),
                new DaCountry("Central African Republic", "CF", "CAF", 140, "236"),
                new DaCountry("Chad", "TD", "TCD", 148, "235"),
                new DaCountry("Chile", "CL", "CHL", 152, "56"),
                new DaCountry("China", "CN", "CHN", 156, "86"),
                new DaCountry("Christmas Island", "CX", "CXR", 162, "61"),
                new DaCountry("Cocos (Keeling) Islands", "CC", "CCK", 166, "61"),
                new DaCountry("Colombia", "CO", "COL", 170, "57"),
                new DaCountry("Comoros", "KM", "COM", 174, "269"),
                new DaCountry("Congo", "CG", "COG", 178, "242"),
                new DaCountry("Congo (DRC)", "CD", "COD", 180, "243"),
                new DaCountry("Cook Islands", "CK", "COK", 184, "682"),
                new DaCountry("Costa Rica", "CR", "CRI", 188, "506"),
                new DaCountry("Côte d'Ivoire", "CI", "CIV", 384, "225"),
                new DaCountry("Croatia", "HR", "HRV", 191, "385"),
                new DaCountry("Cuba", "CU", "CUB", 192, "53"),
                new DaCountry("Curaçao", "CW", "CUW", 531, "599"),
                new DaCountry("Cyprus", "CY", "CYP", 196, "357"),
                new DaCountry("Czech Republic", "CZ", "CZE", 203, "420"),
                new DaCountry("Denmark", "DK", "DNK", 208, "45"),
                new DaCountry("Djibouti", "DJ", "DJI", 262, "253"),
                new DaCountry("Dominica", "DM", "DMA", 212, "1 767"),
                new DaCountry("Dominican Republic", "DO", "DOM", 214, "1 809"),
                new DaCountry("Ecuador", "EC", "ECU", 218, "593"),
                new DaCountry("Egypt", "EG", "EGY", 818, "20"),
                new DaCountry("El Salvador", "SV", "SLV", 222, "503"),
                new DaCountry("Equatorial Guinea", "GQ", "GNQ", 226, "240"),
                new DaCountry("Eritrea", "ER", "ERI", 232, "291"),
                new DaCountry("Estonia", "EE", "EST", 233, "372"),
                new DaCountry("Ethiopia", "ET", "ETH", 231, "251"),
                new DaCountry("Falkland Islands", "FK", "FLK", 238, "500"),
                new DaCountry("Faroe Islands", "FO", "FRO", 234, "298"),
                new DaCountry("Fiji", "FJ", "FJI", 242, "679"),
                new DaCountry("Finland", "FI", "FIN", 246, "358"),
                new DaCountry("France", "FR", "FRA", 250, "33"),
                new DaCountry("French Guiana", "GF", "GUF", 254, "594"),
                new DaCountry("French Polynesia", "PF", "PYF", 258, "689"),
                new DaCountry("French Southern Territories", "TF", "ATF", 260, "262"),
                new DaCountry("Gabon", "GA", "GAB", 266, "241"),
                new DaCountry("Gambia", "GM", "GMB", 270, "220"),
                new DaCountry("Georgia", "GE", "GEO", 268, "995"),
                new DaCountry("Germany", "DE", "DEU", 276, "49"),
                new DaCountry("Ghana", "GH", "GHA", 288, "233"),
                new DaCountry("Gibraltar", "GI", "GIB", 292, "350"),
                new DaCountry("Greece", "GR", "GRC", 300, "30"),
                new DaCountry("Greenland", "GL", "GRL", 304, "299"),
                new DaCountry("Grenada", "GD", "GRD", 308, "1 473"),
                new DaCountry("Guadeloupe", "GP", "GLP", 312, "590"),
                new DaCountry("Guam", "GU", "GUM", 316, "1 671"),
                new DaCountry("Guatemala", "GT", "GTM", 320, "502"),
                new DaCountry("Guernsey", "GG", "GGY", 831, "44 1481"),
                new DaCountry("Guinea", "GN", "GIN", 324, "224"),
                new DaCountry("Guinea-Bissau", "GW", "GNB", 624, "245"),
                new DaCountry("Guyana", "GY", "GUY", 328, "592"),
                new DaCountry("Haiti", "HT", "HTI", 332, "509"),
                new DaCountry("Holy See", "VA", "VAT", 336, "379"),
                new DaCountry("Honduras", "HN", "HND", 340, "504"),
                new DaCountry("Hong Kong", "HK", "HKG", 344, "852"),
                new DaCountry("Hungary", "HU", "HUN", 348, "36"),
                new DaCountry("Iceland", "IS", "ISL", 352, "354"),
                new DaCountry("India", "IN", "IND", 356, "91"),
                new DaCountry("Indonesia", "ID", "IDN", 360, "62"),
                new DaCountry("Iran", "IR", "IRN", 364, "98"),
                new DaCountry("Iraq", "IQ", "IRQ", 368, "964"),
                new DaCountry("Ireland", "IE", "IRL", 372, "353"),
                new DaCountry("Isle of Man", "IM", "IMN", 833, "44 1624"),
                new DaCountry("Israel", "IL", "ISR", 376, "972"),
                new DaCountry("Italy", "IT", "ITA", 380, "39"),
                new DaCountry("Jamaica", "JM", "JAM", 388, "1 876"),
                new DaCountry("Japan", "JP", "JPN", 392, "81"),
                new DaCountry("Jersey", "JE", "JEY", 832, "44 1534"),
                new DaCountry("Jordan", "JO", "JOR", 400, "962"),
                new DaCountry("Kazakhstan", "KZ", "KAZ", 398, "7"),
                new DaCountry("Kenya", "KE", "KEN", 404, "254"),
                new DaCountry("Kiribati", "KI", "KIR", 296, "686"),
                new DaCountry("North Korea", "KP", "PRK", 408, "850"),
                new DaCountry("South Korea", "KR", "KOR", 410, "82"),
                new DaCountry("Kuwait", "KW", "KWT", 414, "965"),
                new DaCountry("Kyrgyzstan", "KG", "KGZ", 417, "996"),
                new DaCountry("Laos", "LA", "LAO", 418, "856"),
                new DaCountry("Latvia", "LV", "LVA", 428, "371"),
                new DaCountry("Lebanon", "LB", "LBN", 422, "961"),
                new DaCountry("Lesotho", "LS", "LSO", 426, "266"),
                new DaCountry("Liberia", "LR", "LBR", 430, "231"),
                new DaCountry("Libya", "LY", "LBY", 434, "218"),
                new DaCountry("Liechtenstein", "LI", "LIE", 438, "423"),
                new DaCountry("Lithuania", "LT", "LTU", 440, "370"),
                new DaCountry("Luxembourg", "LU", "LUX", 442, "352"),
                new DaCountry("Macao", "MO", "MAC", 446, "853"),
                new DaCountry("Macedonia", "MK", "MKD", 807, "389"),
                new DaCountry("Madagascar", "MG", "MDG", 450, "261"),
                new DaCountry("Malawi", "MW", "MWI", 454, "265"),
                new DaCountry("Malaysia", "MY", "MYS", 458, "60"),
                new DaCountry("Maldives", "MV", "MDV", 462, "960"),
                new DaCountry("Mali", "ML", "MLI", 466, "223"),
                new DaCountry("Malta", "MT", "MLT", 470, "356"),
                new DaCountry("Marshall Islands", "MH", "MHL", 584, "692"),
                new DaCountry("Martinique", "MQ", "MTQ", 474, "596"),
                new DaCountry("Mauritania", "MR", "MRT", 478, "222"),
                new DaCountry("Mauritius", "MU", "MUS", 480, "230"),
                new DaCountry("Mayotte", "YT", "MYT", 175, "262"),
                new DaCountry("Mexico", "MX", "MEX", 484, "52"),
                new DaCountry("Micronesia", "FM", "FSM", 583, "691"),
                new DaCountry("Moldova", "MD", "MDA", 498, "373"),
                new DaCountry("Monaco", "MC", "MCO", 492, "377"),
                new DaCountry("Mongolia", "MN", "MNG", 496, "976"),
                new DaCountry("Montenegro", "ME", "MNE", 499, "382"),
                new DaCountry("Montserrat", "MS", "MSR", 500, "1 664"),
                new DaCountry("Morocco", "MA", "MAR", 504, "212"),
                new DaCountry("Mozambique", "MZ", "MOZ", 508, "258"),
                new DaCountry("Myanmar", "MM", "MMR", 104, "95"),
                new DaCountry("Namibia", "NA", "NAM", 516, "264"),
                new DaCountry("Nauru", "NR", "NRU", 520, "674"),
                new DaCountry("Nepal", "NP", "NPL", 524, "977"),
                new DaCountry("Netherlands", "NL", "NLD", 528, "31"),
                new DaCountry("New Caledonia", "NC", "NCL", 540, "687"),
                new DaCountry("New Zealand", "NZ", "NZL", 554, "64"),
                new DaCountry("Nicaragua", "NI", "NIC", 558, "505"),
                new DaCountry("Niger", "NE", "NER", 562, "227"),
                new DaCountry("Nigeria", "NG", "NGA", 566, "234"),
                new DaCountry("Niue", "NU", "NIU", 570, "683"),
                new DaCountry("Norfolk Island", "NF", "NFK", 574, "672"),
                new DaCountry("Northern Mariana Islands", "MP", "MNP", 580, "1 670"),
                new DaCountry("Norway", "NO", "NOR", 578, "47"),
                new DaCountry("Oman", "OM", "OMN", 512, "968"),
                new DaCountry("Pakistan", "PK", "PAK", 586, "92"),
                new DaCountry("Palau", "PW", "PLW", 585, "680"),
                new DaCountry("Palestinian Authority", "PS", "PSE", 275, "970"),
                new DaCountry("Panama", "PA", "PAN", 591, "507"),
                new DaCountry("Papua New Guinea", "PG", "PNG", 598, "675"),
                new DaCountry("Paraguay", "PY", "PRY", 600, "595"),
                new DaCountry("Peru", "PE", "PER", 604, "51"),
                new DaCountry("Philippines", "PH", "PHL", 608, "63"),
                new DaCountry("Pitcairn", "PN", "PCN", 612, "64"),
                new DaCountry("Poland", "PL", "POL", 616, "48"),
                new DaCountry("Portugal", "PT", "PRT", 620, "351"),
                new DaCountry("Puerto Rico", "PR", "PRI", 630, "1 787"),
                new DaCountry("Qatar", "QA", "QAT", 634, "974"),
                new DaCountry("Réunion", "RE", "REU", 638, "262"),
                new DaCountry("Romania", "RO", "ROU", 642, "40"),
                new DaCountry("Russia", "RU", "RUS", 643, "7"),
                new DaCountry("Rwanda", "RW", "RWA", 646, "250"),
                new DaCountry("Saint Barthélemy", "BL", "BLM", 652, "590"),
                new DaCountry("Saint Helena, Ascension and Tristan da Cunha", "SH", "SHN", 654, "290"),
                new DaCountry("Saint Kitts and Nevis", "KN", "KNA", 659, "1 869"),
                new DaCountry("Saint Lucia", "LC", "LCA", 662, "1 758"),
                new DaCountry("Saint Martin", "MF", "MAF", 663, "590"),
                new DaCountry("Saint Pierre and Miquelon", "PM", "SPM", 666, "508"),
                new DaCountry("Saint Vincent and the Grenadines", "VC", "VCT", 670, "1 784"),
                new DaCountry("Samoa", "WS", "WSM", 882, "685"),
                new DaCountry("Sao Tome and Principe", "ST", "STP", 678, "239"),
                new DaCountry("Saudi Arabia", "SA", "SAU", 682, "966"),
                new DaCountry("Senegal", "SN", "SEN", 686, "221"),
                new DaCountry("Serbia", "RS", "SRB", 688, "381"),
                new DaCountry("Seychelles", "SC", "SYC", 690, "248"),
                new DaCountry("Sierra Leone", "SL", "SLE", 694, "232"),
                new DaCountry("Singapore", "SG", "SGP", 702, "65"),
                new DaCountry("Sint Maarten", "SX", "SXM", 534, "1 721"),
                new DaCountry("Slovakia", "SK", "SVK", 703, "421"),
                new DaCountry("Slovenia", "SI", "SVN", 705, "386"),
                new DaCountry("Solomon Islands", "SB", "SLB", 90, "677"),
                new DaCountry("Somalia", "SO", "SOM", 706, "252"),
                new DaCountry("South Africa", "ZA", "ZAF", 710, "27"),
                new DaCountry("South Georgia and the South Sandwich Islands", "GS", "SGS", 239, "500"),
                new DaCountry("South Sudan", "SS", "SSD", 728, "211"),
                new DaCountry("Spain", "ES", "ESP", 724, "34"),
                new DaCountry("Sri Lanka", "LK", "LKA", 144, "94"),
                new DaCountry("Sudan", "SD", "SDN", 729, "249"),
                new DaCountry("Suriname", "SR", "SUR", 740, "597"),
                new DaCountry("Svalbard and Jan Mayen", "SJ", "SJM", 744, "47"),
                new DaCountry("Swaziland", "SZ", "SWZ", 748, "268"),
                new DaCountry("Sweden", "SE", "SWE", 752, "46"),
                new DaCountry("Switzerland", "CH", "CHE", 756, "41"),
                new DaCountry("Syrian", "SY", "SYR", 760, "963"),
                new DaCountry("Taiwan", "TW", "TWN", 158, "886"),
                new DaCountry("Tajikistan", "TJ", "TJK", 762, "992"),
                new DaCountry("Tanzania", "TZ", "TZA", 834, "255"),
                new DaCountry("Thailand", "TH", "THA", 764, "66"),
                new DaCountry("Timor-Leste", "TL", "TLS", 626, "670"),
                new DaCountry("Togo", "TG", "TGO", 768, "228"),
                new DaCountry("Tokelau", "TK", "TKL", 772, "690"),
                new DaCountry("Tonga", "TO", "TON", 776, "676"),
                new DaCountry("Trinidad and Tobago", "TT", "TTO", 780, "1 868"),
                new DaCountry("Tunisia", "TN", "TUN", 788, "216"),
                new DaCountry("Turkey", "TR", "TUR", 792, "90"),
                new DaCountry("Turkmenistan", "TM", "TKM", 795, "993"),
                new DaCountry("Turks and Caicos Islands", "TC", "TCA", 796, "1 649"),
                new DaCountry("Tuvalu", "TV", "TUV", 798, "688"),
                new DaCountry("Uganda", "UG", "UGA", 800, "256"),
                new DaCountry("Ukraine", "UA", "UKR", 804, "380"),
                new DaCountry("United Arab Emirates", "AE", "ARE", 784, "971"),
                new DaCountry("United Kingdom", "GB", "GBR", 826, "44"),
                new DaCountry("United States of America", "US", "USA", 840, "1"),
                new DaCountry("Uruguay", "UY", "URY", 858, "598"),
                new DaCountry("Uzbekistan", "UZ", "UZB", 860, "998"),
                new DaCountry("Vanuatu", "VU", "VUT", 548, "678"),
                new DaCountry("Venezuela", "VE", "VEN", 862, "58"),
                new DaCountry("Viet Nam", "VN", "VNM", 704, "84"),
                new DaCountry("British Virgin Islands", "VG", "VGB", 92, "1 284"),
                new DaCountry("U.S. Virgin Islands", "VI", "VIR", 850, "1 340"),
                new DaCountry("Wallis and Futuna", "WF", "WLF", 876, "681"),
                new DaCountry("Western Sahara", "EH", "ESH", 732, "212"),
                new DaCountry("Yemen", "YE", "YEM", 887, "967"),
                new DaCountry("Zambia", "ZM", "ZMB", 894, "260"),
                new DaCountry("Zimbabwe", "ZW", "ZWE", 716, "263" )
             };
        }
    }
}
