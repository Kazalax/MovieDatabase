
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Movies.Api;
using Movies.Api.Interfaces;
using Movies.Api.Managers;
using Movies.Data;
using Movies.Data.Interfaces;
using Movies.Data.Repositories;
;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalMoviesConnection");

builder.Services.AddDbContext<MoviesDbContext>(options =>
    options.UseSqlServer(connectionString)
        .UseLazyLoadingProxies()
        .ConfigureWarnings(x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)));

builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("movies", new OpenApiInfo
    {
        Version = "v1",
        Title = "Filmová databáze",
        Description = "Webové API pro filmovou databázi vytvoøené pomocí technologie ASP.NET.",
        Contact = new OpenApiContact
        {
            Name = "Kontakt",
            Url = new Uri("https://www.bedrichmaly.cz/")
        }
    }));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IPersonManager, PersonManager>();
builder.Services.AddScoped<IGenreManager, GenreManager>();
builder.Services.AddScoped<IMovieManager, MovieManager>();
builder.Services.AddAutoMapper(typeof(AutomapperConfigurationProfile));
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/movies/swagger.json", "Filmová databáze - v1");
    });
}

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
