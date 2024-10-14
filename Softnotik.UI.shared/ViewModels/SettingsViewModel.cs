using Softnotik.UI.Shared.ViewModels.Interfaces;

namespace Softnotik.UI.Shared.ViewModels
{
    public class SettingsViewModel : ISettingsViewModel
    {
        public bool DarkTheme { get; set; } = false;
        public string CurrentTheme => DarkTheme ? "dark" : "light";

        public SettingsViewModel()
        {
        }

        public void UpdateTheme()
        {
            DarkTheme = !DarkTheme;
        }
    }
}
