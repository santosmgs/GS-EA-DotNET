using Microsoft.AspNetCore.Authentication.JwtBearer;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using EnergyAwareness.Data;

var builder = WebApplication.CreateBuilder(args);

// Inicializa o Firebase Admin SDK - Somente uma vez no início da aplicação
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("energy-awareness-firebase-adminsdk-rhkft-3a71cf7291.json")
});

// Configuração de autenticação JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/energy-awareness";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/energy-awareness",
            ValidateAudience = true,
            ValidAudience = "energy-awareness",
            ValidateLifetime = true
        };
    });

// Configuração do banco de dados com Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração dos serviços
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Configuração do pipeline HTTP
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();