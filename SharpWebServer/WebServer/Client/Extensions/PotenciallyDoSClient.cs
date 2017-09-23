using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace SharpWebServer.WebServer.Client.Extensions
{
    public struct PotenciallyDoSClient
    {
        public Stopwatch Stopwatch;
        public int Count;

        public int MaxTimeSpan, MaxPardons;

        /// <summary>
        /// true = ip_ban false = permitted
        /// </summary>
        /// <param name="_max_time_span"></param>
        /// <param name="_max_tries"></param>
        /// <returns></returns>
        public bool Analyze()
        {
            if (Stopwatch == null)
            {
                Stopwatch = new Stopwatch();
                Stopwatch.Start();
            }
            else
            {
                Stopwatch.Stop();

                if (Stopwatch.Elapsed.TotalMilliseconds < MaxTimeSpan)
                {
                    Count++;
                    if (Count > MaxPardons)
                        return true;
                }
                else Count = 0;
            }

            return false;
        }
    }
}
