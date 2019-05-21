SET IDENTITY_INSERT [EnterpriseSecurity].[UserAgreements] ON

INSERT INTO [EnterpriseSecurity].[UserAgreements]
([Id], [Name],[Key],[AppId])
VALUES
(1, 'Subscription Agreement', 'subscription', 1)

SET IDENTITY_INSERT [EnterpriseSecurity].[UserAgreements] OFF

GO

SET IDENTITY_INSERT [EnterpriseSecurity].[UserAgreementVersions] ON

INSERT INTO [EnterpriseSecurity].[UserAgreementVersions]
([Id],[UserAgreementId],[VersionNumber],[Text],[IsCurrent],[IsPublished],[PublishedDateUtc])
VALUES(1, 1, 1, 'Here are the dummy terms and conditions', 'true', 'true', GETDATE())

SET IDENTITY_INSERT [EnterpriseSecurity].[UserAgreementVersions] OFF

GO

SET IDENTITY_INSERT [EnterpriseSecurity].[Features] ON

INSERT INTO [EnterpriseSecurity].[Features]
([Id],[Name],[Key],[AppId],[Status],[LastUpdatedDateUtc])
VALUES(1, 'Classification', 'classification', 1, 6, GETDATE())

INSERT INTO [EnterpriseSecurity].[Features]
([Id],[Name],[Key],[AppId],[Status],[LastUpdatedDateUtc])
VALUES(2, 'Duty Calculation', 'duty-calculation', 1, 6, GETDATE())

SET IDENTITY_INSERT [EnterpriseSecurity].[Features] OFF

GO

SET IDENTITY_INSERT [EnterpriseSecurity].[SubscriptionPlans] ON

INSERT INTO [EnterpriseSecurity].[SubscriptionPlans]
([Id],[Name],[Description],[Code],[IsAutoRenewByDefault],[MaximumUsers],[IsFeatured],[Status],[UserAgreementVersionId],[PublishedDateUtc])
VALUES(1, 'Silver Plan', 'A simple subscription that gives you most features.', 'SILVER', 'true', 10, 'false', 6, 1, GETDATE())

INSERT INTO [EnterpriseSecurity].[SubscriptionPlans]
([Id],[Name],[Description],[Code],[IsAutoRenewByDefault],[MaximumUsers],[IsFeatured],[Status],[UserAgreementVersionId],[PublishedDateUtc])
VALUES(2, 'Gold Plan', 'The best subscription that gives you all the features.', 'GOLD', 'true', 100, 'true', 6, 1, GETDATE())

SET IDENTITY_INSERT [EnterpriseSecurity].[SubscriptionPlans] OFF

GO

SET IDENTITY_INSERT [EnterpriseSecurity].[SubscriptionPlanApps] ON

INSERT INTO [EnterpriseSecurity].[SubscriptionPlanApps]
([Id],[SubscriptionPlanId],[AppId],[CreatedDateUtc])
VALUES(1, 1, 1, GETDATE())

INSERT INTO [EnterpriseSecurity].[SubscriptionPlanApps]
([Id],[SubscriptionPlanId],[AppId],[CreatedDateUtc])
VALUES(2, 2, 1, GETDATE())

SET IDENTITY_INSERT [EnterpriseSecurity].[SubscriptionPlanApps] OFF

GO

SET IDENTITY_INSERT [EnterpriseSecurity].[SubscriptionPlanFeatures] ON

INSERT INTO [EnterpriseSecurity].[SubscriptionPlanFeatures]
([Id], [SubscriptionPlanId],[FeatureId],[CreatedDateUtc])
VALUES (1, 1, 1, GETDATE())

INSERT INTO [EnterpriseSecurity].[SubscriptionPlanFeatures]
([Id], [SubscriptionPlanId],[FeatureId],[CreatedDateUtc])
VALUES (2, 2, 1, GETDATE())

INSERT INTO [EnterpriseSecurity].[SubscriptionPlanFeatures]
([Id], [SubscriptionPlanId],[FeatureId],[CreatedDateUtc])
VALUES (3, 2, 2, GETDATE())

SET IDENTITY_INSERT [EnterpriseSecurity].[SubscriptionPlanFeatures] OFF

GO

SET IDENTITY_INSERT [EnterpriseSecurity].[SubscriptionPlanFeatureAttributes] ON

INSERT INTO [EnterpriseSecurity].[SubscriptionPlanFeatureAttributes]
([Id], [SubscriptionPlanFeatureId],[Name],[Value])
VALUES(1, 1, 'num_classifications', '1000')

INSERT INTO [EnterpriseSecurity].[SubscriptionPlanFeatureAttributes]
([Id], [SubscriptionPlanFeatureId],[Name],[Value])
VALUES(2, 2, 'num_classifications', '10000')

SET IDENTITY_INSERT [EnterpriseSecurity].[SubscriptionPlanFeatureAttributes] OFF

GO

SET IDENTITY_INSERT [EnterpriseSecurity].[BillingCycles] ON

INSERT INTO [EnterpriseSecurity].[BillingCycles]
([Id],[BillingCycleType],[BillingCycleDuration],[Amount],[CurrencyId],[SubscriptionPlanId],[Name],[Description],[AllowTrial],[StartOnlyWithTrial],[TrialDuration],[TrialDurationType])
VALUES(1, 1, 1, 99, 1, 1, 'Monthly', 'Monthly subscription. Cancel anytime.', 'true', 'false', 1, 0)

INSERT INTO [EnterpriseSecurity].[BillingCycles]
([Id],[BillingCycleType],[BillingCycleDuration],[Amount],[CurrencyId],[SubscriptionPlanId],[Name],[Description],[AllowTrial],[StartOnlyWithTrial],[TrialDuration],[TrialDurationType])
VALUES(2, 3, 1, 899, 1, 1, 'Yearly', 'Yearly subscription. Cancel anytime.', 'true', 'false', 1, 0)

INSERT INTO [EnterpriseSecurity].[BillingCycles]
([Id],[BillingCycleType],[BillingCycleDuration],[Amount],[CurrencyId],[SubscriptionPlanId],[Name],[Description],[AllowTrial],[StartOnlyWithTrial],[TrialDuration],[TrialDurationType])
VALUES(3, 1, 1, 299, 1, 2, 'Monthly', 'Monthly subscription. Cancel anytime.', 'true', 'false', 1, 0)

INSERT INTO [EnterpriseSecurity].[BillingCycles]
([Id],[BillingCycleType],[BillingCycleDuration],[Amount],[CurrencyId],[SubscriptionPlanId],[Name],[Description],[AllowTrial],[StartOnlyWithTrial],[TrialDuration],[TrialDurationType])
VALUES(4, 3, 1, 1999, 1, 2, 'Yearly', 'Yearly subscription. Cancel anytime.', 'true', 'false', 1, 0)

SET IDENTITY_INSERT [EnterpriseSecurity].[BillingCycles] ON

GO