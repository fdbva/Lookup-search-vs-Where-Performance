using BenchmarkDotNet.Running;

namespace LookupVsSeachBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //commit 1
            var summary = BenchmarkRunner.Run<LookupVsSearchBenchmarkExample>();
        }
    }
}
