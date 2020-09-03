using Autofac;
using Caliburn.Micro;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Markup;
using WPF_Caliburn_Mahapps.Events;
using WPF_Caliburn_Mahapps.Services;

namespace WPF_Caliburn_Mahapps.ViewModels
{
    public class HomeViewModel : MenuItemViewModel, IHandle<UpdateUIEvent>
    {      
        public HomeViewModel(ShellViewModel shellViewModel, IComponentContext context) : base(shellViewModel, context)
        {
            UpdateUI();

            Tag = this;
            Icon = new PackIconMaterial() { Kind = PackIconMaterialKind.Home };
        }

        public override void UpdateUI()
        {
            DisplayName = LocalizationProvider.GetLocalizedValue<string>("HomeViewName");
            Label = LocalizationProvider.GetLocalizedValue<string>("HomeViewLabel");
            ToolTip = LocalizationProvider.GetLocalizedValue<string>("HomeViewToolTip");
        }

        #region Events

        public void Handle(UpdateUIEvent message)
        {
            UpdateUI();
        }

        #endregion
    }
}
