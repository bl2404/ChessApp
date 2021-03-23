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
using Chess;
using DesktopChess.ViewModel;

namespace DesktopChess.View
{
    /// <summary>
    /// Interaction logic for WhiteKing.xaml
    /// </summary>
    public partial class WhiteKing : UserControl
    {
        public WhiteKing(IFigure figure)
        {
            InitializeComponent();
            DataContext = new FigureViewModel(figure);
        }
    }
}
