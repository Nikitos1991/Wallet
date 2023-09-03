using Microsoft.EntityFrameworkCore;
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


        builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        builder.Services.AddScoped<IWalletsRepository, WalletsRepository>();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        //{
        app.UseSwagger();
        app.UseSwaggerUI();
        //}

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}