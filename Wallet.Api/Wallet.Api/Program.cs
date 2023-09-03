using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Wallet.Api.Database;
using Wallet.Api.Database.Repositories;


public static class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContextFactory<WalletDbContext>(
                options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

        /*to handle resiliecy*/
        builder.Services.AddHealthChecks()
                .AddCheck("Service", () =>
                    HealthCheckResult.Healthy("The service is working."), new[] { "service" });

        builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        builder.Services.AddScoped<IWalletsRepository, WalletsRepository>();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
        var app = builder.Build();

        app.UseHealthChecks("/healthcheck", new HealthCheckOptions
        {
            Predicate = reg => reg.Tags.Contains("service"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        //{
        app.UseSwagger();
        app.UseSwaggerUI();
        //}

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var dataContext = scope.ServiceProvider.GetRequiredService<WalletDbContext>();
            dataContext.Database.Migrate();
        }

        app.Run();
    }
}