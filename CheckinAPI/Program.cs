using CheckInAPI.Data;
using CheckInAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cria o caminho da pasta do banco de dados
var pastaBanco = Path.Combine(Directory.GetCurrentDirectory(), "Banco");
Directory.CreateDirectory(pastaBanco); // Garante que a pasta será criada

// Caminho completo do banco de dados SQLite
var caminhoDoBanco = Path.Combine(pastaBanco, "checkinbanco.db");

// Configura o Entity Framework com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={caminhoDoBanco}"));

builder.Services.AddControllers();

var app = builder.Build();

// Cria o banco e popula registros iniciais se necessário
using (var escopo = app.Services.CreateScope())
{
    var contexto = escopo.ServiceProvider.GetRequiredService<AppDbContext>();

    // Cria o banco se não existir
    contexto.Database.EnsureCreated();

    // Adiciona registros iniciais se estiver vazio
    if (!contexto.Checkins.Any())
    {
        var registrosIniciais = new List<Checkin>
        {
            new Checkin { Codigo = "CHK001", Email = "ana@email.com", DataCheckin = DateTime.Now },
            new Checkin { Codigo = "CHK002", Email = "bruno@email.com", DataCheckin = DateTime.Now },
            new Checkin { Codigo = "CHK003", Email = "carla@email.com", DataCheckin = DateTime.Now },
            new Checkin { Codigo = "CHK004", Email = "daniel@email.com", DataCheckin = DateTime.Now },
            new Checkin { Codigo = "CHK005", Email = "elaine@email.com", DataCheckin = DateTime.Now },
            new Checkin { Codigo = "CHK006", Email = "felipe@email.com", DataCheckin = DateTime.Now },
            new Checkin { Codigo = "CHK007", Email = "gisele@email.com", DataCheckin = DateTime.Now },
            new Checkin { Codigo = "CHK008", Email = "hugo@email.com", DataCheckin = DateTime.Now },
            new Checkin { Codigo = "CHK009", Email = "isabela@email.com", DataCheckin = DateTime.Now },
            new Checkin { Codigo = "CHK010", Email = "joao@email.com", DataCheckin = DateTime.Now },
        };

        contexto.Checkins.AddRange(registrosIniciais);
        contexto.SaveChanges();
    }
}

app.MapControllers();

app.Run();
