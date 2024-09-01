using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using polyglot_dotnet.Data;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;
builder.Services.AddDbContext<DbConn>(options => 
options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
x=>x.MigrationsHistoryTable("_EfMigrations",Configuration.GetSection("Schema").GetSection("DataSchema").Value)));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
