# Mirabeau
Mirabeau technical test

------

Jump to:
  [Used tools and frameworks](#used-tools-and-frameworks) |
  [Cloning this repository](#cloning-this-repository) |
  [Fixed credential to sign-in to the website](#fixed-credential-to-sign-in-to-the-website) |
  [About the architecture](#about-the-architecture)
  
------

### Used tools and frameworks
- [Visual Studio 2017](https://visualstudio.microsoft.com/)
- [Font-Awesome Free 5.0.13](https://fontawesome.com/)
- [jQuery 1.10.2](https://jquery.com/)
- [Bootstrap v4.1.1](https://getbootstrap.com/)
- [Simple Injector](https://simpleinjector.org/)
- [AutoMapper](https://automapper.org/)

------

## Cloning this repository

URL to clone this repository.
```shell
git clone https://github.com/mlcalache/Mirabeau.git
```
-----

## Fixed credential to sign-in to the website

Username:
```shell
admin
```
Password:
```shell
123
```
-----

## About the architecture

This website was developed using a simple version of the Domain-Driven-Design (DDD) architecture.

The .NET solution is composed of 5 tiers: Presentation, Distributed Services, Application, Domain, and Infra.

The Presentation tier is composed of the Mirabeau.UI.MVC project. This Mirabeau.UI.MVC project is responsible for present an user interface (UI). It is developed using MVC 5 from .NET Framework, besides other frameworks, such as jQuery, Bootstrap, among others.

The Distributed Services tier is composed of the Mirabeau.API .NET project and is responsible for exposing functonalities to the web, using RESTful web services developed using Web.API from .NET Framework.

The Application tier is responsible for orchestrating the access to the low level tiers of the DDD architecture, shielding the access to the Domain tier. This Application tier is composed of the Mirabeau.Application .NET class library project.

The Domain tier is composed of the Mirabeau.Domain .NET class library project. This tier is responsible for maintaining the domain entities classes and the interfaces. The former are used as the models of the system and would be applied to develop a database (if it were applied in this project). The latter are used to dictate the actions of the system. The services developed in the Application tier follow rules defined in these interfaces from the Domain tier. If a repository were used to persist information in a database, this repository would implement an interface developed in the Domain tier as well.

The last tier, the Infra tier, is composed of three .NET projects:

The Mirabeau.Infra.Service.AirportList .NET class library project is responsible for communicating with the external service to get the Airports (JSON). It uses interfaces defined in the Domain tier as well. It should be easy to develop another service getting from a different source (other than this initial JSON url).

The Mirabeau.Infra.CrossCutting.Helpers .NET class library project is responsible for maintaining supporting functionalities to all other projects in all other tiers. It is part of the Cross Cutting concept from the DDD.

The last project is the Mirabeau.Infra.CrossCutting.IoC .NET class library project. This one is responsible for inject dependecies in all classes from all projects from all tiers that require instances from other classes. It applies the concept of Inversion of Control and Depency Injection. This project uses the framework SimpleInjector to control the Dependency Injection.


-----

