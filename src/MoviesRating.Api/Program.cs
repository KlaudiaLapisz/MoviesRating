using Microsoft.EntityFrameworkCore;
using MoviesRating.Api.DAL;
using MoviesRating.Api.Repositories;
using MoviesRating.Api.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["sqllServer:connectionString"];
builder.Services.AddDbContext<MoviesRatingDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IDirectorService, DirectorService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
