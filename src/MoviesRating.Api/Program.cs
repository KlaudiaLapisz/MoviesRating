using MoviesRating.Application;
using MoviesRating.Application.Commands;
using MoviesRating.Domain;
using MoviesRating.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo
        .Console()
        .WriteTo
        .File("logs.txt");
});

var app = builder.Build();
app.UseInfrastructure();
app.MapControllers();
app.Run();
