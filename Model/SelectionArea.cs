using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMaker.Model {
    class SelectionArea : ModelBase {
        private readonly int _startX, _startY, _endX, _endY;

        public int StartX {
            get { return _startX; }
        }

        public int StartY {
            get { return _startY; }
        }

        public int EndX {
            get { return _endX; }
        }

        public int EndY {
            get { return _endY; }
        }

        public int Top {
            get { return Math.Min(StartY, EndY); }
        }

        public int Left {
            get { return Math.Min(StartX, EndX); }
        }

        public int Width {
            get { return Math.Abs(StartX - EndX) + 1; }
        }

        public int Height {
            get { return Math.Abs(StartY - EndY) + 1; }
        }

        public SelectionArea(int startX, int startY, int endX, int endY) {
            _startX = startX;
            _startY = startY;
            _endX = endX;
            _endY = endY;
        }

        public bool ContainsPoint(int x, int y) {
            x -= Left;
            y -= Top;

            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}
