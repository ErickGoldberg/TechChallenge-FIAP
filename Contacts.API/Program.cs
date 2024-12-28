using Contacts.API.Extensions;
using Contacts.API.Middleware;
using Contacts.Infraestructure;
using Contacts.Application;
using OpenTelemetry.Metrics;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry()
    .WithMetrics(builder =>
    {
        builder.AddPrometheusExporter();
        builder.AddMeter("Microsoft.AspNetCore.Hosting",
            "Microsoft.AspNetCore.Server.Kestrel");
        builder.AddView("http.server.request.duration",
            new ExplicitBucketHistogramConfiguration
            {
                Boundaries = new double[] { 0, 0.005, 0.01, 0.025, 0.05,
                      0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 }
            });
    });


builder.Services.AddSingleton<GlobalExceptionHandler>();

// Add services to the container.
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

builder.ConfigureServices();



var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var serviceProvider = serviceScope.ServiceProvider;
    await DbInitializer.InitializeAsync(serviceProvider);
}

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandler>();

app.MapPrometheusScrapingEndpoint();


app.MapControllers();

app.Run();

