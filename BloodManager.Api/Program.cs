using Application;
using Application.Queries.Donors.ReadAllDonors;
using BloodManager.Api.Middlewares;
using BloodManager.Infrastructure;
using Microsoft.OpenApi.Models;

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
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc(
                "v1",
                new OpenApiInfo()
                {
                    Contact = new OpenApiContact()
                    {
                        Name = "João",
                        Email = "joaoback47@gmail.com"
                    }
                }
            );
            var xmlFile = Path.Combine(AppContext.BaseDirectory, "BloodManager.Api.xml");
            o.IncludeXmlComments(xmlFile);
        });
        var app = builder.Build();
        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.MapControllers();
        app.UseSwaggerUI();
        app.UseSwagger();
        app.Run();
    }
}