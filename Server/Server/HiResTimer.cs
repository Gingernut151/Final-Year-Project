using System;
using System.Diagnostics;

namespace FYP_Server
{
    public class HiResTimer
    {
        private Stopwatch stopwatch;

        // Constructor
        public HiResTimer()
        {
            stopwatch = new Stopwatch();
        }

        // Start the timer
        public void Start()
        {
            if (stopwatch.IsRunning)
            {
                Console.WriteLine("Stopwatch is already stopped");
            }
            else
            {
                stopwatch.Start();
            }
        }

        // Stop the timer
        public void Stop()
        {
            if (!stopwatch.IsRunning)
            {
                Console.WriteLine("Stopwatch is already stopped");                
            }
            else
            {
                stopwatch.Stop();
            }
        }

        public void Reset()
        {
            stopwatch.Reset();
        }

        // Returns the duration of the timer (in milisedonds)
        public float Duration()
        {
            double temp = Convert.ToDouble(stopwatch.ElapsedMilliseconds);
            return (float)temp * 5.0f;
        }
    }
}