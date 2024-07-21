using deportesApi.models;
using deportesApi.Repositories;
using deportesApi.Repositories.Impl;
using deportesApi.Services;
using deportesApi.Services.Impl;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<db_aa579f_prog3w1Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbParcial")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ISocioService, SocioService>();
builder.Services.AddScoped<IDeporteRepository, DeporteRepositoryImpl>();
builder.Services.AddScoped<ISocioRepository, SocioRepositoryImpl>();
builder.Services.AddFluentValidation((options) =>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
