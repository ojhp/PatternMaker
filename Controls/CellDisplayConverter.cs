using PatternMaker.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PatternMaker.Controls {
    class CellDisplayConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            CellInfo cell = values[0] as CellInfo;
            SelectionArea area = values[1] as SelectionArea;
            Cell fillCell = values[2] as Cell;

            if (cell == null)
                throw new ArgumentException("The first value must be a cell info object", "values");
            if (area != null && fillCell == null)
                throw new ArgumentException("The third value must be a cell if the second is non-null", "values");

            if (area != null && area.ContainsPoint(cell.X, cell.Y)) {
                return fillCell;
            } else {
                return cell.Cell;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
