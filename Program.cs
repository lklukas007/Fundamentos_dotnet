using TiposEstruturasDotNet.Topicos;
using Colecoes_LINQ;
using AcessoDadosDapper;

namespace TiposEstruturasDotNet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("=== Aprendendo Fundamentos .NET ===");
                Console.WriteLine("1 - Tipos e Estruturas");
                Console.WriteLine("2 - Coleções e LINQ");
                Console.WriteLine("3 - Async/Await e Tasks");
                Console.WriteLine("4 - Exceptions");
                Console.WriteLine("5 - Dapper");
                Console.WriteLine("0 - Sair");
                Console.Write("Selecione uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Pressione uma tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        TiposEestruturas.Executar();
                        break;
                    case 2:
                        Colecoes_e_LINQ.Executar();
                        break;
                    case 3:
                        await Async_Tasks.AsyncTasks.ExecutarAsync();
                        break;
                    case 4:
                        Exceptions.TratamentoDeExcecoes.Executar();
                        break;
                    case 5:
                        DapperExemplo.Executar();
                        break;
                    case 0:
                        Console.WriteLine("Encerrando aplicação...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}