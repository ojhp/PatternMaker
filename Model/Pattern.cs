using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMaker.Model {
    class Pattern : ModelBase {
        private int _width, _height;
        private double _cellWidth, _cellHeight, _cellSpacing;
        private Cell[] _cells;

        public int Width {
            get { return _width; }
            set { Resize(value, _height); }
        }

        public int Height {
            get { return _height; }
            set { Resize(_width, value); }
        }

        public double CellWidth {
            get { return _cellWidth; }
            set {
                _cellWidth = value;
                NotifyPropertyChanged(() => CellWidth);
            }
        }

        public double CellHeight {
            get { return _cellHeight; }
            set {
                _cellHeight = value;
                NotifyPropertyChanged(() => CellHeight);
            }
        }

        public double CellSpacing {
            get { return _cellSpacing; }
            set {
                _cellSpacing = value;
                NotifyPropertyChanged(() => CellSpacing);
            }
        }

        public IEnumerable<CellInfo> Cells {
            get {
                for (int y = 0; y < _height; y++) {
                    for (int x = 0; x < _width; x++) {
                        yield return new CellInfo(x, y, _cells[x + (y * _width)]);
                    }
                }
            }
        }

        public Cell this[int x, int y] {
            get {
                if (x < 0 || x >= _width || y < 0 || y >= _height)
                    throw new IndexOutOfRangeException();

                return _cells[x + (y * _width)];
            }
        }

        public Pattern(int width, int height) {
            if (width <= 0)
                throw new ArgumentException("Width must be greater than zero", "width");
            if (height <= 0)
                throw new ArgumentException("Height must be greater than zero", "height");

            _width = width;
            _height = height;
            _cellWidth = 20.0;
            _cellHeight = 20.0;
            _cellSpacing = 2.0;

            _cells = new Cell[width * height];
            for (int i = 0; i < _cells.Length; i++) {
                _cells[i] = new Cell();
            }
        }

        public void Resize(int width, int height) {
            if (width <= 0)
                throw new ArgumentException("Width must be greater than zero", "width");
            if (height <= 0)
                throw new ArgumentException("Height must be greater than zero", "height");

            Cell[] cells = new Cell[width * height];

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    if (x < _width && y < _height) {
                        cells[x + (y * width)] = _cells[x + (y * _width)];
                    } else {
                        cells[x + (y * width)] = new Cell();
                    }
                }
            }

            _width = width;
            _height = height;
            _cells = cells;

            NotifyPropertyChanged(() => Width);
            NotifyPropertyChanged(() => Height);
            NotifyPropertyChanged(() => Cells);
        }
    }
}
