using Caliburn.Micro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Caliburn_Mahapps.Contracts;

namespace WPF_Caliburn_Mahapps.ViewModels
{
    public class FlyoutBaseViewModel : PropertyChangedBase, IFlyoutBaseViewModel
    {
        private string _name;
        /// <summary>
        /// Name for the flyout object
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }


        private string _header;
        /// <summary>
        /// Flyout header string.
        /// </summary>
        public string Header
        {
            get { return _header; }
            set
            {
                if (value == this._header)
                {
                    return;
                }
                Set(ref _header, value);
            }
        }

        private bool _isOpen;
        /// <summary>
        /// Flyout open status.
        /// </summary>
        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                if (value.Equals(_isOpen))
                {
                    return;
                }
                Set(ref _isOpen, value);
            }
        }

        private Position _position;
        /// <summary>
        /// The position of flyout
        /// </summary>
        public Position Position
        {
            get { return _position; }
            set
            {
                if (value == _position)
                {
                    return;
                }
                Set(ref _position, value);
            }
        }

        private bool _isModal;

        public bool IsModal
        {
            get { return _isModal; }
            set { Set(ref _isModal, value); }
        }

        private FlyoutTheme _theme;
        /// <summary>
        /// Theme of flyout
        /// </summary>
        public FlyoutTheme Theme
        {
            get { return _theme; }
            set
            {
                if (value == _theme)
                {
                    return;
                }
                Set(ref _theme, value);
            }
        }

    }
}
