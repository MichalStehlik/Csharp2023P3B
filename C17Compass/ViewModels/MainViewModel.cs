using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C17Compass.ViewModels
{
    // https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device/sensors?view=net-maui-8.0&tabs=windows#compass
    // https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device/battery?view=net-maui-8.0&tabs=windows
    internal class MainViewModel : INotifyPropertyChanged
    {
        private double _north;

        public MainViewModel()
        {
            ToggleCompassCommand = new Command(
                () =>
                {
                    if (Supported)
                    {
                        if (Monitoring)
                        {
                            Compass.ReadingChanged += Compass_ReadingChanged;
                            Compass.Default.Start(SensorSpeed.Default);
                            Console.WriteLine("Start");
                        }
                        else
                        {
                            Compass.Default.Stop();
                            Compass.ReadingChanged -= Compass_ReadingChanged;
                            Console.WriteLine("Stop");
                        }
                        OnPropertyChanged(nameof(Monitoring));
                    }
                },
                () => Supported
                );
        }

        private void Compass_ReadingChanged( object sender, CompassChangedEventArgs e )
        {
            North = (Math.Round(e.Reading.HeadingMagneticNorth * 100)) / 100;
        }

        public ICommand ToggleCompassCommand { get; set; }

        public double North
        {
            get { return _north; }
            set
            {
                _north = value;
                OnPropertyChanged();
            }
        }

        public bool Supported
        {
            get { return Compass.IsSupported; }
        }

        public bool Monitoring
        {
            get { return Compass.IsMonitoring; }
        }

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
