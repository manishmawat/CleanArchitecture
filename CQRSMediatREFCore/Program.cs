using CQRSMediatREFCore.Data;
using CQRSMediatREFCore.Data.Repository;
using CQRSMediatREFCore.Data.SeedData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//builder.Services.AddDbContext<TrailInMemoryDbContext>(opt => opt.UseInMemoryDatabase("Trails"));
builder.Services.AddDbContext<TrailDbContext>(opt=>opt.UseSqlite($"Data Source = Trails.db"));

//builder.Services.AddSingleton<ITrailRepository,FakeTrailDataStore>();
builder.Services.AddTransient<ITrailRepository,TrailRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //data base seed
    app.UseItToSeedSqliteDb();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
