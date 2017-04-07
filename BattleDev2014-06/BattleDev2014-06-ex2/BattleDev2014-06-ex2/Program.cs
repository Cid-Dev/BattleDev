using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDev2014_06_ex2
{
    class Program
    {
        static readonly int X = 0;
        static readonly int Y = 1;
        static readonly int HOUR = 0;
        static readonly int MINUTES = 1;
        static readonly int SECONDS = 2;

        static void Main(string[] args)
        {
            string line;
            string[] infos = new string[3];
            double posx;
            double posy;
            double tot_dist = 0.0;
            double tot_time = 0.0;
            double[] prevcoor = null;
            DateTime first_time = new DateTime();
            DateTime last_time = new DateTime();

            while ((line = Console.ReadLine()) != null)
            {
                infos = line.Split(' ');
                string[] time = infos[2].Split(':');
                posx = Convert.ToDouble(infos[0]);
                posy = Convert.ToDouble(infos[1]);
                if (prevcoor == null)
                {
                    prevcoor = new double[2];
                    first_time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                              Convert.ToInt32(time[HOUR]), Convert.ToInt32(time[MINUTES]), Convert.ToInt32(time[SECONDS]));
                }
                else
                    tot_dist += Math.Round(Math.Sqrt(Math.Pow(posx - prevcoor[X], 2)
                                          + Math.Pow(posy - prevcoor[Y], 2)));
                last_time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                              Convert.ToInt32(time[HOUR]), Convert.ToInt32(time[MINUTES]), Convert.ToInt32(time[SECONDS]));
                prevcoor[X] = posx;
                prevcoor[Y] = posy;
            }
            tot_time = last_time.Subtract(first_time).TotalHours;
            Console.WriteLine(Math.Round((tot_dist / 1000.0) / tot_time, 2));
        }
    }
}