using PatternMaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMaker.ViewModel.Default {
    class MainViewModel : ModelBase, IMainViewModel {
        private Pattern _pattern;

        public Pattern Pattern {
            get { return _pattern; }
            set {
                _pattern = value;
                NotifyPropertyChanged(() => Pattern);
            }
        }

        public MainViewModel() {
            _pattern = new Pattern(10, 10);
        }
    }
}
