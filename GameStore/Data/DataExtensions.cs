using Microsoft.OpenApi.Writers;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public static class DataExtensions
{
    public static async Task MigrateDBAsync(this WebApplication app)
    {
        // Scope use to request instance of service registed to ASP.NET service container
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
    }
}


