# recife-expenses-visualization
A web application to read and present data about Recife's expenses

## Features

The web app displays the Recife's expense data as table and chart: 

- Total expenses grouped by month.
- Total expenses grouped by category.
- Total expenses grouped by source.

## Instructions

Download and install .NET Core Runtime if necessary:

- .NET Core 3.1 download : https://dotnet.microsoft.com/download/dotnet-core/current/runtime.

Using Microsoft Visual Studio:

- Open Microsoft Visual Studio.
- Open the solution file (`recife-expenses-visualization.sln`) to load all the project files.
- To run the application, navigate to `Debug` -> `Start Without Debugging` or type `CTRL + F5`.

Using Visual Studio Code:

- Open Visual Studio Code.
- Click on `Open folder...` on the Welcome screen or navigate to `File` -> `Open folder...`.
- Select the root folder of the application to load all the project files.
- Select `Yes` when prompted to add required assets to build and debug.
- Select the `Web` project when prompted to select the project to launch.
- To run the application, navigate to `Debug` -> `Start Without Debugging` or type `CTRL + F5`.

## Important files

- `Core.Entities.Expense` represents a single expense.
- `Core.Response.ExpenseSearchResponseData` represents the data that comes from the API, used for serialization purposes.
- `Core.Services.ApiResourceService` contains code to make and process requests.
- `Core.Services.ExpenseService` contains methods to load the expense data from the API.
- `Web.Controllers.ExpenseController` handles requests from the user to load the views.
- `js/site.js` contains javascript code responsible for load async data (to show table and chart views).
