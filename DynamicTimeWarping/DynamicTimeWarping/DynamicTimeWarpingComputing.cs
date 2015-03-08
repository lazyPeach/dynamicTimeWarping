using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicTimeWarping
{
  class DynamicTimeWarpingComputing
  {
    private int signalLength, rows, cols;
    private LinkedList<double> dynamicSignal = new LinkedList<double>();
    private LinkedList<double> staticSignal = new LinkedList<double>();

    public DynamicTimeWarpingComputing(int signalLength)
    {
      this.signalLength = signalLength;
      rows = signalLength;
      cols = signalLength;
      InitSignals();
      //InitDynamicSignal();
      //InitStaticSignal();
    }

    private void InitSignals()
    {
      Random rnd = new Random();

      for (int i = 0; i < signalLength; i++)
      {
        double sample = rnd.NextDouble() * 9 + 1; // in order to have a signal between 1 and 10
        dynamicSignal.AddLast(sample);
        staticSignal.AddLast(sample);
      }
    }

    public LinkedList<double> GetDynamicSignal()
    {
      return dynamicSignal;
    }

    public LinkedList<double> GetStaticSignal()
    {
      return staticSignal;
    }

    public void InsertSample()
    {
      dynamicSignal.RemoveLast();
      Random rnd = new Random();
      dynamicSignal.AddFirst(rnd.NextDouble() * 9 + 1);
    }

    private void InitDynamicSignal()
    {
      dynamicSignal.AddLast(1.2);
      dynamicSignal.AddLast(2.8);
      dynamicSignal.AddLast(3.1);
      dynamicSignal.AddLast(3.4);
      dynamicSignal.AddLast(4.0);
      dynamicSignal.AddLast(1.9);
      dynamicSignal.AddLast(5.8);
      dynamicSignal.AddLast(6.4);
      dynamicSignal.AddLast(8.9);
      dynamicSignal.AddLast(9.8);

      dynamicSignal.AddLast(8.7);
      dynamicSignal.AddLast(8.2);
      dynamicSignal.AddLast(6.1);
      dynamicSignal.AddLast(2.4);
      dynamicSignal.AddLast(2.6);
      dynamicSignal.AddLast(2.8);
      dynamicSignal.AddLast(3.5);
      dynamicSignal.AddLast(4.1);
      dynamicSignal.AddLast(1.2);
      dynamicSignal.AddLast(4.9);

      dynamicSignal.AddLast(5.3);
      dynamicSignal.AddLast(5.9);
      dynamicSignal.AddLast(6.4);
      dynamicSignal.AddLast(6.9);
      dynamicSignal.AddLast(7.5);
      dynamicSignal.AddLast(8.0);
      dynamicSignal.AddLast(7.8);
      dynamicSignal.AddLast(6.1);
      dynamicSignal.AddLast(8.9);
      dynamicSignal.AddLast(9.7);
    }

    private void InitStaticSignal()
    {
      staticSignal.AddLast(1.2);
      staticSignal.AddLast(2.8);
      staticSignal.AddLast(3.1);
      staticSignal.AddLast(3.4);
      staticSignal.AddLast(4.0);
      staticSignal.AddLast(1.9);
      staticSignal.AddLast(5.8);
      staticSignal.AddLast(6.4);
      staticSignal.AddLast(8.9);
      staticSignal.AddLast(9.8);

      staticSignal.AddLast(8.7);
      staticSignal.AddLast(8.2);
      staticSignal.AddLast(6.1);
      staticSignal.AddLast(2.4);
      staticSignal.AddLast(2.6);
      staticSignal.AddLast(2.8);
      staticSignal.AddLast(3.5);
      staticSignal.AddLast(4.1);
      staticSignal.AddLast(1.2);
      staticSignal.AddLast(4.9);

      staticSignal.AddLast(5.3);
      staticSignal.AddLast(5.9);
      staticSignal.AddLast(6.4);
      staticSignal.AddLast(6.9);
      staticSignal.AddLast(7.5);
      staticSignal.AddLast(8.0);
      staticSignal.AddLast(7.8);
      staticSignal.AddLast(6.1);
      staticSignal.AddLast(8.9);
      staticSignal.AddLast(9.7);
    }
  }
}
