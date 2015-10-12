using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTemplate.Services.Themes
{
    public class ThemeColor
    {
        public ThemeColor(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public string Name { get; }
        public string Color { get; }
    }
}
