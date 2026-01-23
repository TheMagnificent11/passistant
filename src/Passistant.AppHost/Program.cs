using Passistant.Common;

var builder = DistributedApplication.CreateBuilder(args);

var isTest = Environments.IsIntegrationTesting;
var isDevOrTest = isTest;

#if DEBUG
isDevOrTest = true;
#endif

var authServer = builder.AddKeycloak(ServiceNames.AuthServer)
    .WithRealmImport($"keycloak/{Environments.Auth.RealmName}-realm.json");

if (isDevOrTest)
{
    authServer = authServer
        .WithEnvironment("KC_BOOTSTRAP_ADMIN_USERNAME", Environments.Auth.DefaultAdminCredentialsForTesting.Username)
        .WithEnvironment("KC_BOOTSTRAP_ADMIN_PASSWORD", Environments.Auth.DefaultAdminCredentialsForTesting.Password);
}

if (!isTest)
{
    authServer = authServer
        .WithLifetime(ContainerLifetime.Persistent)
        .WithDataVolume();
}

var databaseServer = Environments.IsIntegrationTesting
    ? builder.AddPostgres(ServiceNames.DatabaseServer)
    : builder.AddPostgres(ServiceNames.DatabaseServer)
        .WithLifetime(ContainerLifetime.Persistent)
        .WithDataVolume(isReadOnly: false)
        .WithPgWeb();

var mealPlannerDatabase = databaseServer.AddDatabase(ServiceNames.MealPlannerDatabase);

builder.AddProject<Projects.Passistant_MealPlanner>(ServiceNames.MealPlannerApp)
    .WithReference(mealPlannerDatabase)
    .WithReference(authServer)
    .WaitFor(mealPlannerDatabase)
    .WaitFor(authServer);

var app = builder.Build();

await app.RunAsync();
