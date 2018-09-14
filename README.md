# WalmartStore


The Walmart client application is developed using asp.net core; with supporting class libraries to make components loosly coupled and to ensure separation of concern.

**AES.Domains:** This defines the two domain classes which are one for walmart open api and the other for walmartstore client application.

**AES.Data:** This is the data access layer to abstract the walmart open api web service with Repository pattern.

**AES.Service:** This is the service layer to get data from the data access layer and map the data to walmartstore client domain.

**AES.Data.Tests and AES.Service.Tests:** These are the test projects which use MSTest with moq framework to mock Repository dependencies.  

**WalmartStore:** This is the client application which is built using asp.net core and javascript. The .net core part renders the first landing page and also acts as a web service to serve the ajax requests coming from the client application.  


To test the test projects from a command line, use the below command as an example

  **vstest.console.exe bin/debug/aes.data.tests.dll**
  
To run the walmartstore client from a command line, use

  **dotnet run --project walmartstore.csproj**

**Note:** when running this commands, make sure your under the corresponding current directory.

To see a running application, click here http://walmartstore.azurewebsites.net/
