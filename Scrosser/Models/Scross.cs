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

        #endregion

        public double LargeChange => 1;

        public double SmallChange => 0.1;

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

    }

}
