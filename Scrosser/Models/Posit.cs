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
            long total = 0,
            long position = 0)
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

        private long _position;

        public long Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }

        private long _total;

        public long Total
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
        /// <param name="actualWidth">The actual width of the viewer.</param>
        /// <returns>The visibility and the Margin.Left.</returns>
        public (Visibility, double) GetPosition(Scross scross, double actualWidth)
        {
            double x = actualWidth / 2 - (Position - scross.Position) * scross.Zoom;
            if (x >= 0 && x < actualWidth) return (Visibility.Visible, x);
            return (Visibility.Collapsed, 0);
        }

        #endregion

    }

}
