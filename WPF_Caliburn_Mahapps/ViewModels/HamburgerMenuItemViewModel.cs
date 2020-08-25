using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Caliburn_Mahapps.Contracts;

namespace WPF_Caliburn_Mahapps.ViewModels
{
    public class HamburgerMenuItemViewModel : Screen, IHamburgerMenuItemViewModel
    {
        private object _icon;
        public object Icon
        {
            get => _icon;
            set => Set(ref _icon, value);
        }

        private object _label;
        public object Label { 
            get => _label;
            set => Set(ref _label, value);
        }

        private object _tag;

        public object Tag
        {
            get => _tag; 
            set => Set( ref _tag,  value); 
        }


        private object _toolTip;
        public object ToolTip
        {
            get => _toolTip;
            set => Set(ref _toolTip, value);
        }

        private bool _isVisible = true;
        public bool IsVisible { 
            get => _isVisible; 
            set => Set(ref _isVisible, value); 
        }

        public ShellViewModel ShellViewModel { get; }

        public HamburgerMenuItemViewModel(ShellViewModel shellViewModel)
        {
            ShellViewModel = shellViewModel;
        }
    }
}
