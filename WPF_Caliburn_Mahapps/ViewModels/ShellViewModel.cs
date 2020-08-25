using Autofac;
using Autofac.Core;
using Caliburn.Micro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.IconPacks;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using WPF_Caliburn_Mahapps.Contracts;
using WPF_Caliburn_Mahapps.Services;

namespace WPF_Caliburn_Mahapps.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        #region Private Vars

        //The logger
        private log4net.ILog _log;        

        //Dialogcoordinator
        private IDialogCoordinator _dialogs;

        //Hamburger view models
        private HomeViewModel _homeViewModel;
        private SettingsViewModel _settingsViewModel;

        //Flyout view models
        private UserInfoFlyoutViewModel _userInfoFlyoutViewModel;

        #endregion

        #region UI Properties

        private ObservableCollection<HamburgerMenuItemViewModel> _menuItems;
        /// <summary>
        /// Hamburger menu items
        /// </summary>
        public ObservableCollection<HamburgerMenuItemViewModel> MenuItems
        {
            get { return _menuItems; }
            //set { Set( ref _menuItems, value); }
        }

        private BindableCollection<HamburgerMenuItemViewModel> _optionMenuItems;
        /// <summary>
        /// Hamburger option menu items
        /// </summary>
        public BindableCollection<HamburgerMenuItemViewModel> OptionMenuItems
        {
            get { return _optionMenuItems; }
            //set { Set( ref _optionMenuItems, value); }
        }

        private BindableCollection<FlyoutBaseViewModel> _flyoutItems;
        /// <summary>
        /// Flyout items
        /// </summary>
        public BindableCollection<FlyoutBaseViewModel> FlyoutItems
        {
            get { return _flyoutItems; }
            //set { Set( ref _flyoutItems, value); }
        }

        ///// <summary>
        ///// Language support
        ///// </summary>
        //public IList<CultureInfo> SupportedLanguages
        //{ 
        //    get => _localizerService.SupportedLanguages ?? null; 
        //}

        /// <summary>
        /// Selected language
        /// </summary>
        public CultureInfo SelectedLanguage
        {
            get => _localizerService.SelectedLanguage ?? null;
            set => SelectedLanguage = value ?? null;
        }

        #endregion


        #region Constructor

        /// <summary>
        /// ShellViewModel constructor
        /// </summary>
        /// <param name="container"></param>
        public ShellViewModel(IComponentContext container)
        {
            DisplayName = LocalizationProvider.GetLocalizedValue<string>("AppName");

            //Resolve the logger
            _log = container.Resolve<log4net.ILog>();            

            //Resolve the dialog coordinator
            _dialogs = container.Resolve<IDialogCoordinator>();

            //Init hamburger and flyouts item lists
            _menuItems = new BindableCollection<HamburgerMenuItemViewModel>();
            _optionMenuItems = new BindableCollection<HamburgerMenuItemViewModel>();
            _flyoutItems = new BindableCollection<FlyoutBaseViewModel>();

            //Resolve hamburger viewmodels
            _homeViewModel = container.Resolve<HomeViewModel>(new NamedParameter ("shellViewModel", this ));
            _settingsViewModel = container.Resolve<SettingsViewModel>(new NamedParameter("shellViewModel", this));

            //Resolve flyout viewmodels
            _userInfoFlyoutViewModel = container.Resolve<UserInfoFlyoutViewModel>();

            CreateMenuItems();
            CreateFlyoutItems();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Create menu items and menu option items
        /// </summary>
        public void CreateMenuItems()
        {           
            //MenuItems
            MenuItems.Add(_homeViewModel);

            //MenuOptionItems
            OptionMenuItems.Add(_settingsViewModel);
        }

        public void CreateFlyoutItems()
        {
            FlyoutItems.Add(_userInfoFlyoutViewModel);
        }

        /// <summary>
        /// Set the content of active item in caliburn.micro
        /// </summary>
        /// <param name="hamburgerMenuItemViewModel"></param>
        public void SetContent(object hamburgerMenuItemViewModel)
        {
            ActiveItem = hamburgerMenuItemViewModel as HamburgerMenuItemViewModel;
        }

        /// <summary>
        /// Togle flyouts
        /// </summary>
        /// <param name="name"></param>
        public void ToggleFlyout(string name)
        {
            this.ApplyToggleFlyout(name);
        }

        /// <summary>
        /// Toggle flyouts with all paramter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="isModal"></param>
        /// <param name="show"></param>
        /// <param name="theme"></param>
        protected void ApplyToggleFlyout(string name, 
                                         Position? position = null, 
                                         bool? isModal = null, 
                                         bool? show = null, 
                                         FlyoutTheme? theme = null)
        {
            Contract.Requires(name != null, "name cannot be null");

            //Find the flyout
            var flyout = FlyoutItems.FirstOrDefault(f => f.Name == name);
            if (flyout == null)
            {
                _log.Error("Error selecting flyout by name, no matching item found!");
                return;
            }

            if (position.HasValue) 
                flyout.Position = position.Value;

            if (isModal.HasValue)
                flyout.IsModal = isModal.Value;

            if (show.HasValue)
            {
                flyout.IsOpen = show.Value;
            }
            else
            {
                flyout.IsOpen = !flyout.IsOpen;
            }

            if (theme.HasValue)
            {
                flyout.Theme = theme.Value;
            }
        }

        public async void LogMeIn()
        {
            var data = await _dialogs.ShowLoginAsync(this, "Login", "Bitte loggen Sie sich ein");           

        }



        #endregion



    }
}
