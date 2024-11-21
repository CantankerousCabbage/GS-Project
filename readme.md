
## Dependencies

### Annotations extension for minimal APIs

```shell
    dotnet add package MinimalApis.Extensions --version 0.11.0
```

### Database package
```shell
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 9.0.0
```
OR

Can use other database such as SQLserver
```shell
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.0
```

### Dotnet-ef
Manages migration, scaffolds database and inspects EF core configuration via CLI commands

```shell
    dotnet tool install --global dotnet-ef --version 9.0.0
```

### Design
Used to generate entity framework migrations

```shell
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
```

### Generating migrations

```shell
    dotnet ef migrations add <migration name> --output-dir Data/Migrations
```

Prefix numbers are time stamp related

### Execute Migration

Auto create a migrations table to track migrations

```shell
    dotnet ef database update
```