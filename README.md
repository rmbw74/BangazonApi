# BangazonApi
Bangazon API Sprint for the Stormy Hares

## External Tools used with this API
This api uses the SWAGGER api development tool
please see https://swagger.io/swagger-ui/ for information

## Installing the Bangazon Api
1. start by cloning the repo to the machine that will be running the webapi
1. use the green clone/download button on the github repo
1. copy the link provided.
1. on the local machine, create the folder that you wish the api to reside
1. navigate into that folder and then use the command "Git Clone" followed by the
    url that you copied in step 3.
1. once the repo has been copied down you are ready to start.
1. navigate to the root folder of the project, and type dotnet restore into the terminal

## Setting up your environment variables
1. add the following environemnt variable to your shell script


## creating the database
The banagazon api by default will create a seeded database with test information. If you wish to start with a completely empty database you must follow these steps. If you want to start with the default seeded database, skip to step 4
1. open the program.cs file
1. comment out all code between the "SEED" and "END SEED" comments
1. save your changes to program.cs
1. from the terminal type "dotnet ef database update"
1. the BangazonApi.db file should now


