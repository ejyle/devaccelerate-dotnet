using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Migrations
{
    /// <inheritdoc />
    public partial class DaEnterpriseSecurityDbMigrationv700 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EnterpriseSecurity");

            migrationBuilder.CreateTable(
                name: "Apps",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectTypes",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsAutoRenewUntilCanceled = table.Column<bool>(type: "bit", nullable: false),
                    ValidityInMonths = table.Column<int>(type: "int", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    SetupFee = table.Column<double>(type: "float", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    AllowTrial = table.Column<bool>(type: "bit", nullable: false),
                    StartOnlyWithTrial = table.Column<bool>(type: "bit", nullable: false),
                    TrialDays = table.Column<int>(type: "int", nullable: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    UserAgreementVersionId = table.Column<int>(type: "int", nullable: true),
                    PublishedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DefaultBillingCycleId = table.Column<int>(type: "int", nullable: true),
                    BillingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantType = table.Column<int>(type: "int", nullable: false),
                    OwnerUserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsDomainOwnershipVerified = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    TimeZoneId = table.Column<int>(type: "int", nullable: true),
                    BillingEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DateFormatId = table.Column<int>(type: "int", nullable: true),
                    SystemLanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppAttributes",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAttributes_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Apps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAgreements",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAgreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAgreements_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Apps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ObjectInstances",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObjectTypeId = table.Column<int>(type: "int", nullable: false),
                    SourceObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectInstances_ObjectTypes_ObjectTypeId",
                        column: x => x.ObjectTypeId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "ObjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingCycleOptions",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingInterval = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubscriptionPlanId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingCycleOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingCycleOptions_SubscriptionPlans_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlanApps",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionPlanId = table.Column<int>(type: "int", nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlanApps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionPlanApps_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionPlanApps_SubscriptionPlans_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlanAttributes",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionPlanId = table.Column<int>(type: "int", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Target = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlanAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionPlanAttributes_SubscriptionPlans_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    ExpiryDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    BillingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillingInterval = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    UserAgreementVersionId = table.Column<int>(type: "int", nullable: true),
                    OwnerUserId = table.Column<int>(type: "int", nullable: false),
                    LastTransactionId = table.Column<int>(type: "int", nullable: true),
                    LastPaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    SubscriptionPlanId = table.Column<int>(type: "int", nullable: false),
                    IsCurrentlyInTrial = table.Column<bool>(type: "bit", nullable: false),
                    TrialPeriodStartDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrialPeriodEndDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAutoRenewUntilCanceled = table.Column<bool>(type: "bit", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextBillingDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrialStartDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionPlans_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantAttributes",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantAttributes_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantUsers",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantUsers_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppFeatures",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFeatures_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppFeatures_Features_AppId",
                        column: x => x.AppId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureActions",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureActions_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlanFeatures",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionPlanId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false),
                    MaximumQuantity = table.Column<double>(type: "float", nullable: true),
                    SubscriptionPlanFeatureType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlanFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionPlanFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionPlanFeatures_SubscriptionPlans_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAgreementVersions",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAgreementId = table.Column<int>(type: "int", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    PublishedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAgreementVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAgreementVersions_UserAgreements_UserAgreementId",
                        column: x => x.UserAgreementId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "UserAgreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectHistoryItems",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObjectInstanceId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNoteHtml = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectHistoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectHistoryItems_ObjectInstances_ObjectInstanceId",
                        column: x => x.ObjectInstanceId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "ObjectInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingCycles",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    FromDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingCycles_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionApps",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionApps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionApps_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionApps_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionAttributes",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionAttributes_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionFeatures",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false),
                    MaximumQuantity = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionPlanFeatureType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionFeatures_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlanFeatureAttributes",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionPlanFeatureId = table.Column<int>(type: "int", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlanFeatureAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionPlanFeatureAttributes_SubscriptionPlanFeatures_SubscriptionPlanFeatureId",
                        column: x => x.SubscriptionPlanFeatureId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionPlanFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAgreementVersionActions",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAgreementVersionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionOwner = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAgreementVersionActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAgreementVersionActions_UserAgreementVersions_UserAgreementVersionId",
                        column: x => x.UserAgreementVersionId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "UserAgreementVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingCycleAttributes",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillingCycleId = table.Column<int>(type: "int", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingCycleAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingCycleAttributes_BillingCycles_BillingCycleId",
                        column: x => x.BillingCycleId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "BillingCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionAppRoles",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionAppId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionAppRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionAppRoles_SubscriptionApps_SubscriptionAppId",
                        column: x => x.SubscriptionAppId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionAppUsers",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionAppId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionAppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionAppUsers_SubscriptionApps_SubscriptionAppId",
                        column: x => x.SubscriptionAppId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingCycleFeatureUsage",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillingCycleId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionFeatureId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingCycleFeatureUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingCycleFeatureUsage_BillingCycles_BillingCycleId",
                        column: x => x.BillingCycleId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "BillingCycles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillingCycleFeatureUsage_SubscriptionFeatures_SubscriptionFeatureId",
                        column: x => x.SubscriptionFeatureId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionFeatureAttributes",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionFeatureId = table.Column<int>(type: "int", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionFeatureAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionFeatureAttributes_SubscriptionFeatures_SubscriptionFeatureId",
                        column: x => x.SubscriptionFeatureId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionFeatureRole",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionFeatureId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionFeatureRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionFeatureRole_SubscriptionFeatures_SubscriptionFeatureId",
                        column: x => x.SubscriptionFeatureId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionFeatureUsers",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionFeatureId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionFeatureUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionFeatureUsers_SubscriptionFeatures_SubscriptionFeatureId",
                        column: x => x.SubscriptionFeatureId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionFeatureRoleActions",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionFeatureRoleId = table.Column<int>(type: "int", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Allowed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionFeatureRoleActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionFeatureRoleActions_SubscriptionFeatureRole_SubscriptionFeatureRoleId",
                        column: x => x.SubscriptionFeatureRoleId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionFeatureRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionFeatureUserActions",
                schema: "EnterpriseSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionFeatureUserId = table.Column<int>(type: "int", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Allowed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionFeatureUserActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionFeatureUserActions_SubscriptionFeatureUsers_SubscriptionFeatureUserId",
                        column: x => x.SubscriptionFeatureUserId,
                        principalSchema: "EnterpriseSecurity",
                        principalTable: "SubscriptionFeatureUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAttributes_AppId",
                schema: "EnterpriseSecurity",
                table: "AppAttributes",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFeatures_AppId",
                schema: "EnterpriseSecurity",
                table: "AppFeatures",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_Key",
                schema: "EnterpriseSecurity",
                table: "Apps",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillingCycleAttributes_BillingCycleId",
                schema: "EnterpriseSecurity",
                table: "BillingCycleAttributes",
                column: "BillingCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingCycleFeatureUsage_BillingCycleId",
                schema: "EnterpriseSecurity",
                table: "BillingCycleFeatureUsage",
                column: "BillingCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingCycleFeatureUsage_SubscriptionFeatureId",
                schema: "EnterpriseSecurity",
                table: "BillingCycleFeatureUsage",
                column: "SubscriptionFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingCycleOptions_SubscriptionPlanId",
                schema: "EnterpriseSecurity",
                table: "BillingCycleOptions",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingCycles_SubscriptionId",
                schema: "EnterpriseSecurity",
                table: "BillingCycles",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureActions_FeatureId",
                schema: "EnterpriseSecurity",
                table: "FeatureActions",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_AppId",
                schema: "EnterpriseSecurity",
                table: "Features",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectHistoryItems_ObjectInstanceId",
                schema: "EnterpriseSecurity",
                table: "ObjectHistoryItems",
                column: "ObjectInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectInstances_ObjectTypeId",
                schema: "EnterpriseSecurity",
                table: "ObjectInstances",
                column: "ObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionAppRoles_SubscriptionAppId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionAppRoles",
                column: "SubscriptionAppId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionApps_AppId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionApps",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionApps_SubscriptionId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionApps",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionAppUsers_SubscriptionAppId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionAppUsers",
                column: "SubscriptionAppId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionAttributes_SubscriptionId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionAttributes",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionFeatureAttributes_SubscriptionFeatureId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionFeatureAttributes",
                column: "SubscriptionFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionFeatureRole_SubscriptionFeatureId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionFeatureRole",
                column: "SubscriptionFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionFeatureRoleActions_SubscriptionFeatureRoleId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionFeatureRoleActions",
                column: "SubscriptionFeatureRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionFeatures_FeatureId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionFeatures_SubscriptionId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionFeatures",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionFeatureUserActions_SubscriptionFeatureUserId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionFeatureUserActions",
                column: "SubscriptionFeatureUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionFeatureUsers_SubscriptionFeatureId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionFeatureUsers",
                column: "SubscriptionFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPlanApps_AppId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionPlanApps",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPlanApps_SubscriptionPlanId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionPlanApps",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPlanAttributes_SubscriptionPlanId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionPlanAttributes",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPlanFeatureAttributes_SubscriptionPlanFeatureId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionPlanFeatureAttributes",
                column: "SubscriptionPlanFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPlanFeatures_FeatureId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionPlanFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPlanFeatures_SubscriptionPlanId",
                schema: "EnterpriseSecurity",
                table: "SubscriptionPlanFeatures",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPlans_Code",
                schema: "EnterpriseSecurity",
                table: "SubscriptionPlans",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionPlanId",
                schema: "EnterpriseSecurity",
                table: "Subscriptions",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantAttributes_TenantId",
                schema: "EnterpriseSecurity",
                table: "TenantAttributes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Domain",
                schema: "EnterpriseSecurity",
                table: "Tenants",
                column: "Domain",
                unique: true,
                filter: "[Domain] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Name",
                schema: "EnterpriseSecurity",
                table: "Tenants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenantUsers_TenantId",
                schema: "EnterpriseSecurity",
                table: "TenantUsers",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAgreements_AppId",
                schema: "EnterpriseSecurity",
                table: "UserAgreements",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAgreementVersionActions_UserAgreementVersionId",
                schema: "EnterpriseSecurity",
                table: "UserAgreementVersionActions",
                column: "UserAgreementVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAgreementVersions_UserAgreementId",
                schema: "EnterpriseSecurity",
                table: "UserAgreementVersions",
                column: "UserAgreementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAttributes",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "AppFeatures",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "BillingCycleAttributes",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "BillingCycleFeatureUsage",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "BillingCycleOptions",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "FeatureActions",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "ObjectHistoryItems",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionAppRoles",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionAppUsers",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionAttributes",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionFeatureAttributes",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionFeatureRoleActions",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionFeatureUserActions",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionPlanApps",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionPlanAttributes",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionPlanFeatureAttributes",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "TenantAttributes",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "TenantUsers",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "UserAgreementVersionActions",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "BillingCycles",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "ObjectInstances",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionApps",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionFeatureRole",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionFeatureUsers",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionPlanFeatures",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "UserAgreementVersions",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "ObjectTypes",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionFeatures",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "UserAgreements",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "Subscriptions",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "Apps",
                schema: "EnterpriseSecurity");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans",
                schema: "EnterpriseSecurity");
        }
    }
}
