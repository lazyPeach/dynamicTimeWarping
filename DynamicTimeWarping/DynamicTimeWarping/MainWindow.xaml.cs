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

  public partial class MainWindow : Window {
    private DynamicTimeWarpingComputing dynamicTimeWarping;
    private int signalLength = 30;

    public MainWindow() {
      InitializeComponent();

      Board.InitializeBoard(signalLength);
      dynamicTimeWarping = new DynamicTimeWarpingComputing(signalLength);

      PlotDynamicSignal();
      PlotStaticSignal();
    }

    private void PlotDynamicSignal() {
      LinkedList<double> dynamicSignal = dynamicTimeWarping.GetDynamicSignal();
      List<KeyValuePair<int, double>> dynamicValues = new List<KeyValuePair<int, double>>();
      int index = 0;

      foreach (double val in dynamicSignal) {
        dynamicValues.Add(new KeyValuePair<int, double>(index++, val));
      }

      dynamicSeries.DataContext = dynamicValues;
    }

    private void PlotStaticSignal() {
      LinkedList<double> staticSignal = dynamicTimeWarping.GetStaticSignal();
      List<KeyValuePair<int, double>> staticValues = new List<KeyValuePair<int, double>>();
      int index = 0;

      foreach (double val in staticSignal) {
        staticValues.Add(new KeyValuePair<int, double>(index++, val));
      }

      staticSeries.DataContext = staticValues;
    }

    private void DTWBtn_Click(object sender, RoutedEventArgs e) {
      dynamicTimeWarping.ComputeDTWMatrix();
      Board.UpdateBoard(dynamicTimeWarping.GetDTWMatrix());
      Result.Content = dynamicTimeWarping.GetDTWCost().ToString();
    }

    private void showPathBtn_Click(object sender, RoutedEventArgs e) {
      Board.ShowPath(dynamicTimeWarping.GetDTWPath());
    }

    private void insertSampleBtn_Click(object sender, RoutedEventArgs e) {
      dynamicTimeWarping.InsertSample();
      PlotDynamicSignal();
    }
  }
}
