using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using Scrosser.Models;

namespace Scrosser.Controls
{
    public class ScrossBar : ScrollBar
    {

        public static readonly DependencyProperty ScrossProperty = DependencyProperty.Register(
            "Scross", typeof(Scross), typeof(ScrossViewer), new PropertyMetadata(default(Scross)));

        /// <summary>
        /// The scross data. Remember to use "TwoWay" mode.
        /// </summary>
        public Scross Scross
        {
            get { return (Scross)GetValue(ScrossProperty); }
            set { SetValue(ScrossProperty, value); }
        }

    }
}
