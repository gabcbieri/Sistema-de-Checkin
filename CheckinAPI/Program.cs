using CheckInAPI.Data;
using CheckInAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var pastaBanco = Path.Combine(Directory.GetCurrentDirectory(), "Banco");
Directory.CreateDirectory(pastaBanco);
var caminhoDoBanco = Path.Combine(pastaBanco, "checkinbanco.db");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={caminhoDoBanco}"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var escopo = app.Services.CreateScope())
{
    var contexto = escopo.ServiceProvider.GetRequiredService<AppDbContext>();
    contexto.Database.EnsureCreated();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
