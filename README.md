# PersonalWebsite-AspNetCore
Small project for CITB537 course in New Bulgarian University. The website is a user-friendly representation of a typical resume parts. 

It consists of many pages, most notable of which are:
* **Home/CV** - people can view general CV like information for the owner. Admins have functionality to update/delete components of the page.
* **Gallery** - page containing photos that the owner would like to share. Admins have functionality to add new pictures and delete old ones.
* **Comments** - page where logged in users can leave comments. Admins have functionality to edit or delete inappropriate comments.
* **Users** - admin only page used for user-management.

There are also pages for privacy policy, about information, user profile page, login, registration and several others.


## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

In order to be sure you can run the project, make sure you have the following frameworks installed on your PC:
* **NET Standard 2.0 compatible frameworks** - **NET Core 3.1** & **NET Framework 4.6.1** (should be installed with VisualStudio/Rider, double check it just in case)
* **SQL Server 2019** - the project is built and tested on EF 3.1.10 which, is using latest SQL Server version

It's good to have the following software products installed in order to be sure the project is running as expected:
* **VisualStudio 2019 / Rider 2020** - built and tested on both of those IDEs, the project should also be running on any newer version as long as it supports the above mentioned frameworks
* **SQL Server Management Studio (SSMS) / Azure Data Studio** - This one is not required at all, but if you want to check what happens in the database, it's good to have it. It's recommended to use latest version, the project has been tested on SSMS 2018 & Azure Data Studio 2020 and it's working fine.

### Installation

If you want to have **custom database name**, go to [appsettings.json](PersonalWebsite/appsettings.json) file and change **_THAT__** to whatever name you would like:
```
"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=THAT_;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

Before initially running the project, go to [PersonalWebsite](PersonalWebsite) folder (the one containing PersonalWebsite.csproj file) and execute the following commands:

```
dotnet ef migrations add initialCreate
```
```
dotnet ef database update 
```
Those commands are required in order for the project to correctly build the database before running it.


## Built With

* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1) - The web framework 
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/) - The ORM framework 
* [Bootstrap](https://getbootstrap.com) - Front-end kit used for better styling
* [jQuery & AJAX](https://api.jquery.com/jquery.ajax/) - jQuery is used in several places for adding transitions, animations and so on. It's used together with VanillaJS. Also AJAX via jQuery is used for the votes functionality in the Comments page


## Contribution

* **Ilian Ganchosov** - *One man army / project creator* - [Plotso](https://github.com/Plotso)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details