using GoalsetterChallenge.AppCore.Services;
using GoalsetterChallenge.Domain.Abstract;
using GoalsetterChallenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GoalsetterChallenge;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<RentalDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!));

        builder.Services.AddTransient<IVehicleService, VehicleService>();
        builder.Services.AddTransient<IClientService, ClientService>();

        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options => 
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "RentalAPI", Version = "v1" }));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
