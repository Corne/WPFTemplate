using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTemplate.Controls
{
    /// <summary>
    /// Interaction logic for BackButton.xaml
    /// </summary>
    public partial class NavigationButton : Button
    {
        public NavigationButton()
        {
            InitializeComponent();
        }

        public NavigationDirection Direction
        {
            get { return (NavigationDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Direction.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(NavigationDirection), typeof(NavigationButton), new PropertyMetadata(NavigationDirection.Back));




        //public ICommand Command
        //{
        //    get { return (ICommand)GetValue(CommandProperty); }
        //    set { SetValue(CommandProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CommandProperty =
        //    DependencyProperty.Register("Command", typeof(ICommand), typeof(NavigationButton));

    }

    public enum NavigationDirection
    {
        Back = -1,
        Forward = 1
    }
}
