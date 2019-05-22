# DevAccelerate for .NET

**DevAccelerate for .NET** is a comprehensive and well-designed development accelerator for Microsoft .NET Framework. It is free and open source. It contains common components and functionalities that allow developers to build real-world .NET apps rapidly. It is broken up into individual modules and therefore allows developers to use only what is needed. The usage of the framework is governed by the terms and conditions of its [License](https://github.com/devaccelerate/DevAccelerateNet/blob/master/LICENSE).

### NuGet Packages

DevAccelerate is broken down into modules and each module has one ore more NuGet package. A DevAccelerate NuGet package automatically installs required dependencies.

The following is the list of DevAccelerate NuGet packages:
* [DevAccelerateCore](https://www.nuget.org/packages/DevAccelerateCore)
* [DevAccelerateCoreEF](https://www.nuget.org/packages/DevAccelerateCoreEF)
* [DevAccelerateCoreExceptionHandlingMsel](https://www.nuget.org/packages/DevAccelerateCoreExceptionHandlingMsel)
* [DevAccelerateCoreLoggingMsel](https://www.nuget.org/packages/DevAccelerateCoreLoggingMsel)
* [DevAccelerateLists](https://www.nuget.org/packages/DevAccelerateLists/)
* [DevAccelerateListsEF](https://www.nuget.org/packages/DevAccelerateListsEF/)
* [DevAccelerateIdentity](https://www.nuget.org/packages/DevAccelerateIdentity/)
* [DevAccelerateIdentityEF](https://www.nuget.org/packages/DevAccelerateIdentityEF/)
* [DevAccelerateEnterpriseSecurity](https://www.nuget.org/packages/DevAccelerateEnterpriseSecurity/)
* [DevAccelerateEnterpriseSecurityEF](https://www.nuget.org/packages/DevAccelerateEnterpriseSecurityEF/)
* [DevAccelerateSecurityFacade](https://www.nuget.org/packages/DevAccelerateSecurityFacade/)
* [DevAccelerateMail](https://www.nuget.org/packages/DevAccelerateMail/)
* [DevAccelerateMailSendGrid](https://www.nuget.org/packages/DevAccelerateMailSendGrid/)
* [DevAccelerateSms](https://www.nuget.org/packages/DevAccelerateSms/)
* [DevAccelerateSmsTextlocal](https://www.nuget.org/packages/DevAccelerateSmsTextlocal/)
* [DevAccelerateSmsTwilio](https://www.nuget.org/packages/DevAccelerateSmsTwilio/)

### Installation

The best way to install DevAccelerate libraries in your .NET project is through NuGet's **Install-Package** command. For example, if you want to install **DevAccelerateCoreEF** library:
```
Install-Package DevAccelerateCoreEF 
```

You can also install a specific version of a DevAccelerate NuGet package with the **-Version** option. The following is an example of installing specific version **v6.0.0 Preview 2** of **DevAccelerateCoreEF**:
```
Install-Package DevAccelerateCoreEF -Version 6.0.0-preview2
```

If you need all or most of the DevAccelerate libraries in your .NET project, **DevAccelerateAll** can be very handy. It is a metapackage that installs all the DevAccelerate libraries:
```
Install-Package DevAccelerateAll
```

**Note:** You always need to install only top-level NuGet package. Dependencies, whether DevAccelerate libraries or any other, would automatically get installed.

### Issues

If you find a bug in the library or you have an idea about a new feature, please try to search in the existing list of [issues](https://github.com/devaccelerate/DevAccelerateNet/issues). If the bug or idea is not listed and addressed there, please [open a new issue](https://github.com/devaccelerate/DevAccelerateNet/issues/new).
