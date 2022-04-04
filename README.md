# Welcome to Pokedex

This is Pokedex fun application. Where we are providing some pokemon API to get pokemon details by passing name of pokemon.

-----------------------------------
-----------------------------------

# How to build and run project and test cases


## Requirements

The project requires [.NET 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/5.0).

## Compatible IDEs

Tested on:

- Visual Studio 2019

## Useful commands

From the terminal/shell/command line tool, use the following commands to build, test and run the API.

### Build the project - 

```console
$ dotnet build
```

```This command must be used in Pokedex project where we have Pokedex c# project file```


### Run the tests

````Visual Studio 2019 - Test Explorer or select project and Run Tests
````

```console
$ dotnet test Pokedex.Tests
```

### Run the application

Run the application which will be listening on port `5000`.

```console
$ dotnet run Pokedex

This command must be used in Pokedex project where we have Pokedex c# project file

````

-----------------------------------
-----------------------------------

# Avaialble API with payload
Use postman or IE browser to test API

### First Http GET Api to get Pokemon basic Information
Url - http://localhost:5000/pokemon/mewtwo 
```where mewtwo is Pokemon Name```

### Second Http GET Api to get Pokemon basic Information with Fun Translation
Url - http://localhost:5000/pokemon/translated/mewtwo
```where mewtwo is Pokemon Name and there are 2 fun translation present - Yoda and Shakespeare based on conditions```

-----------------------------------
-----------------------------------

# Build and Run with Docker - WSL Docker with Ubuntu or Linux

For Docker Build & Run there are 2 files present docker_build_sh and docker_run_local.sh

Go to Path and run these files with linux CLI or copy command from these files and directly run on CLI.

-----------------------------------
-----------------------------------

# Production Settings needs to be done 

In appsettings.json file - Need to update property - It can be done with docker file or by Jenkins or other CI-CD
Current "ApplicationEnvironment": "Local" --> to --> "ApplicationEnvironment": "Production"

and Update URL for production API in this file

## What else i would do differently for production API or what tasks are in pipline

1) Authorization and Token Based Authentication.
2) Rate limit based on Users, currently used IP rate limit of 50.
3) Versioning of API.
4) Implement CORS.
5) Proper Async implementation.