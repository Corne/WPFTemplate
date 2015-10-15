using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WPFTemplate.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ThemeViewModel themeViewModel;

        public SettingsViewModel(ThemeViewModel themeViewModel)
        {
            this.themeViewModel = themeViewModel;
        }

        private ISettingEditor _content;
        public ISettingEditor Content
        {
            get { return _content; }
            set { Set(ref _content, value); }
        }

        private bool _showSettings;
        public bool ShowSettings
        {
            get { return _showSettings; }
            set { Set(ref _showSettings, value); }
        }

        public ICommand OpenThemeSettings
        {
            get { return new RelayCommand(openSettingsExecute); }
        }

        private void openSettingsExecute()
        {
            Content = themeViewModel;
            ShowSettings = true;
        }
    }
}
