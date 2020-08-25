using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Caliburn_Mahapps.Contracts
{
    public interface IHamburgerMenuItemViewModel : IHamburgerMenuItemBase
    {
        object Icon { get; }
        object Label { get; }
        object Tag { get; }
        object ToolTip { get; }
        
    }
}
