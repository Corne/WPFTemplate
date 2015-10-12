using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFTemplate.ViewModels;

namespace WPFTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var locator = (ViewModelLocator)FindResource("Locator");
            locator.Dispose();
            base.OnExit(e);
        }
    }
}
