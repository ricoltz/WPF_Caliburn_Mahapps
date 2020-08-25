using MahApps.Metro.Controls;

namespace WPF_Caliburn_Mahapps.Contracts
{
    public interface IFlyoutBaseViewModel
    {
        string Header { get; set; }
        bool IsModal { get; set; }
        bool IsOpen { get; set; }
        string Name { get; set; }
        Position Position { get; set; }
        FlyoutTheme Theme { get; set; }
    }
}