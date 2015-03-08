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
    private Rectangle[,] cells;
    private int signalLength;

    public DTWMatrix() {
      InitializeComponent();
    }

    public void InitializeBoard(int signalLength) {
      this.signalLength = signalLength;
      cells = new Rectangle[signalLength, signalLength];

      SolidColorBrush fillBrush = new SolidColorBrush();
      fillBrush.Color = (Color)ColorConverter.ConvertFromString("#007700");
      SolidColorBrush strokeBrush = new SolidColorBrush();
      strokeBrush.Color = (Color)ColorConverter.ConvertFromString("#cccccc");

      // the grid should be changed in order to adapt more than 30 rows and cols
      for (int i = 0; i < signalLength; i++) {
        for (int j = 0; j < signalLength; j++) {
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

    private void CleanBoard() {
      SolidColorBrush fillBrush = new SolidColorBrush();
      fillBrush.Color = (Color)ColorConverter.ConvertFromString("#007700");

      for (int i = 0; i < signalLength; i++) {
        for (int j = 0; j < signalLength; j++) {
          cells[i, j].Fill = fillBrush;
        }
      }
    }

    public void UpdateBoard(double[,] matrix) {
      CleanBoard();

      for (int i = 0; i < signalLength; i++) {
        for (int j = 0; j < signalLength; j++) {
          cells[i, j].Opacity = matrix[i, j];
        }
      }
    }

    public void ShowPath(List<Tuple<int, int>> path) {
      SolidColorBrush pathBrush = new SolidColorBrush();
      pathBrush.Color = (Color)ColorConverter.ConvertFromString("#DD0000");
      foreach (Tuple<int, int> elem in path) {
        cells[elem.Item1, elem.Item2].Fill = pathBrush;
        cells[elem.Item1, elem.Item2].Opacity = 1;
      }
    }

  }
}
