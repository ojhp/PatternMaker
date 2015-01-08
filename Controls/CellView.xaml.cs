using PatternMaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PatternMaker.Controls {
    /// <summary>
    /// Interaction logic for CellView.xaml
    /// </summary>
    partial class CellView : UserControl {
        public static readonly DependencyProperty CellProperty =
            DependencyProperty.Register("Cell", typeof(Cell), typeof(CellView),
            new FrameworkPropertyMetadata());

        public Cell Cell {
            get { return (Cell) GetValue(CellProperty); }
            set { SetValue(CellProperty, value); }
        }

        public CellView() {
            InitializeComponent();
        }
    }
}
