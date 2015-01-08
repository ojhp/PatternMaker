using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMaker.Model {
    class CellInfo : ModelBase {
        private int _x, _y;
        private Cell _cell;

        public int X {
            get { return _x; }
            set {
                _x = value;
                NotifyPropertyChanged(() => X);
            }
        }

        public int Y {
            get { return _y; }
            set {
                _y = value;
                NotifyPropertyChanged(() => Y);
            }
        }

        public Cell Cell {
            get { return _cell; }
            set {
                _cell = value;
                NotifyPropertyChanged(() => Cell);
            }
        }

        public CellInfo(int x, int y, Cell cell) {
            _x = x;
            _y = y;
            _cell = cell;
        }
    }
}
