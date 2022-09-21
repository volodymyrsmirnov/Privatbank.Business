# Privatbank API AutoClient

![Privatbank.Business](https://github.com/mindcollapse/Privatbank.Business/workflows/Privatbank.Business/badge.svg)

This library allows you to quickly and easily use the Privatbank AutoClient API for obtaining balance sheets, transactions and creating outgoing payments for the corporate users (legal entities and entrepreneurs).

For now, this library does not have a functionality to querying exchange rates, working with digital documents and e-statements. Feel free to send PRs or raise an issue if you need them.


**see [changelog.md](./Privatbank.Business/CHANGELOG.md)**
---
## Installation 

### Prerequisites

* .NET Framework 4.6.1+
* .NET Core 3.0+
* .NET Standard 2.0+
* Privatbank AutoClient API client id and token.

### Obtaining an API id and token

For working with API, you need an account in https://otp24.privatbank.ua/v2/

Check [official documentation from Privatbank](https://docs.google.com/document/d/e/2PACX-1vTtKvGa3P4E-lDqLg3bHRF6Wi9S7GIjSMFEFxII5qQZBGxuTXs25hQNiUU1hMZQhOyx6BNvIZ1bVKSr/pub) (Ukrainian) 
for instructions on how to enable AutoClient and generate client id and token.

### Install Package

```cmd
dotnet add package Privatbank.Business
```

### Dependencies

Please see the [.csproj file](Privatbank.Business/Privatbank.Business.csproj).

## Documentation

Please see documentation string in [PrivatBankAutoClient.cs](Privatbank.Business/PrivatbankAutoClient.cs), [Privatbank.Business.Data.Models](Privatbank.Business/Data/Models) and [Privatbank.Business.Exceptions](Privatbank.Business/Exceptions) namespaces.

You can also check [tests](Privatbank.Business.Tests/PrivatBankAutoClient.cs) for basic usage examples.