using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Caliburn_Mahapps.ViewModels
{
    public class UserInfoFlyoutViewModel : FlyoutBaseViewModel
    {
        public UserInfoFlyoutViewModel()
        {
            Name = "UserInfo";
            Header = "User info";
            Position = Position.Right;
        }
    }
}
