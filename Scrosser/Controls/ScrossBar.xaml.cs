using System.Windows;
using System.Windows.Controls;
using Scrosser.Models;

namespace Scrosser.Controls
{
    /// <summary>
    /// ScrossBar.xaml 的交互逻辑
    /// </summary>
    public partial class ScrossBar : UserControl
    {
        public ScrossBar()
        {
            InitializeComponent();

            DataContext = this;
        }

        public static readonly DependencyProperty ScrossProperty = DependencyProperty.Register(
            "Scross", typeof(Scross), typeof(ScrossBar), new PropertyMetadata(new Scross()));

        /// <summary>
        /// The scross data.
        /// </summary>
        public Scross Scross
        {
            get => (Scross) GetValue(ScrossProperty);
            set => SetValue(ScrossProperty, value);
        }

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
            "Orientation", typeof(Orientation), typeof(ScrossBar), new PropertyMetadata(Orientation.Vertical));

        /// <summary>
        /// The orientation.
        /// </summary>
        public Orientation Orientation
        {
            get => (Orientation) GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

    }
}
