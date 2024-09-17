using Contacts.API.Extensions;
using Contacts.API.Middleware;
using Contacts.Infraestructure;
using Contacts.Application;

var builder = WebApplication.CreateBuilder(args);

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
    DbInitializer.Initialize(serviceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandler>();

app.MapControllers();

app.Run();

