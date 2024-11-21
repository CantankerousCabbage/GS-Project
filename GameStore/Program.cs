using GameStore.Data;
using GameStore.DTOs;
using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Use iconfiguration framework to access connection string stored in appSettings
var connectionString = builder.Configuration.GetConnectionString("GameStore");

// Inject database service dependency.AddSQLlite is an aggregate function.
// One thing it includes is specifying scoped lifetime for the dependency to prevent concurrency.
builder.Services.AddSqlite<GameStoreContext>(connectionString);

// can configure services using builder.
var app = builder.Build();

//Make endpoints available
app.MapGamesEndpoints();
app.MapGenresEndpoints();

// Will migrate and populate database on run
await app.MigrateDBAsync();

app.Run();
