// ==============================
//        NAMESPACE IMPORTS
// ==============================
// Import required namespaces for ASP.NET Core application
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// ==============================
//  APPLICATION CONFIGURATION
// ==============================
// Create a WebApplicationBuilder object
// This sets up the application configuration, logging, and dependency injection container
var builder = WebApplication.CreateBuilder(args);

// ==============================
//      SERVICES CONFIGURATION
// ==============================
// Add services to the container. These services are injected as dependencies throughout the app.

// Enable Endpoint API Explorer for Swagger documentation
builder.Services.AddEndpointsApiExplorer();

// Register Swagger for API documentation generation
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(options =>
{
    // Configure Swagger options
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Provider Member Portal API",
        Version = "v1",
        Description = "API Documentation for Provider Member Portal",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Support Team",
            Email = "support@example.com"
        }
    });
});

// Register Controllers for API routing
// This is required for attribute-based routing using [HttpGet], [HttpPost], etc.
builder.Services.AddControllers();


// ==============================
//      BUILD THE APPLICATION
// ==============================
// The builder is now ready to build the application
// The app object represents the web application itself
var app = builder.Build();


// ==============================
//   MIDDLEWARE CONFIGURATION
// ==============================
// Configure the HTTP request pipeline.
// This middleware order is important for request processing and response generation.

// Enable Swagger in Development Environment
if (app.Environment.IsDevelopment())
{
    // Generate and serve Swagger documentation
    app.UseSwagger();

    // Serve Swagger UI at the application's root URL
    // Swagger JSON will be available at /swagger/v1/swagger.json
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Provider Member Portal API v1");
        options.RoutePrefix = string.Empty; // Makes Swagger UI available at https://localhost:7068
    });
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable routing for controllers
// This scans and registers all controllers with attribute routing
app.UseRouting();

// Register route handlers for API controllers
// Ensures all endpoints with attribute routing are mapped correctly
app.MapControllers();


// ==============================
//      SIMPLE API ENDPOINT
// ==============================
// Sample WeatherForecast Endpoint using Minimal API approach
// This demonstrates how to use Minimal APIs for quick and simple endpoints

// Define an array of weather summaries
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// Map a GET endpoint for "/weatherforecast"
// This uses a Minimal API pattern for demonstration purposes
app.MapGet("/weatherforecast", () =>
{
    // Generate a list of random weather forecasts
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)), // Forecast date
            Random.Shared.Next(-20, 55),                       // Random temperature
            summaries[Random.Shared.Next(summaries.Length)]    // Random weather summary
        ))
        .ToArray();

    // Return the generated weather forecasts as JSON
    return forecast;
})
// Set the name of the endpoint
.WithName("GetWeatherForecast")
// Include this endpoint in the generated Swagger documentation
.WithOpenApi();


// ==============================
//          RUN THE APP
// ==============================
// Start the web application and listen for incoming HTTP requests
// The app will listen on ports specified in launchSettings.json
app.Run();


// ==============================
//      RECORD DEFINITION
// ==============================
// Record type for WeatherForecast
// Records are immutable reference types with built-in value equality

// Define a record to represent the WeatherForecast model
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    // Calculated property for Fahrenheit temperature
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
