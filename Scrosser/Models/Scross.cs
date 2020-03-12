using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Scrosser.Models
{

    /// <summary>
    /// Scross class.
    /// </summary>
    public class Scross : INotifyPropertyChanged
    {

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        private double _position;

        /// <summary>
        /// The position.
        /// Notice that this is scroll position and is not song position.
        /// </summary>
        public double Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }

        private double _total;

        /// <summary>
        /// The total length.
        /// </summary>
        public double Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabled;

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public double LargeChange => 100;

        public double SmallChange => 10;

        public double Minimum => 0;

        public double ZoomLargeChange => 1;

        public double ZoomSmallChange => 0.1;

        public double ZoomMinimum => 0.1;

        public double ZoomMaximum => 10;

        private double _zoom = 1;

        public double Zoom
        {
            get => _zoom;
            set
            {
                _zoom = value;
                OnPropertyChanged();
            }
        }

        private double _viewportSize = 0;

        public double ViewportSize
        {
            get => _viewportSize;
            set
            {
                _viewportSize = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Zoom in.
        /// </summary>
        /// <param name="large">Apply large change.</param>
        public void ZoomIn(bool large = false)
        {
            if (large)
            {
                if (Zoom + ZoomLargeChange <= ZoomMaximum)
                    Zoom += ZoomLargeChange;
                else Zoom = ZoomMaximum;
            }
            else
            {
                if (Zoom + ZoomSmallChange <= ZoomMaximum)
                    Zoom += ZoomSmallChange;
                else Zoom = ZoomMaximum;
            }
        }

        /// <summary>
        /// Zoom out.
        /// </summary>
        /// <param name="large">Apply large change.</param>
        public void ZoomOut(bool large = false)
        {
            if (large)
            {
                if (Zoom - ZoomLargeChange >= ZoomMinimum)
                    Zoom -= ZoomLargeChange;
                else Zoom = ZoomMinimum;
            }
            else
            {
                if (Zoom - ZoomSmallChange >= ZoomMinimum)
                    Zoom -= ZoomSmallChange;
                else Zoom = ZoomMinimum;
            }
        }

        /// <summary>
        /// Zoom to fit.
        /// </summary>
        public void ZoomToFit()
        {
            Zoom = 1;
        }

        /// <summary>
        /// Scroll for mouse wheel.
        /// </summary>
        /// <param name="positive">Scroll down/right.</param>
        /// <param name="large">Apply large change.</param>
        public void ScrollDelta(bool positive = true, bool large = false)
        {
            if (positive)
            {
                if (large)
                {
                    if (Position + LargeChange <= Total) Position += LargeChange;
                    else Position = Total;
                }
                else
                {
                    if (Position + SmallChange <= Total) Position += SmallChange;
                    else Position = Total;
                }
            }
            else
            {
                if (large)
                {
                    if (Position - LargeChange >= 0) Position -= LargeChange;
                    else Position = 0;
                }
                else
                {
                    if (Position - SmallChange >= 0) Position -= SmallChange;
                    else Position = 0;
                }
            }
        }

        #endregion

    }

}
