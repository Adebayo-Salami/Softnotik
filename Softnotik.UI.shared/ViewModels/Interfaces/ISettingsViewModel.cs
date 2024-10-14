namespace Softnotik.UI.Shared.ViewModels.Interfaces
{
    public interface ISettingsViewModel
    {
        public string CurrentTheme { get; }
        public bool DarkTheme { get; set; }

        public void UpdateTheme();
    }
}
