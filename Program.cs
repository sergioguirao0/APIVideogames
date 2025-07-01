using APIVideogames.Data;
using APIVideogames.Model.Repositories;
using APIVideogames.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IPlatformRepository, PlatformService>();

var app = builder.Build();

app.MapControllers();

app.Run();
