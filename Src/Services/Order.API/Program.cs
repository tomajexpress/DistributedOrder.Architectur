var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 1. Authentifizierung hinzufügen
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        // Die URL unseres IdentityServers (passen Sie den Port an Ihren lokalen IdP an)
        options.Authority = "https://localhost:7234";

        // Da wir in der Config.cs des IdP den Scope "orderapi" definiert haben
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false // Für den Start vereinfacht. In Produktion oft auf true gesetzt.
        };
    });

// 2. Autorisierung (Rechteprüfung) hinzufügen
builder.Services.AddAuthorization(options =>
{
    // Beispiel für eine Policy, die wir auf Controller anwenden können
    options.AddPolicy("SeniorDeveloperOnly", policy =>
        policy.RequireClaim("role", "SeniorDeveloper"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 3. Middleware-Pipeline aktivieren (Reihenfolge ist extrem wichtig!)
app.UseAuthentication(); // Wer bist du?
app.UseAuthorization();  // Was darfst du?

app.MapControllers();

app.Run();
