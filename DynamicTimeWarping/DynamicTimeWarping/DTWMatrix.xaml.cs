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

namespace DynamicTimeWarping {
  public partial class DTWMatrix : UserControl {
    private const int rows = 30;
    private const int cols = 30;
    private Rectangle[,] cells = new Rectangle[rows, cols];


    public DTWMatrix() {
      InitializeComponent();
      InitBoard();
    }

    private void InitBoard() {
      SolidColorBrush fillBrush = new SolidColorBrush();
      fillBrush.Color = (Color)ColorConverter.ConvertFromString("#007700");
      SolidColorBrush strokeBrush = new SolidColorBrush();
      strokeBrush.Color = (Color)ColorConverter.ConvertFromString("#cccccc");

      for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
          cells[i, j] = new Rectangle();
          cells[i, j].Height = 15;
          cells[i, j].Width = 15;
          cells[i, j].Fill = fillBrush;
          cells[i, j].Stroke = strokeBrush;

          board.Children.Add(cells[i, j]);
          Grid.SetColumn(cells[i, j], j);
          Grid.SetRow(cells[i, j], 29 - i);
        }
      }
    }
  }
}
