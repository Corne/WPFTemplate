using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WPFTemplate.Services.Themes;

namespace WPFTemplate.ViewModels.Settings
{
    public class ThemeViewModel : ViewModelBase, ISettingEditor
    {

        private readonly IThemeController controller;

        public ThemeViewModel(IThemeController controller)
        {
            this.controller = controller;

            Themes = controller.Themes;
            Accents = controller.Accents;

            CurrentTheme = Themes.Single(t => t.Name == controller.CurrentTheme.Name);
            CurrentAccent = Accents.Single(a => a.Name == controller.CurrentAccent.Name);
        }

        public string Title { get { return "Theme"; } }

        public IEnumerable<ThemeColor> Themes { get; }
        public IEnumerable<AccentColor> Accents { get; }

        private ThemeColor _currentTheme;
        public ThemeColor CurrentTheme
        {
            get { return _currentTheme; }
            set
            {
                if (Set(ref _currentTheme, value))
                {
                    controller.SetTheme(_currentTheme.Name);
                }
            }
        }

        private AccentColor _currentAccent;
        public AccentColor CurrentAccent
        {
            get { return _currentAccent; }
            set
            {
                if (Set(ref _currentAccent, value))
                {
                    controller.SetAccent(_currentAccent.Name);
                }
            }
        }
    }


}
