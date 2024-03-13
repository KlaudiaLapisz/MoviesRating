using MoviesRating.Application;
using MoviesRating.Domain;
using MoviesRating.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
