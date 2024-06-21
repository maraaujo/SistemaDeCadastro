using Microsoft.EntityFrameworkCore;
using SistemaDeCadastro.APP;
using SistemaDeCadastro.APP.Interface;
using SistemaDeCadastro.Data.Interface;
using SistemaDeCadastro.Data.Repository;
using SistemaDeCadastro.Domain.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SitemaDeCadastroContext>(options => 
options.UseSqlServer(builder.Configuration
.GetConnectionString("Host=localhost;Database=mydb;Username=root;Password=irmaos03;Convert Zero Datetime=True")));

builder.Services.AddScoped<SitemaDeCadastroContext>();
builder.Services.AddScoped<IIdosoRepository,IdosoRepository>();
builder.Services.AddScoped<IIdosoApp, IdosoApp>();

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
