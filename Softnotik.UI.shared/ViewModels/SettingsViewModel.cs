using Softnotik.UI.Shared.ViewModels.Interfaces;

namespace Softnotik.UI.Shared.ViewModels
{
    public class SettingsViewModel : ISettingsViewModel
    {
        public bool Notifications { get; set; }
        public bool DarkTheme { get; set; } = false;

        public string CurrentTheme => DarkTheme ? "dark" : "light";

        public SettingsViewModel()
        {
        }

        public async Task UpdateTheme()
        {
            throw new NotImplementedException();
        }

        public Task UpdateNotifications()
        {
            throw new NotImplementedException();
        }
    }
}
