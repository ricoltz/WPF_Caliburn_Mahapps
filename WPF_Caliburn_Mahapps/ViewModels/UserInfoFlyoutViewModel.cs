using Autofac;
using Caliburn.Micro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WPF_Caliburn_Mahapps.Events;
using WPF_Caliburn_Mahapps.Services;

namespace WPF_Caliburn_Mahapps.ViewModels
{
    public class UserInfoFlyoutViewModel : FlyoutBaseViewModel, IHandle<UpdateUIEvent>
    {       

        public UserInfoFlyoutViewModel(IComponentContext context) : base(context)
        {
            Name = "UserInfo";            
            Position = Position.Right;
            UpdateUI();
        }

        public void UpdateUI()
        {
            Header = LocalizationProvider.GetLocalizedValue<string>("UserInfoFlyoutCaption");
        }

        public void Handle(UpdateUIEvent message)
        {
            UpdateUI();
        }
    }
}
