using System;
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
    /// <typeparam name="T">The type of the posit.</typeparam>
    public class Posit<T> : INotifyPropertyChanged
    {

        public Posit(
            T total,
            T position,
            T start)
        {
            _position = position;
            _total = total;
            Start = start;
        }

        #region DataContext

        /// <summary>
        /// Start position. Always 0.
        /// Define a new class inherit from Posit if you want to redefine start position.
        /// </summary>
        public T Start { get; }

        private T _position;

        public T Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }

        private T _total;

        public T Total
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
        /// Get the horizontal position in the viewer.
        /// </summary>
        /// <param name="scross">The horizontal scross.</param>
        /// <param name="actualWidth">The actual width of the viewer.</param>
        /// <param name="minus">Minus double and T.</param>
        /// <returns>The visibility and the Margin.Left.</returns>
        public (Visibility, double) GetHorizontalPosition(Scross scross, double actualWidth, Func<double, T, double> minus)
        {
            double x = actualWidth / 2 - minus(scross.Position, Position) * scross.Zoom;
            if (x >= 0 && x < actualWidth) return (Visibility.Visible, x);
            return (Visibility.Collapsed, 0);
        }

        /// <summary>
        /// Get the vertical position in the viewer.
        /// </summary>
        /// <param name="scross">The horizontal scross.</param>
        /// <param name="actualHeight">The actual height of the viewer.</param>
        /// <param name="minus">Minus double and T.</param>
        /// <returns>The visibility and the Margin.Left.</returns>
        public (Visibility, double) GetVertitalPosition(Scross scross, double actualHeight, Func<double, T, double> minus)
        {
            double x = actualHeight / 2 + minus(scross.Total - scross.Position, Position) * scross.Zoom;
            if (x >= 0 && x < actualHeight) return (Visibility.Visible, x);
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
        public static Posit<int> GetPositFromViewer(double x, Scross scross, double actualLength, int total)
        {
            int p = (int)Math.Floor(scross.Position - (actualLength / 2 - x) / scross.Zoom);
            if (p <= 0 || p > total) p = 0;
            return new Posit<int>(total, p, 0);
        }

        /// <summary>
        /// Get the value from the position in the viewer.
        /// </summary>
        /// <param name="x">The position in the viewer.</param>
        /// <param name="scross">The scross.</param>
        /// <param name="actualLength">The actual length of the viewer.</param>
        /// <param name="total">The total of the posit.</param>
        /// <returns>The new posit.</returns>
        public static Posit<double> GetValueFromViewer(double x, Scross scross, double actualLength, double total)
        {
            double p = scross.Total - scross.Position - (actualLength / 2 - x) / scross.Zoom;
            if (p <= 0 || p > total) p = 0;
            return new Posit<double>(total, p, 0);
        }

        #endregion

    }

}
