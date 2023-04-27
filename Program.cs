using HelpDeskClean.Data;
using HelpDeskClean.Repositories;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("HelpDeskConnection");
builder.Services.AddDbContext<ApplicationContext>(
    opt => opt.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString))
    );

builder.Services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(cors =>
{
    cors.AllowAnyHeader();
    cors.AllowAnyMethod();
    cors.AllowAnyOrigin();
});

app.MapControllers();

app.Run();
