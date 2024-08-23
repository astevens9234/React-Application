using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddApplicationServices(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline. Any middlewear goes here.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        app.UseCors("CorsPolicy");
        app.UseAuthorization();
        app.MapControllers();

        // Start up the DB
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<DataContext>();
            await context.Database.MigrateAsync();
            await Seed.SeedData(context);
        }
        catch (Exception err)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(err, "Error During Migration.");
        }

        app.Run();
    }
}