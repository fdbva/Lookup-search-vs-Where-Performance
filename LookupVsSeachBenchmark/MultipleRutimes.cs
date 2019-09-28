using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;

namespace LookupVsSeachBenchmark
{
    public class MultipleRuntimes : ManualConfig
    {
        public MultipleRuntimes()
        {
            Add(Job.Default.With(CsProjCoreToolchain.NetCoreApp30)); // .NET Core 2.1

            Add(Job.Default.With(CsProjCoreToolchain.NetCoreApp20)); // NET 4.6.2
        }
    }
}
