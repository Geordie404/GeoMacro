Geos Macros

migrate DB and scaffolding
- dotnet ef migrations add MigrationName --context Context
- dotnet ef database update
- dotnet aspnet-codegenerator controller --model Macros --dataContext Context --controllerName MacrosController   -relativeFolderPath Controllers --useDefaultLayout -f

to run:
-   dotnet run