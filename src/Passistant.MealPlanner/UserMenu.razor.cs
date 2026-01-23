namespace Passistant.MealPlanner;

public partial class UserMenu
{
    private void SignOut()
    {
        // Force a full page reload to initiate server-side logout
        this.Navigation.NavigateTo("/authentication/logout", forceLoad: true);
    }
}
