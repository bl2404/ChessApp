using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
    /// Interaction logic for Figure.xaml
    /// </summary>
    public partial class Figure : UserControl
    {
        private readonly string whiteRookPath="Icons\\white_rook.png";
        private readonly string blackRookPath = "Icons\\black.png";
        private readonly string whiteKingPath = "Icons\\white_king.png";
        private readonly string blackKingPath = "Icons\\black_king.png";
        public Figure(IFigure figure)
        {
            InitializeComponent();
            SetBrush(figure);
            DataContext = new FigureViewModel(figure);
        }

        public void SetBrush(IFigure figure)
        {
            string figurePath = string.Empty;
            switch (figure.Color)
            {
                case Chess.Color.White:
                    if (figure is King)
                        figurePath = whiteKingPath;
                    else
                        figurePath = whiteRookPath;
                    break;
                case Chess.Color.Black:
                    if (figure is King)
                        figurePath = blackKingPath;
                    else
                        figurePath = blackRookPath;
                    break;
            }
            var imageBrush = new ImageBrush();
            string path = System.IO.Path.Combine(Environment.CurrentDirectory,figurePath);
            imageBrush.ImageSource = new BitmapImage(new Uri(path));
            FigureRectangle.Fill = imageBrush;
        }
    }
}
