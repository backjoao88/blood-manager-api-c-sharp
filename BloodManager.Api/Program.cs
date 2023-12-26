using Application;
using Application.Queries.Donor.ReadAllDonors;
using BloodManager.Infrastructure;

namespace BloodManager.Api;

public abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddBkMediator(typeof(ReadAllDonorsQuery).Assembly);
        builder.Services.AddPersistence();
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}