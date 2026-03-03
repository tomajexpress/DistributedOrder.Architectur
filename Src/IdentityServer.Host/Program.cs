using IdentityServer.Host;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// 1. CORS-Dienst hinzufügen
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClientPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7003") // Die URL Ihrer Blazor-App
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 2. IdentityServer Dienste registrieren
builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
})
.AddInMemoryIdentityResources(Config.IdentityResources)
.AddInMemoryApiScopes(Config.ApiScopes)
.AddInMemoryClients(Config.Clients)
.AddTestUsers(TestUsers.Users) // Für die Entwicklung nutzen wir Test-User
.AddDeveloperSigningCredential(); // Für die Entwicklung nutzen wir ein temporäres Signaturzertifikat

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// 2. CORS-Middleware an der richtigen Stelle aktivieren!
// WICHTIG: UseCors muss VOR UseIdentityServer stehen
app.UseCors("BlazorClientPolicy");

app.UseIdentityServer(); // Diese Middleware erledigt die ganze Magie
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
