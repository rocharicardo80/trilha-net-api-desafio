using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;

var builder = WebApplication.CreateBuilder(args);

// ✅ Pega a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("⚠️ ERRO: ConnectionString não encontrada no appsettings.json!");
}
else
{
    Console.WriteLine($"ConnectionString: {connectionString}");
}

builder.Services.AddDbContext<OrganizadorContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
