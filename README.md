# Random Text Generator API

## About
A .NET Core  Web.API (C#) that generates a random text and return it in JSON format. The random text is obtained from Wikipedia summay section by hitting their URL: https://en.wikipedia.org/api/rest_v1/page/random/summary 

Request:
/TextGenerator (GET)

Sample Response:
{"content":"Belona is an unincorporated community in Powhatan County, in the U.S. state of Virginia."}

## To run locally
1. Clone or download the source code
2. Open WebApplication.sln with Visual Studio
3. Build Solution
4. Start IIS Express
