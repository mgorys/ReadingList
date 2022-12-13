# ReadingList

ReadingList is an application, on which you can make your list of books, you want to store.
That list can be reorganized by changing its place in line or mark if it has been read.

## Installation

1.Change your connection string in appsettings.json

```bash
"ConnectionStrings": {
    "ReadingListConnectionString": "Server=.;Database=ReadingListDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
```

2. Initiate database

![update-database](update-database.png)

Run `update-database` command in Package Manager Console in Persistance project

## CORS Policy

Be sure your port is proper with origins rules placed in `Program.cs`.

```bash
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:3000", "http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
```

## Architecture

This is a web application, which uses Model-View-Controller (MVC) design patter.

Model part is supported by repository-service pattern, which contains businness logic with operations that should be performed by it.

Repository-Service pattern divides the business layer into two semi-layers. Repository handles getting data into and out of database.

Service is responsible for operations on data and passing them between repository and controller.

## Patterns/Technologies:

- ASP.NET Core
- Entity Framework
- Repository Pattern
- Fluent Validation
- AutoMapper

# Client

User interface is created with usage of React, a JavaScript library.

Client sends requests on port: 7138 by default. You should check if it is proper path for your needs.

`const urlServer = 'https://localhost:7138/api/';`

## Instalation

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.\
You will also see any lint errors in the console.

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

## About

Solbeg 4th Task
