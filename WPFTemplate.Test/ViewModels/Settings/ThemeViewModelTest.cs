using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTemplate.Services.Themes;
using WPFTemplate.ViewModels.Settings;
using Moq;
using NUnit.Framework;

namespace WPFTemplate.Test.ViewModels.Settings
{
    [TestFixture]
    public class ThemeViewModelTest
    {
        private static readonly ThemeColor[] themes = new[] {
            new ThemeColor("theme1", "black"),
            new ThemeColor("theme2", "white"),
            new ThemeColor("theme3", "pink"),
        };

        private static readonly AccentColor[] accents = new[] {
            new AccentColor("accent 1", "red"),
            new AccentColor("accent 2", "blue"),
            new AccentColor("accent 3", "green"),
            new AccentColor("accent 4", "yellow"),
        };

        private Mock<IThemeController> controller;

        [SetUp]
        public void SetUp()
        {
            controller = new Mock<IThemeController>();
            controller.Setup(c => c.Themes).Returns(themes);
            controller.Setup(c => c.Accents).Returns(accents);
            controller.Setup(c => c.CurrentTheme).Returns(themes[1]);
            controller.Setup(c => c.CurrentAccent).Returns(accents[2]);
        }

        [Test]
        public void ConstructionTest()
        {
            var themeviewmodel = new ThemeViewModel(controller.Object);

            Assert.AreEqual(themeviewmodel.Themes, themes);
            Assert.AreEqual(themeviewmodel.Accents, accents);
            Assert.AreEqual(themeviewmodel.CurrentTheme, themes[1]);
            Assert.AreEqual(themeviewmodel.CurrentAccent, accents[2]);
        }

        [Test]
        public void CurrentThemeUpdateTest()
        {
            var themeviewmodel = new ThemeViewModel(controller.Object);
            themeviewmodel.CurrentTheme = themes[0];

            controller.Verify(c => c.SetTheme(themes[0].Name));
        }

        [Test]
        public void CurrentAccentUpdateTest()
        {
            var themeviewmodel = new ThemeViewModel(controller.Object);
            themeviewmodel.CurrentAccent = accents[0];

            controller.Verify(c => c.SetAccent(accents[0].Name));
        }

        /// <summary>
        /// Check if the update don't get called, when we try to set the currentvalue
        /// </summary>
        [Test]
        public void CurrentThemeNoUpdateTest()
        {
            var themeviewmodel = new ThemeViewModel(controller.Object);

            //set gets called once on construction, but not after set
            controller.Verify(c => c.SetTheme(themes[1].Name), Times.Once);
            themeviewmodel.CurrentTheme = themes[1];
            controller.Verify(c => c.SetTheme(themes[1].Name), Times.Once);
        }

        [Test]
        public void CurrentAccentNoUpdateTest()
        {
            var themeviewmodel = new ThemeViewModel(controller.Object);

            controller.Verify(c => c.SetAccent(accents[2].Name), Times.Once);
            themeviewmodel.CurrentAccent = accents[2];
            controller.Verify(c => c.SetAccent(accents[2].Name), Times.Once);
        }
    }
}
