namespace Softnotik.UI.Shared.ViewModels.Interfaces
{
    public interface ISettingsViewModel
    {
        public string CurrentTheme { get; }
        public bool Notifications { get; set; }
        public bool DarkTheme { get; set; }

        public Task UpdateTheme();
        public Task UpdateNotifications();
    }
}
