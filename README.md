The code has been written in c# using BDD framework and Playwright

A Visual Studio / Visual Studio/ Rider Code IDE is recommended 

The following packages need to be installed for successful execution

To Generate a Report, install living doc using following command in powershell:    dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

livingdoc test-assembly C:\Work\MyProject.Specs\bin\Debug\netcoreapp3.1\MyProject.Specs.dll -t C:\Work\MyProject.Specs\bin\debug\netcoreapp3.1\TestExecution.json  provide filepath to your local DLL and .json file and the report will be generated
