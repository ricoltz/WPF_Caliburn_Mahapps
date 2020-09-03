using Autofac;
using Caliburn.Micro;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Caliburn_Mahapps.Events;
using WPF_Caliburn_Mahapps.Services;

namespace WPF_Caliburn_Mahapps.ViewModels
{
    public class SettingsViewModel : MenuItemViewModel, IHandle<UpdateUIEvent>
    {        

        public SettingsViewModel( ShellViewModel shellViewModel, IComponentContext context) : base(shellViewModel, context)
        {  
            UpdateUI();

            Tag = this;
            Icon = new PackIconMaterial() { Kind = PackIconMaterialKind.SettingsHelper };
        }



        /// <summary>
        /// Update all UI text fields
        /// </summary>
        public override void UpdateUI()
        {
            DisplayName = LocalizationProvider.GetLocalizedValue<string>("SettingsViewName");
            Label = LocalizationProvider.GetLocalizedValue<string>("SettingsViewLabel");
            ToolTip = LocalizationProvider.GetLocalizedValue<string>("SettingsViewToolTip");
        }

        #region Events
        
        public void Handle(UpdateUIEvent message)
        {
            UpdateUI();
        }

        #endregion
    }
}
