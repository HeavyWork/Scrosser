using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Scrosser.Models;

namespace Scrosser.Controls
{

    /// <summary>
    /// The scross viewer.
    /// </summary>
    public class ScrossViewer : ScrollViewer
    {

        public static readonly DependencyProperty ScrossProperty = DependencyProperty.Register(
            "Scross", typeof(Scross), typeof(ScrossViewer), new PropertyMetadata(default(Scross)));

        /// <summary>
        /// The scross data. Remember to use "OneWay" mode.
        /// </summary>
        public Scross Scross
        {
            get { return (Scross) GetValue(ScrossProperty); }
            set { SetValue(ScrossProperty, value); }
        }

    }

}
