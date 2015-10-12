using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTemplate.Services.Themes
{
    public interface IThemeController
    {
        /// <summary>
        /// Return all the available themes
        /// </summary>
        IEnumerable<ThemeColor> Themes { get; }

        /// <summary>
        /// Return all the available accents
        /// </summary>
        IEnumerable<AccentColor> Accents { get; }

        /// <summary>
        /// Get the current active theme
        /// </summary>
        ThemeColor CurrentTheme { get; }

        /// <summary>
        /// Get the current active accent
        /// </summary>
        AccentColor CurrentAccent { get; }

        /// <summary>
        /// Sets the default theme (theme that was active this instance was created)
        /// </summary>
        void Default();
        /// <summary>
        /// Rerverses current theme white -> black / black -> white
        /// </summary>
        void Reverse();

        /// <summary>
        /// Set a new theme
        /// </summary>
        /// <param name="theme">name of the theme</param>
        void SetTheme(string theme);

        /// <summary>
        /// Set a new accent
        /// </summary>
        /// <param name="accent">name the accent</param>
        void SetAccent(string accent);
    }
}
