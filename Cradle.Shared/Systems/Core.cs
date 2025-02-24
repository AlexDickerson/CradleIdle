using System.Numerics;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Cradle.Shared.Systems
{
    public delegate Task MadraCycled();

    public interface ICore
    {
        double CyclingInterval { get; set; }
        int MadraPerCycle { get; set; }
        BigInteger Madra { get; set; }

        event MadraCycled OnMadraCycled;
    }
    public class Core : ICore
    {
        public double CyclingInterval
        {
            get => cyclingInterval;
            set
            {
                cyclingInterval = value;
                myTimer.Interval = value;
            }
        }
        public int MadraPerCycle { get; set; } = 1;
        public BigInteger Madra { get; set; } = 0;

        public event MadraCycled OnMadraCycled;

        private double cyclingInterval = 2000; // default to 2 seconds
        private readonly Timer myTimer = new();

        public Core()
        {
            // Create a timer with a two second interval.
            myTimer.Elapsed += new ElapsedEventHandler(CycleMadra);
            myTimer.Interval = cyclingInterval; // 2000 ms is two seconds
            myTimer.Enabled = true;
        }

        public void CycleMadra(object source, ElapsedEventArgs e)
        {
            Madra += MadraPerCycle;
            OnMadraCycled?.Invoke();
        }
    }
}
