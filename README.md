# DevAccelerate for .NET

**DevAccelerate for .NET** is a comprehensive and well-designed development accelerator for Microsoft .NET Framework. It is free and open source. It contains common components and functionalities that allow developers to build real-world .NET apps rapidly. It is broken up into individual modules and therefore allows developers to use only what is needed. The usage of the framework is governed by the terms and conditions of its [License](https://github.com/devaccelerate/DevAccelerateNet/blob/master/LICENSE).

## Latest Changes
The code base has been updated in a significant way to provide better and more optimised functionality. The following are the highlights:
* The current code base is now fully migrated to .NET 6 (latest .NET version) and it includes the support for .NET 5 and .NET Core 3.1. The support for .NET Framework has been discontinued.
* Support for Microsoft Enterprise Library (MSEL) has been removed. The development of MSEL was discontinued by Microsoft long time ago and therefore it was reasonable to discontinue its inclusion in DevAccelerate.
* The use of application configurations (app.config / web.config) in DevAccelerate libraries has been discontinued. This has been replaced with the IOptions pattern.

## Modules

DevAccelerate for .NET is broken down into modules and each module has one or more NuGet package. A DevAccelerate NuGet package automatically installs required dependencies.

The following is the list of DevAccelerate modules with corresponding NuGet packages:
#### Core
* [DevAccelerateCore](https://www.nuget.org/packages/DevAccelerateCore)
* [DevAccelerateCoreEF](https://www.nuget.org/packages/DevAccelerateCoreEF)
#### Lists
* [DevAccelerateLists](https://www.nuget.org/packages/DevAccelerateLists/)
* [DevAccelerateListsEF](https://www.nuget.org/packages/DevAccelerateListsEF/)
#### Identity
* [DevAccelerateIdentity](https://www.nuget.org/packages/DevAccelerateIdentity/)
* [DevAccelerateIdentityEF](https://www.nuget.org/packages/DevAccelerateIdentityEF/)
#### Profiles
* [DevAccelerateProfiles](https://www.nuget.org/packages/DevAccelerateProfiles/)
* [DevAccelerateProfilesEF](https://www.nuget.org/packages/DevAccelerateProfilesEF/)
#### Enterprise Security
* [DevAccelerateEnterpriseSecurity](https://www.nuget.org/packages/DevAccelerateEnterpriseSecurity/)
* [DevAccelerateEnterpriseSecurityEF](https://www.nuget.org/packages/DevAccelerateEnterpriseSecurityEF/)
#### Mail and SMS
* [DevAccelerateMail](https://www.nuget.org/packages/DevAccelerateMail/)
* [DevAccelerateMailSendGrid](https://www.nuget.org/packages/DevAccelerateMailSendGrid/)
* [DevAccelerateSms](https://www.nuget.org/packages/DevAccelerateSms/)
* [DevAccelerateSmsTextlocal](https://www.nuget.org/packages/DevAccelerateSmsTextlocal/)
* [DevAccelerateSmsTwilio](https://www.nuget.org/packages/DevAccelerateSmsTwilio/)
#### Facades
* [DevAccelerateSecurityFacade](https://www.nuget.org/packages/DevAccelerateSecurityFacade/)

## Getting Started
### Installation

The best way to install DevAccelerate libraries in your .NET project is through NuGet's **Install-Package** command. For example, if you want to install **DevAccelerateCoreEF** library:
```
Install-Package DevAccelerateCoreEF 
```

You can also install a specific version of a DevAccelerate NuGet package with the **-Version** option. The following is an example of installing specific version **v6.0.0** of **DevAccelerateCoreEF**:
```
Install-Package DevAccelerateCoreEF -Version 6.0.0
```
**Note:** You always need to install only top-level NuGet package. Dependencies, whether DevAccelerate libraries or any other, would automatically get installed.

## Issues

If you find a bug in the library or you have an idea about a new feature, please try to search in the existing list of [issues](https://github.com/devaccelerate/DevAccelerateNet/issues). If the bug or idea is not listed and addressed there, please [open a new issue](https://github.com/devaccelerate/DevAccelerateNet/issues/new).
