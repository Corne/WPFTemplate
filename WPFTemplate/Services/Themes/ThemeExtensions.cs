using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro;

namespace WPFTemplate.Services.Themes
{
    public static class ThemeExtensions
    {

        public static ThemeColor ToThemeColor(this AppTheme theme)
        {
            return new ThemeColor(theme.Name, theme.Resources["WindowBackgroundBrush"].ToString());
        }

        public static AccentColor ToAccentColor(this Accent accent)
        {
            return new AccentColor(accent.Name, accent.Resources["HighlightColor"].ToString());
        }
    }
}
