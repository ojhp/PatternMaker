using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PatternMaker.ViewModel {
    class ViewModelModule : NinjectModule {
        public override void Load() {
            bool isDesign = DesignerProperties.GetIsInDesignMode(new DependencyObject());

            if (isDesign) {
                Bind<IMainViewModel>().To<Design.MainViewModel>();
            } else {
                Bind<IMainViewModel>().To<Default.MainViewModel>();
            }
        }
    }
}
