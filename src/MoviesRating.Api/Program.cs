using Microsoft.EntityFrameworkCore;
using MoviesRating.Api.DAL;
using MoviesRating.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["sqllServer:connectionString"];
builder.Services.AddDbContext<MoviesRatingDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
