using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 1. ocelot.json laden
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// 2. Authentifizierung wie in der Order.API (Ocelot prüft das Token vorab)
builder.Services.AddAuthentication()
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7234"; // Unser IdP
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Services.AddOcelot();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorCors", policy =>
    {
        policy.WithOrigins("https://localhost:7003") // Port Ihrer Blazor-App
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("BlazorCors"); // Muss VOR UseOcelot stehen!

app.UseHttpsRedirection();

// WICHTIG: Die Reihenfolge!
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Ocelot muss ganz am Ende der Pipeline stehen
await app.UseOcelot();

app.Run();
