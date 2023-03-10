using CoffeeShopMicro.Barista.Core;
using CoffeeShopMicro.Barista.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CoffeeShopMicro.Barista.Domain.Repositories;
using CoffeeShopMicro.Barista.Data.Repositories;
using CoffeeShopMicro.Tools.Extentions;
using FluentValidation;
using CoffeeShopMicro.Barista.Core.Commands;
using CoffeeShopMicro.Barista.Core.Validators;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AddServices(builder);

        var app = builder.Build();

        ConfigureRequestPipeline(app);

        //MigrationManager.MigrateDatabase(app);

        app.Run();
    }
    private static void AddServices(WebApplicationBuilder builder)
    {
        var connstr = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                 builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception(),
                 x => x.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name)));

        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddMediatR();
        builder.Services.AddHateoas();
        builder.Services.AddScoped<IValidator<HireBarista>, HireBaristaValidator>();
        builder.Services.AddTransient<IBaristaRepository, BaristaRepository>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
    private static void ConfigureRequestPipeline(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        //app.MigrateDatabase();

    }

}
   
public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                try
                {
                    if (!appContext.Baristas.Any())
                    {
                        appContext.Database.Migrate();
                    }

                }
                catch (Exception ex)
                {
                    //Log errors or do anything you think it's needed
                    throw;
                }
            }
        }
        return webApp;
    }
}
