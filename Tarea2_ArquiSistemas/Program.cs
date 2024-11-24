using Microsoft.EntityFrameworkCore;
using Tarea2_ArquiSistemas.Src.Data;
using Microsoft.IdentityModel.Tokens;
using Tarea2_ArquiSistemas.Src.Repositories;
using Tarea2_ArquiSistemas.Src.Repositories.Interfaces;
using Tarea2_ArquiSistemas.Src.Services;
using Tarea2_ArquiSistemas.Src.Services.Interfaces;
using System.Text;

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

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    if (options != null)
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:TokenKey").Value!))
        };
    }
    else
    {
        throw new ArgumentNullException(nameof(options));
    }
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    try
    {
        Console.WriteLine("Aplicando migraciones...");
        dbContext.Database.Migrate();
        DataSeeder.Initialize(scope.ServiceProvider);
        Console.WriteLine("Migraciones aplicadas correctamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al aplicar migraciones: {ex.Message}");
    }
}
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


