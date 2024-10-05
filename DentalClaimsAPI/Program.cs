using DentalClaims.Application.DTOs;
using DentalClaims.Application.Interface;
using DentalClaims.Application.Services;
using DentalClaims.Application.Validators;
using DentalClaims.Domain.Interfaces;
using DentalClaims.Infrastructure;
using DentalClaims.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database configuration (alterado para Oracle)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("DentalClaimsAPI")));

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Register Repositories
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

// Register Services
builder.Services.AddScoped<DentalClaims.Application.Interface.IUsuarioServico, DentalClaims.Application.Services.UsuarioServico>();
builder.Services.AddScoped<IConsultaServico, ConsultaServico>();

// Register Validators
builder.Services.AddScoped<IValidator<CriarUsuarioDto>, CriarUsuarioDtoValidator>();
builder.Services.AddScoped<IValidator<ConsultaDto>, ConsultaDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
