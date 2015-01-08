using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMaker.ViewModel {
    class ViewModelLocator {
        private readonly IKernel _kernel;

        public IMainViewModel Main {
            get { return _kernel.Get<IMainViewModel>(); }
        }

        public ViewModelLocator() {
            _kernel = new StandardKernel(new ViewModelModule());
        }
    }
}
