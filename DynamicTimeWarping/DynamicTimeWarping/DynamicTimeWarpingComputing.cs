using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicTimeWarping {
  class DynamicTimeWarpingComputing {
    private int signalLength, rows, cols;
    private LinkedList<double> dynamicSignal = new LinkedList<double>();
    private LinkedList<double> staticSignal = new LinkedList<double>();
    private double[,] DTWMatrix;
    private double DTWCost;

    public DynamicTimeWarpingComputing(int signalLength) {
      this.signalLength = signalLength;
      rows = signalLength;
      cols = signalLength;
      DTWMatrix = new double[signalLength, signalLength]; 
      InitSignals();
    }

    public LinkedList<double> GetDynamicSignal() {
      return dynamicSignal;
    }

    public LinkedList<double> GetStaticSignal() {
      return staticSignal;
    }

    public double GetDTWCost() {
      return DTWCost;
    }

    public double[,] GetDTWMatrix() {
      return DTWMatrix;
    }

    public void InsertSample() {
      dynamicSignal.RemoveLast();
      Random rnd = new Random();
      dynamicSignal.AddFirst(rnd.NextDouble() * 9 + 1);
    }

    public void ComputeDTWMatrix() {
      //double[,] differenceMatrix = new double[signalLength, signalLength];
      double max = 0;

      // compute the signal difference matrix and get the maximum value of it
      for (int i = 0; i < signalLength; i++) {
        for (int j = 0; j < signalLength; j++) {
          DTWMatrix[i, j] = Math.Abs(staticSignal.ElementAt(i) - dynamicSignal.ElementAt(j));

          if (DTWMatrix[i, j] > max) max = DTWMatrix[i, j];
        }
      }

      // normalize matrix -> make all values between 1 and 0
      for (int i = 0; i < signalLength; i++) {
        for (int j = 0; j < signalLength; j++) {
          DTWMatrix[i, j] /= max;
        }
      }

      
      // make a copy matrix with infinity on row 0 and col 0
      double[,] copyMatrix = new double[signalLength + 1, signalLength + 1];
      // init elements on row 0 and col 0 to 1.1 (a value grater than others in the matrix)
      for (int i = 0; i < signalLength + 1; i++)
        copyMatrix[i, 0] = 1.1;

      for (int j = 0; j < signalLength + 1; j++)
        copyMatrix[0, j] = 1.1;

      // copy difference matrix into the dtw one
      for (int i = 1; i < signalLength + 1; i++) {
        for (int j = 1; j < signalLength + 1; j++) {
          copyMatrix[i, j] = DTWMatrix[i - 1, j - 1];
        }
      }

      dtwPath.Clear();
      DTWCost = GetDTWCost(copyMatrix, signalLength, signalLength);
    }

    // keep elements that compose the dtw path
    private List<Tuple<int, int>> dtwPath = new List<Tuple<int, int>>();

    public List<Tuple<int, int>> GetDTWPath() {
      return dtwPath;
    }

    // recursively compute the DTW cost - greedy solution
    private double GetDTWCost(double[,] mat, int i, int j) {
      if (i == 0 && j == 0)
        return 0;

      int minI, minJ;
      if (mat[i - 1, j] < mat[i - 1, j - 1] && mat[i - 1, j] < mat[i, j - 1]) {
        minI = i - 1;
        minJ = j;
      } else if (mat[i, j - 1] < mat[i - 1, j - 1] && mat[i, j - 1] < mat[i - 1, j]) {
        minI = i;
        minJ = j - 1;
      } else {
        minI = i - 1;
        minJ = j - 1;
      }

      Tuple<int, int> elem = new Tuple<int, int>(i - 1, j - 1);
      dtwPath.Add(elem);

      double cost = mat[i, j] + GetDTWCost(mat, minI, minJ);

      return cost;
    }

    private void InitSignals() {
      Random rnd = new Random();

      for (int i = 0; i < signalLength; i++) {
        double sample = rnd.NextDouble() * 9 + 1; // in order to have a signal between 1 and 10
        dynamicSignal.AddLast(sample);
        staticSignal.AddLast(sample);
      }
    }
  }
}
