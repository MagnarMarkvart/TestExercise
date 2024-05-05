# Helmes Test - Helpers

## Entity Framework

### NuGet Packages (DAL)
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore
* etc.


### Migrations (Done from code)
~~~bash
dotnet tool update --global dotnet-ef

dotnet ef migrations add --project App.DAL.EF --startup-project WebApp Initial
dotnet ef database update --project App.DAL.EF --startup-project WebApp 

dotnet ef database drop --project App.DAL.EF --startup-project WebApp
~~~

## MVC Web Controllers / API Controllers

### NuGet Packages (WebApp Project)
* Microsoft.VisualStudio.Web.CodeGeneration.Design
* Microsoft.EntityFrameworkCore.SqlServer
* etc.

### Code Generation
~~~bash
dotnet tool update --global dotnet-aspnet-codegenerator
cd WebApp

# MVC
dotnet aspnet-codegenerator controller -name SectorsController -actions -m App.Domain.Sector -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UserInSectorsController -actions -m App.Domain.UserInSector -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
# MVC in Areas
dotnet aspnet-codegenerator area Admin
dotnet aspnet-codegenerator controller -name SectorsController -actions -m App.Domain.Sector -dc AppDbContext -outDir Areas/Admin/Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UserInSectorsController -actions -m App.Domain.UserInSector -dc AppDbContext -outDir Areas/Admin/Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
# API
dotnet aspnet-codegenerator controller -name SectorsController -m App.Domain.Sector -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
# Identity
dotnet aspnet-codegenerator identity --userClass=App.Domain.Identity.AppUser -f
~~~