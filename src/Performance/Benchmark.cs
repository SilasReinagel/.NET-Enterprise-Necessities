
namespace System.Enterprise.Necessities.Performance
{
    public sealed class Benchmark
    {
        private readonly Action _action;
        private readonly int _nWarmups;
        private readonly int _nRepetitions;

        public Benchmark(Action action, int nWarmups, int nRepetitions)
        {
            _action = action;
            _nWarmups = nWarmups;
            _nRepetitions = nRepetitions;
        }

        public TimeSpan GetAverageDuration()
        {
            Warmup();

            var ticks = DateTime.Now.Ticks;
            PerformBenchmark();
            var durationTicks = DateTime.Now.Ticks - ticks;

            return TimeSpan.FromTicks(Convert.ToInt64((double)durationTicks / _nRepetitions));
        }

        private void PerformBenchmark()
        {
            for (var i = 0; i < _nRepetitions; i++)
                _action();
        }

        private void Warmup()
        {
            for (var i = 0; i < _nWarmups; i++)
                _action();
        }
    }
}
