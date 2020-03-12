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
using Scrosser.Models;

namespace Scrosser.Views
{
    /// <summary>
    /// HorizontalNavigator.xaml 的交互逻辑
    /// </summary>
    public partial class HorizontalNavigator : UserControl
    {
        public HorizontalNavigator()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ScrossProperty = DependencyProperty.Register(
            "Scross", typeof(Scross), typeof(HorizontalNavigator), new UIPropertyMetadata(new Scross()));

        public Scross Scross
        {
            get => (Scross)GetValue(ScrossProperty);
            set => SetValue(ScrossProperty, value);
        }

    }
}
