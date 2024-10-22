using Bodega.Repository;
using Bodega.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Obtener la cadena de conexi�n desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("BodegaConnection");

// Agregar el contexto de base de datos con SQLite
builder.Services.AddDbContext<BodegaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BodegaAPIDBConnectionString")));


// Configuraci�n de JWT
var secretKey = builder.Configuration["Authentication:SecretForKey"];
var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        ValidateLifetime = true, // Valida la expiraci�n del token
        ClockSkew = TimeSpan.Zero // Elimina la tolerancia para la expiraci�n del token
    };
});

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Inyectar repositorios y servicios
builder.Services.AddScoped<VinoRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IVinoService, VinoService>();
builder.Services.AddScoped<IUserService, UserService>();

// Agregar Swagger para documentaci�n de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware para la autenticaci�n
app.UseAuthentication(); // Asegura que se use la autenticaci�n antes de la autorizaci�n
app.UseAuthorization();

app.MapControllers();

app.Run();