using PatternMaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PatternMaker.ViewModel.Design {
    class MainViewModel : ModelBase, IMainViewModel {
        private readonly Pattern _pattern;

        public Pattern Pattern {
            get { return _pattern; }
        }

        public MainViewModel() {
            _pattern = new Pattern(3, 3);
            _pattern[0, 0].Color = Colors.Red;
            _pattern[0, 1].Color = Colors.Green;
            _pattern[0, 2].Color = Colors.Blue;
            _pattern[1, 0].Color = Colors.Pink;
            _pattern[1, 1].Color = Colors.Orange;
            _pattern[1, 2].Color = Colors.Yellow;
            _pattern[2, 0].Color = Colors.Cyan;
            _pattern[2, 1].Color = Colors.Black;
            _pattern[2, 2].Color = Colors.MediumOrchid;
        }
    }
}
