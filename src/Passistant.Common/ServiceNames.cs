namespace Passistant.Common;

public static class ServiceNames
{
    public const string DatabaseServer = "database-server";

    public const string MealPlannerDatabase = "meal-planner-database";

    public const string MealPlannerDatabaseIntegrationTesting = "meal-planner-integration-testing-database";

    public const string MealPlannerWeb = "meal-planner-web";

    public const string AuthServer = "auth-server";

    public static string PizzaStoreDatabaseName => Environments.IsIntegrationTesting
        ? MealPlannerDatabaseIntegrationTesting
        : MealPlannerDatabase;
}
