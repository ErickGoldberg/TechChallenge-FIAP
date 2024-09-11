using Contacts.API.Extensions;
using Contacts.API.Middleware;
using Contacts.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureServices();
builder.Services.AddInfrastructure(builder.Configuration);

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
