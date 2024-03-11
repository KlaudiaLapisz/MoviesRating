using Microsoft.EntityFrameworkCore;
using MoviesRating.Api.DAL;
using MoviesRating.Api.Repositories;
using MoviesRating.Api.Services;
using MoviesRating.Domain;
using MoviesRating.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["sqlServer:connectionString"];
builder.Services.AddDbContext<MoviesRatingDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IDirectorService, DirectorService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddDomain();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
