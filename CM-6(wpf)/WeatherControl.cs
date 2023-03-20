using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CM_6_wpf_
{ 
    enum Precipitation
        {
            sunny,
            cloudy,
            rain,
            snow
        }
    class WeatherControl : DependencyObject
    {
        private string wind_direction;
        private int wind_speed;
        private Precipitation precipitation;
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public WeatherControl(string winddir, int windsp, Precipitation precipitation)
        {
            this.WindDirection = winddir;
            this.WindSpeed = windsp;
            this.precipitation = precipitation;
        }
        public static readonly DependencyProperty TempProperty;
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault |
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));

        }

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }
    }
}


