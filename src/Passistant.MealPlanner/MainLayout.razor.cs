using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Passistant.MealPlanner;

public partial class MainLayout : LayoutComponentBase
{
    private MudThemeProvider ThemeProvider { get; set; } = null!;

    private bool IsDarkMode { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            this.IsDarkMode = await this.ThemeProvider.GetSystemDarkModeAsync();
            await this.ThemeProvider.WatchSystemDarkModeAsync(this.OnSystemPreferenceChangedAsync);
            this.StateHasChanged();
        }
    }

    private Task OnSystemPreferenceChangedAsync(bool isDarkMode)
    {
        this.IsDarkMode = isDarkMode;
        this.StateHasChanged();
        return Task.CompletedTask;
    }
}
