using Microsoft.EntityFrameworkCore;
using MoviesRating.Api.DAL;
using MoviesRating.Api.Repositories;
using MoviesRating.Application;
using MoviesRating.Domain;
using MoviesRating.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["sqlServer:connectionString"];
builder.Services.AddDbContext<MoviesRatingDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
