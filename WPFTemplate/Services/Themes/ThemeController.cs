using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MahApps.Metro;

namespace WPFTemplate.Services.Themes
{
    public class ThemeController : IThemeController
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Tuple<AppTheme, Accent> defaultTheme;

        public ThemeController()
        {
            if (Application.Current != null)
            {
                // set current active theme
                // if not initialized yet this will be the setting from the app.xaml
                defaultTheme = getCurrentAppStyle();
                log.Info($"Created ThemeController with {defaultTheme.Item1.Name}");
            }
            else
            {
                log.Warn("Themecontroller created without current application (valid within unit tests)");
            }
        }

        public void Initialize()
        {
            var theme = Properties.Settings.Default.Theme;
            var accent = Properties.Settings.Default.Accent;

            if (!Themes.Any(c => c.Name == theme))
            {
                theme = defaultTheme.Item1.Name;
            }

            if (!Accents.Any(c => c.Name == accent))
            {
                accent = defaultTheme.Item2.Name;
            }

            SetTheme(theme);
            SetAccent(accent);
        }

        public IEnumerable<ThemeColor> Themes { get { return ThemeManager.AppThemes.Select(t => t.ToThemeColor()).ToArray(); } }
        public IEnumerable<AccentColor> Accents { get { return ThemeManager.Accents.Select(a => a.ToAccentColor()).ToArray(); } }

        public ThemeColor CurrentTheme { get { return getCurrentAppStyle().Item1.ToThemeColor(); } }
        public AccentColor CurrentAccent { get { return getCurrentAppStyle().Item2.ToAccentColor(); } }

        private Tuple<AppTheme, Accent> getCurrentAppStyle()
        {
            return ThemeManager.DetectAppStyle(Application.Current);
        }

        public void Default()
        {
            SetTheme(defaultTheme.Item1.Name);
        }

        public void Reverse()
        {
            var current = getCurrentAppStyle();
            var reverse = ThemeManager.GetInverseAppTheme(current.Item1);
            SetTheme(reverse.Name);
        }

        public void SetTheme(string theme)
        {
            log.Info($"Switched theme to {theme}");
            ThemeManager.ChangeAppTheme(Application.Current, theme);
            Properties.Settings.Default.Theme = theme;
            Properties.Settings.Default.Save();
        }

        public void SetAccent(string accent)
        {
            log.Info($"Switched accent to {accent}");

            var resource = ThemeManager.GetAccent(accent);
            ThemeManager.ChangeAppStyle(Application.Current, resource, getCurrentAppStyle().Item1);
            Properties.Settings.Default.Accent = accent;
            Properties.Settings.Default.Save();

        }


    }
}
