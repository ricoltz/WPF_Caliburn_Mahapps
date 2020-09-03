using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using MahApps.Metro.Controls.Dialogs;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WPF_Caliburn_Mahapps.Helpers;
using WPF_Caliburn_Mahapps.ViewModels;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Providers;

namespace WPF_Caliburn_Mahapps
{
    public class AppBootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        //Constructor
        public AppBootstrapper()
        {
            Initialize();

            //For binding the passwordbox to a property
            // see https://stackoverflow.com/questions/30631522/caliburn-micro-support-for-passwordbox
            ConventionManager.AddElementConvention<PasswordBox>(
                PasswordBoxHelper.BoundPassword,
                "Password", "PasswordChanged");
        }

        //Configure the container
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            //Configure and register the logger
            log4net.Config.XmlConfigurator.Configure();
            builder.RegisterInstance(log4net.LogManager.GetLogger("Log")).As<log4net.ILog>();

            //Register dialog coordinator
            builder.RegisterType<DialogCoordinator>().As<IDialogCoordinator>().SingleInstance();


        }

        //Configure the bootstrapper
        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();
            EnforceNamespaceConvention = false;
        }

        //Configure the on start up action
        protected override void OnStartup(object sender, StartupEventArgs e)
        {

            ResxLocalizationProvider.Instance.UpdateCultureList(GetType().Assembly.FullName, "Resources");
            LocalizeDictionary.Instance.IncludeInvariantCulture = false;
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            string lang = "de-DE";
            LocalizeDictionary.Instance.Culture = new CultureInfo(lang);

            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
