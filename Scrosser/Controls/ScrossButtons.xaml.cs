﻿using System;
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

namespace Scrosser.Controls
{
    /// <summary>
    /// ScrossButtons.xaml 的交互逻辑
    /// </summary>
    public partial class ScrossButtons : UserControl
    {
        public ScrossButtons()
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
            get => (Scross)GetValue(ScrossProperty);
            set => SetValue(ScrossProperty, value);
        }

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
            "Orientation", typeof(Orientation), typeof(ScrossBar), new PropertyMetadata(Orientation.Vertical));

        /// <summary>
        /// The orientation.
        /// </summary>
        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

    }
}
