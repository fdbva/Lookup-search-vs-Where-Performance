using BenchmarkDotNet.Running;

namespace LookupVsSeachBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<LookupVsSearchBenchmarkExample>();
        }
    }
}
