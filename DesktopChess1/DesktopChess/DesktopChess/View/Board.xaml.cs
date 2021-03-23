using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using DesktopChess.ViewModel;

namespace DesktopChess.View
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        public Board()
        {
            InitializeComponent();
            DataContext = new GameViewModel();
            foreach (var item in ((GameViewModel)DataContext).Model.Figures)
            {
                FrameworkElement gridItem = new Figure(item);
                gridItem.SetValue(Grid.ColumnProperty, (int)item.Field.Horizontal);
                gridItem.SetValue(Grid.RowProperty, 8-(int)item.Field.Vertical);
                gridItem.MouseMove += Figure_MouseMove;
                gridItem.MouseLeftButtonDown += Figure_MouseLeftButtonDown_1;
                gridItem.MouseLeftButtonUp += Figure_MouseLeftButtonUp;
                BoardGrid.Children.Add(gridItem);
            }
        }

        private Point _anchorPoint;
        private Point _currentPoint;
        private bool _isInDrag;
        private TranslateTransform _transform;

        private void Figure_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isInDrag) return;
            _currentPoint = e.GetPosition(null);

            _transform.X += _currentPoint.X - _anchorPoint.X;
            _transform.Y += (_currentPoint.Y - _anchorPoint.Y);

            var element = sender as FrameworkElement;
            element.RenderTransform = _transform;
            _anchorPoint = _currentPoint;
        }

        private void Figure_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            _transform = new TranslateTransform();
            var element = sender as FrameworkElement;

            _anchorPoint = e.GetPosition(null);
            if (element != null) element.CaptureMouse();
            _isInDrag = true;
            e.Handled = true;
        }

        private void Figure_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!_isInDrag) return;
            var element = sender as FrameworkElement;

            if (element != null) element.ReleaseMouseCapture();
            _isInDrag = false;
            e.Handled = true;
            var grid = (Grid)element.Parent;
            grid.Children.Remove(element);
            Rectangle targetField = VisualTreeHelper.HitTest(this, e.GetPosition(this)).VisualHit as Rectangle;
            int column = (int)targetField.GetValue(Grid.ColumnProperty);
            int row = (int)targetField.GetValue(Grid.RowProperty);

            element.SetValue(Grid.ColumnProperty, column);
            element.SetValue(Grid.RowProperty, row);
            element.RenderTransform = null;

            grid.Children.Add(element);
        }
    }
}
