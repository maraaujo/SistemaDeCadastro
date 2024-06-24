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

var connectionString = builder.Configuration.GetConnectionString("SistemaDeCadastro");

builder.Services.AddDbContext<SitemaDeCadastroContext>(options =>
{
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddScoped<IIdosoRepository, IdosoRepository>();
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
