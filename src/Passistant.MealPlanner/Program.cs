using Microsoft.AspNetCore.Authentication.Cookies;
using MudBlazor.Services;
using Passistant.Common;
using Passistant.MealPlanner;

var builder = WebApplication.CreateBuilder(args);

// Add Aspire service discovery
builder.Services.AddServiceDiscovery();
builder.Services.ConfigureHttpClientDefaults(http => http.AddServiceDiscovery());

// Add services to the container.
builder.Services.AddMudServices();

// Configure authentication with Keycloak OIDC using Aspire integration
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "keycloak";
})
.AddCookie()
.AddKeycloakOpenIdConnect(
    serviceName: ServiceNames.AuthServer,
    realm: Passistant.Common.Environments.Auth.RealmName,
    authenticationScheme: "keycloak",
    options =>
    {
        options.ClientId = "passistant-mealplanning-web";
        options.ResponseType = "code";
        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.MapInboundClaims = false;
        options.TokenValidationParameters.NameClaimType = "preferred_username";
        options.TokenValidationParameters.RoleClaimType = "roles";
        options.RequireHttpsMetadata = false; // Allow HTTP for local development with Aspire

        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Passistant.MealPlanner.Client._Imports).Assembly)
    .RequireAuthorization();

await app.RunAsync();
