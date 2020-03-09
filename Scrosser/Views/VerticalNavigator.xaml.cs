using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// VerticalNavigator.xaml 的交互逻辑
    /// </summary>
    public partial class VerticalNavigator : UserControl
    {
        public VerticalNavigator()
        {
            InitializeComponent();

            DataContext = this;
        }

        public static readonly DependencyProperty ScrossProperty = DependencyProperty.Register(
            "Scross", typeof(Scross), typeof(VerticalNavigator), new PropertyMetadata(new Scross()));

        public Scross Scross
        {
            get => (Scross) GetValue(ScrossProperty);
            set => SetValue(ScrossProperty, value);
        }

    }
}
