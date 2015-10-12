using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTemplate.Services.Themes
{
    public class AccentColor
    {
        public AccentColor(string name, string color)
        {
            Name = name;
            Color = color;
        }


        public string Name { get; }
        public string Color { get; }
    }
}
