using AmbienteSimuladoClienteCompra;
using BenchmarkDotNet.Attributes;

namespace LookupVsSeachBenchmark
{
    [Config(typeof(MultipleRuntimes))]
    [MemoryDiagnoser]
    public class LookupVsSearchBenchmarkExample
    {
        private AmbienteSimuladoTeste _ambienteSimuladoTeste;

        [GlobalSetup]
        public void Setup()
        {
            _ambienteSimuladoTeste = new AmbienteSimuladoTeste();
            _ambienteSimuladoTeste.SetupInicial();
        }

        [Benchmark]
        public decimal Where() => _ambienteSimuladoTeste.AlgoritmoNaoOtimizado();

        [Benchmark]
        public decimal Lookup() => _ambienteSimuladoTeste.AlgoritmoOtimizado();
    }
}
