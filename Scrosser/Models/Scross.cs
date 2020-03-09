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

        private double _horizontalZoom = 1;

        /// <summary>
        /// Horizontal zoom.
        /// </summary>
        public double HorizontalZoom
        {
            get => _horizontalZoom;
            set
            {
                _horizontalZoom = value;
                OnPropertyChanged();
            }
        }

        private double _verticalZoom = 1;

        /// <summary>
        /// Vertical zoom.
        /// </summary>
        public double VerticalZoom
        {
            get => _verticalZoom;
            set
            {
                _verticalZoom = value;
                OnPropertyChanged();
            }
        }

        private double _horizontalScroll;

        /// <summary>
        /// Horizontal scroll.
        /// </summary>
        public double HorizontalScroll
        {
            get => _horizontalScroll;
            set
            {
                _horizontalScroll = value;
                OnPropertyChanged();
            }
        }

        private double _verticalScroll;

        /// <summary>
        /// Vertical scroll.
        /// </summary>
        public double VerticalScroll
        {
            get => _verticalScroll;
            set
            {
                _verticalScroll = value;
                OnPropertyChanged();
            }
        }

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
                OnPropertyChanged(nameof(Value));
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
                OnPropertyChanged(nameof(Maximum));
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

        public double Maximum
        {
            get => Total;
            set => Total = value;
        }

        public double Minimum => 0;

        public double Value
        {
            get => Position;
            set => Position = value;
        }

    }

}
