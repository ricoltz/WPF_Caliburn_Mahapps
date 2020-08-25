using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Caliburn_Mahapps.ViewModels
{
    public class SettingsViewModel : HamburgerMenuItemViewModel
    {
        public SettingsViewModel( ShellViewModel shellViewModel) : base(shellViewModel)
        {
            DisplayName = "Settings View";
            Label = "Settings";
            ToolTip = "Settings for all";
            Tag = this;
            Icon = new PackIconMaterial() { Kind = PackIconMaterialKind.SettingsHelper };
        }
    }
}
