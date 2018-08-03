using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int window_size = 10000000; 
            StatsCalculator calc = new StatsCalculator(window_size);

            double avg;
            int max;

            //int[] arr = new int[] { 10, 9, 8, 7, 6, 10 };

            for(int i=0; i< 1000000000; i++)
            {
                calc.GetRollingStats(i, out avg, out max);

                if(i>= window_size-1)
                {
                    Console.WriteLine("Avg: " + string.Format("{0:0.00}", avg) + ", Max: " + max);
                }
            }
            Console.ReadLine();
        }
    }
}
