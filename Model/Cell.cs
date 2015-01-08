using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PatternMaker.Model {
    class Cell : ModelBase {
        private Color _color = Colors.White;

        public Color Color {
            get { return _color; }
            set {
                _color = value;
                NotifyPropertyChanged(() => Color);
            }
        }

        public void CopyFrom(Cell other) {
            Color = other.Color;
        }
    }
}
