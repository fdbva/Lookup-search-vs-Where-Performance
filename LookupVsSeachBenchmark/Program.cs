using BenchmarkDotNet.Running;

namespace LookupVsSeachBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //commit 1
            //commit 2
            var summary = BenchmarkRunner.Run<LookupVsSearchBenchmarkExample>();
        }
    }
}
