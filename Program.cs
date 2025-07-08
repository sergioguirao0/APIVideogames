using APIVideogames.Data;
using APIVideogames.Model.Repositories;
using APIVideogames.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<IPlatformRepository, PlatformService>();
builder.Services.AddTransient<IVideogameRepository, VideogamesService>();

var app = builder.Build();

app.MapControllers();

app.Run();
