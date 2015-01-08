using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatternMaker.Model {
    abstract class ModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected void NotifyPropertyChanged<T>(Expression<Func<T>> expr) {
            MemberExpression memberExpr = (MemberExpression) expr.Body;
            OnPropertyChanged(new PropertyChangedEventArgs(memberExpr.Member.Name));
        }
    }
}
