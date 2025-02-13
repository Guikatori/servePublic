using Models.CommandInterface;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy => 
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();
app.UseCors("AllowAll");

app.MapGet("/", () => Results.Json(new { applicationStatus = true, statusCode = 200 }));

app.MapPost("/call", (CommandInterface callData) =>
{
    var processUtils = new ProcessUtilities();
    return processUtils.MakeCall(callData);
});

app.Run();