using Microsoft.EntityFrameworkCore;
using Tarea2_ArquiSistemas.Src.Data;
using Tarea2_ArquiSistemas.Src.Repositories;
using Tarea2_ArquiSistemas.Src.Repositories.Interfaces;
using Tarea2_ArquiSistemas.Src.Services;
using Tarea2_ArquiSistemas.Src.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data Source=user_db.db"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();


app.Run();


