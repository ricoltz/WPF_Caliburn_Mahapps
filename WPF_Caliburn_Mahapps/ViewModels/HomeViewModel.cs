using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WPF_Caliburn_Mahapps.Services;

namespace WPF_Caliburn_Mahapps.ViewModels
{
    public class HomeViewModel : HamburgerMenuItemViewModel
    {
        public HomeViewModel(ShellViewModel shellViewModel) : base(shellViewModel)
        {
            DisplayName = LocalizationProvider.GetLocalizedValue<string>("HomeViewName");

            Label = "Home";
            ToolTip = "Home sweet home";
            Tag = this;
            Icon = new PackIconMaterial() { Kind = PackIconMaterialKind.Home };
        }
    }
}
