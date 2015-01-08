using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PatternMaker.Controls {
    class SpacingToBorderThicknessConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            double? spacing = value as double?;
            if (!spacing.HasValue)
                throw new ArgumentException("Value must be a double", "value");

            return new Thickness(spacing.Value / 2.0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
