﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scrosser.Models
{

    /// <summary>
    /// Position definition.
    /// </summary>
    public class Posit : INotifyPropertyChanged
    {

        public Posit(
            int total = 0,
            int position = 0)
        {
            _position = position;
            _total = total;
        }

        #region DataContext

        /// <summary>
        /// Start position. Always 0.
        /// Define a new class inherit from Posit if you want to redefine start position.
        /// </summary>
        public double Start => 0;

        private int _position;

        public int Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }

        private int _total;

        public int Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Get the position in the viewer.
        /// </summary>
        /// <param name="scross">The horizontal scross.</param>
        /// <param name="actualLength">The actual length of the viewer.</param>
        /// <returns>The visibility and the Margin.Left.</returns>
        public (Visibility, double) GetPosition(Scross scross, double actualLength)
        {
            double x = actualLength / 2 - (scross.Position - Position) * scross.Zoom;
            if (x >= 0 && x < actualLength) return (Visibility.Visible, x);
            return (Visibility.Collapsed, 0);
        }

        /// <summary>
        /// Get the scross position from the position in the viewer.
        /// </summary>
        /// <param name="x">The position in the viewer.</param>
        /// <param name="scross">The scross.</param>
        /// <param name="actualLength">The actual length of the viewer.</param>
        /// <param name="total">The total of the posit.</param>
        /// <returns>The new Posit instance.</returns>
        public static Posit GetPositFromViewer(double x, Scross scross, double actualLength, int total)
        {
            int p = (int)Math.Floor(scross.Position - (actualLength / 2 - x) / scross.Zoom);
            if (p <= 0 || p > total) p = 0;
            return new Posit(total, p);
        }

        /// <summary>
        /// Get the value from the position in the viewer.
        /// </summary>
        /// <param name="x">The position in the viewer.</param>
        /// <param name="scross">The scross.</param>
        /// <param name="actualLength">The actual length of the viewer.</param>
        /// <param name="total">The total of the posit.</param>
        /// <returns>The new value.</returns>
        public static double GetValueFromViewer(double x, Scross scross, double actualLength, double total)
        {
            double p = scross.Position - (actualLength / 2 - x) / scross.Zoom;
            if (p <= 0 || p > total) p = 0;
            return p;
        }

        #endregion

    }

}
