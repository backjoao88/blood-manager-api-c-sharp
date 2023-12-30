using Application;
using Application.Queries.Donors.ReadAllDonors;
using BloodManager.Api.Middlewares;
using BloodManager.Infrastructure;

namespace BloodManager.Api;

public abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<GlobalExceptionMiddleware>();
        builder.Services.AddFluentValidation();
        builder.Services.AddBkMediator(typeof(ReadAllDonorsQuery).Assembly);
        builder.Services.AddPersistence();
        builder.Services.AddControllers();
        var app = builder.Build();
        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.MapControllers();
        app.Run();
    }
}