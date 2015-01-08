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
    /// Interaction logic for PatternEditor.xaml
    /// </summary>
    partial class PatternEditor : UserControl {
        #region Dependency Properties
        public static readonly DependencyProperty PatternProperty =
            DependencyProperty.Register("Pattern", typeof(Pattern), typeof(PatternEditor),
            new FrameworkPropertyMetadata());

        public static readonly DependencyProperty PrimaryCellProperty =
            DependencyProperty.Register("PrimaryCell", typeof(Cell), typeof(PatternEditor),
            new FrameworkPropertyMetadata(new Cell { Color = Colors.Black }));

        public static readonly DependencyProperty SecondaryCellProperty =
            DependencyProperty.Register("SecondaryCell", typeof(Cell), typeof(PatternEditor),
            new FrameworkPropertyMetadata(new Cell { Color = Colors.White }));

        private static readonly DependencyPropertyKey FillAreaPropertyKey =
            DependencyProperty.RegisterReadOnly("FillArea", typeof(SelectionArea), typeof(PatternEditor),
            new FrameworkPropertyMetadata());

        public static readonly DependencyProperty FillAreaProperty = FillAreaPropertyKey.DependencyProperty;

        private static readonly DependencyPropertyKey FillCellPropertyKey =
            DependencyProperty.RegisterReadOnly("FillCell", typeof(Cell), typeof(PatternEditor),
            new FrameworkPropertyMetadata());

        public static readonly DependencyProperty FillCellProperty = FillCellPropertyKey.DependencyProperty;
        #endregion

        #region Properties
        public Pattern Pattern {
            get { return (Pattern) GetValue(PatternProperty); }
            set { SetValue(PatternProperty, value); }
        }

        public Cell PrimaryCell {
            get { return (Cell) GetValue(PrimaryCellProperty); }
            set { SetValue(PrimaryCellProperty, value); }
        }

        public Cell SecondaryCell {
            get { return (Cell) GetValue(SecondaryCellProperty); }
            set { SetValue(SecondaryCellProperty, value); }
        }

        public SelectionArea FillArea {
            get { return (SelectionArea) GetValue(FillAreaProperty); }
            private set { SetValue(FillAreaPropertyKey, value); }
        }

        public Cell FillCell {
            get { return (Cell) GetValue(FillCellProperty); }
            private set { SetValue(FillCellPropertyKey, value); }
        }
        #endregion

        #region Static Constructor
        static PatternEditor() {
            BackgroundProperty.OverrideMetadata(typeof(PatternEditor),
                new FrameworkPropertyMetadata(new SolidColorBrush(Colors.LightGray)));
        }
        #endregion

        #region Constructor
        public PatternEditor() {
            InitializeComponent();
        }
        #endregion

        #region Method Overrides
        private MouseButton? _pressedButton;

        protected override void OnMouseDown(MouseButtonEventArgs e) {
            base.OnMouseDown(e);

            e.Handled = true;

            int x, y;
            if (!_pressedButton.HasValue && GetMouseCoords(e, out x, out y)) {
                if (e.ChangedButton == MouseButton.Left) {
                    FillCell = PrimaryCell;
                } else if (e.ChangedButton == MouseButton.Right) {
                    FillCell = SecondaryCell;
                } else {
                    return;
                }

                _pressedButton = e.ChangedButton;
                FillArea = new SelectionArea(x, y, x, y);

                CaptureMouse();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);

            int x, y;
            if (_pressedButton.HasValue && GetMouseCoords(e, out x, out y)) {
                if (x != FillArea.EndX || y != FillArea.EndY) {
                    FillArea = new SelectionArea(FillArea.StartX, FillArea.StartY, x, y);
                }
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e) {
            base.OnMouseUp(e);

            if (_pressedButton.HasValue && _pressedButton.Value == e.ChangedButton) {
                Fill(FillArea, FillCell);

                _pressedButton = null;
                FillArea = null;
                FillCell = null;

                ReleaseMouseCapture();
            }
        }
        #endregion

        #region Helper Methods
        private bool GetMouseCoords(MouseEventArgs e, out int x, out int y) {
            if (Pattern == null) {
                x = y = 0;
                return false;
            }

            Point position = e.GetPosition(this);
            x = (int) Math.Round(position.X / (Pattern.CellWidth + Pattern.CellSpacing));
            y = (int) Math.Round(position.Y / (Pattern.CellHeight + Pattern.CellSpacing));

            return x >= 0 && x < Pattern.Width && y >= 0 && y < Pattern.Height;
        }

        private void Fill(SelectionArea area, Cell cell) {
            if (Pattern != null) {
                for (int y = 0; y < area.Height; y++) {
                    for (int x = 0; x < area.Width; x++) {
                        Pattern[x + area.Left, y + area.Top].CopyFrom(cell);
                    }
                }
            }
        }
        #endregion
    }
}
