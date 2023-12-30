using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Exceptions;
using BloodManager.Api.Abstractions;
using Core.Primitives;
using Microsoft.AspNetCore.Http.Json;

namespace BloodManager.Api.Middlewares;

/// <summary>
/// Represents a middleware responsible for handling global exceptions
/// </summary>
public class GlobalExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomValidationException customValidationException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            var apiErrorResponse = new ApiErrorResponse(customValidationException.Errors);
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(apiErrorResponse, options);
            await context.Response.WriteAsync(json);
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var apiErrorResponse = new ApiErrorResponse(new[] { new Error("Server.UnknownError", exception.Message)});
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(apiErrorResponse, options);
            await context.Response.WriteAsync(json);
        }
    }
}