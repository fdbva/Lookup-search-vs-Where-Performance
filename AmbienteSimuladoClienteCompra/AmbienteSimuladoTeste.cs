using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AmbienteSimuladoClienteCompra
{
    public class AmbienteSimuladoTeste
    {
        private const int QuantidadeDeClientes = 50000;
        private const int QuantidadeDeCompras = 5000;
        private ConcurrentDictionary<string, Cliente> Clientes { get; set; } = new ConcurrentDictionary<string, Cliente>();
        private List<Compra> Compras { get; set; } = new List<Compra>();

        public void Run()
        {

            Console.WriteLine("Criando o Setup Inicial");
            SetupInicial();
            Console.WriteLine("Setup Inicial Finalizado, prosseguir?");
            Console.ReadLine();

            Console.WriteLine("Tarefa não otimizada começou! Processando...");
            var stopwatch = Stopwatch.StartNew();
            //2º caso - percorrer os clientes. Encontrar todas as compras que o cliente fez na semana.
            //  Fazer alguma operação, por exemplo: enviar email com informação de todas as compras agrupadas
            var somatorioSemSentido = AlgoritmoNaoOtimizado();

            Console.WriteLine($"Tarefa não otimizada terminou em {stopwatch.ElapsedMilliseconds}ms, somatório total foi de {somatorioSemSentido}");

            Console.WriteLine($"{Environment.NewLine}Pronto para começar tarefa otimizada, prosseguir?");
            Console.ReadLine();

            stopwatch.Restart();
            somatorioSemSentido = AlgoritmoOtimizado();

            Console.WriteLine($"Tarefa otimizada terminou em {stopwatch.ElapsedMilliseconds}ms, somatório total foi de {somatorioSemSentido}");
        }

        public decimal AlgoritmoOtimizado()
        {
            decimal somatorioSemSentido;
            var lookupDeCompras = Compras.ToLookup(x => x.CpfCliente, x => x);
            somatorioSemSentido = 0m;
            foreach (var cliente in Clientes)
            {
                var comprasDoCliente = lookupDeCompras[cliente.Key].ToList();

                var valorTotalComprasDoCliente = comprasDoCliente.Sum(x => x.Valor);

                //fazer alguma outra operação
                somatorioSemSentido += valorTotalComprasDoCliente;
            }

            return somatorioSemSentido;
        }

        public decimal AlgoritmoNaoOtimizado()
        {
            var somatorioSemSentido = 0m;
            foreach (var cliente in Clientes)
            {
                var comprasDoCliente = Compras.Where(x => x.CpfCliente == cliente.Key).ToList();

                var valorTotalComprasDoCliente = comprasDoCliente.Sum(x => x.Valor);

                //fazer alguma outra operação
                somatorioSemSentido += valorTotalComprasDoCliente;
            }

            return somatorioSemSentido;
        }

        public void SetupInicial()
        {
            var randomGenerator = new Random();
            //Setup Inicial
            for (var i = 0; i < QuantidadeDeClientes; i++)
            {
                var cpf = randomGenerator.Next(100000, 999999) +
                          randomGenerator.Next(10000, 99999).ToString();
                Clientes.TryAdd(
                    cpf,
                    new Cliente
                    {
                        Cpf = cpf,
                        Email = cpf
                    });
            }

            var clienteList = Clientes.Select(x => x.Key).ToList();
            var maxClienteIndex = clienteList.Count - 1;
            for (var i = 0; i < QuantidadeDeCompras; i++)
            {
                Compras.Add(
                    new Compra
                    {
                        Id = Guid.NewGuid(),
                        CpfCliente = clienteList[randomGenerator.Next(0, maxClienteIndex)],
                        Valor = randomGenerator.Next(1, 111)
                    });
            }
        }
    }
}
