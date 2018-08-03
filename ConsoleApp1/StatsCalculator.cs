using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class StatsCalculator
    {
        private static int size;
        private static double average;
        private static double sum;
        private static Queue<int> streamElements;
        private static MaxHeap maxHeap;


        public StatsCalculator(int window_size)
        {
            if (window_size <= 0) throw new InvalidOperationException("no window to do calculations");

            size = window_size;
            streamElements = new Queue<int>(size);
            maxHeap = new MaxHeap(size);
        }

        public void GetRollingStats(int n, out double avg, out int max)
        {
            avg = GetRollingAverage(n);
            max = GetRollingMaximum(n);
        }

        /// <summary>
        /// To get the avg maintain a Queue
        /// and do the avg when reaches size limit
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private double GetRollingAverage(int n)
        {
            sum += n;

            streamElements.Enqueue(n);

            if(streamElements.Count > size)
            {
                sum -= streamElements.Dequeue();
            }

            if(streamElements.Count >= size)
            {
                return average = sum / size;
            }
            else
            {
                return Int32.MinValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int GetRollingMaximum(int n)
        {
            maxHeap.add(n);

            return maxHeap.peek();

        }
    }
}
