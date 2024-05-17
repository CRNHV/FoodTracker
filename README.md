# Foodtracker
A Blazor wasm app to track dutch food consumption.

## Motivation
This is a project inspired by apps like `MyFitnessPal` and `Lose it!`
The blazor web app provides functionality to log consumed food and view consumed nutrients. It is also able to scan barcodes from most food available in the Dutch supermarkets. 

## Design

As you can see, the repo contains a lot of folders for such small application.
This is because I was experimenting with different project structures and decided to stick with this. I don't think it's an optimal solution for having a modular structure, but it works... for now.

### Software requirements
In order to build and run the application you need the following:
        
    - .NET 8 
    - Visual Studio 2022
    - SQL Server ( Or set the database to something else ) 
    
## Folder overview:
    - FoodTracker.Application
        - Contains the business logic
    - FoodTracker.Contracts
        - Contains all interfaces for the FoodTracker.Application, DataProvider and FoodTracker.Persistence projects.
    - FoodTracker.Data.Domain
        - Contains all interfaces for the Database / DataProvider and Application models
    - FoodTracker.Data.Persistence
        - Contains the interface implementations for the database and contains the database context.
    - FoodTracker.Web.API
        - Contains the WebAPI 
    - FoodTracker.Web.UI
        - Contains the blazor wasm project.
    - ZXingBlazor
        - Contains the blazor component for the barcode scanner, original repo is https://github.com/densen2014/ZXingBlazor

## The provider
This project has been build with an API which isn't public. As such the provider implementation is a private repository.
