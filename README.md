# Azure Functions Test Host

* Azure Functions
  * [MS: Dependency Injection](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection)
  * [MS: Testing Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-test-a-function)
  * [Integration Testing in Azure Functions with Dependency Injection](https://saebamini.com/integration-testing-in-azure-functions-with-dependency-injection/)

# Packages for Azure Functions App

```
Install-Package Microsoft.Azure.Functions.Extensions -Version 1.1.0
Install-Package Microsoft.NET.Sdk.Functions -Version 4.0.1
Install-Package Microsoft.Extensions.DependencyInjection -Version 6.0.0
```

# Packages for Test Project
```
Install-Package xunit -Version 2.4.1
Install-Package xunit.runner.visualstudio -Version 2.4.3
Install-Package coverlet.collector -Version 3.1.2
Install-Package AutoFixture -Version 4.17.0
Install-Package FluentAssertions -Version 6.5.1
Install-Package Microsoft.NET.Test.Sdk -Version 17.1.0


```