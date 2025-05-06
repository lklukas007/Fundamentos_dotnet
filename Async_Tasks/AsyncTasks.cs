using System;
using System.Threading.Tasks;

namespace Async_Tasks
{
    public static class AsyncTasks
    {
        public static async Task ExecutarAsync()
        {
            Console.WriteLine("=== Exemplo: Async/Await e Tasks ===");

            Console.WriteLine("\nIniciando processamento assíncrono...");

            var resultado = await ObterDadosAsync();

            Console.WriteLine($"Resultado recebido: {resultado}");

            Console.WriteLine("\nProcessando múltiplas tarefas paralelas...");

            var tarefa1 = TarefaDemorada("Tarefa 1", 2000);
            var tarefa2 = TarefaDemorada("Tarefa 2", 3000);
            var tarefa3 = TarefaDemorada("Tarefa 3", 1000);

            await Task.WhenAll(tarefa1, tarefa2, tarefa3);

            Console.WriteLine("\nTodas as tarefas foram concluídas!");
        }

        // Simula uma operação assíncrona que retorna um resultado
        private static async Task<string> ObterDadosAsync()
        {
            await Task.Delay(1500); // simula espera
            return "Dados simulados do servidor";
        }

        // Simula uma tarefa demorada
        private static async Task TarefaDemorada(string nome, int tempoMs)
        {
            Console.WriteLine($"{nome} iniciada...");
            await Task.Delay(tempoMs);
            Console.WriteLine($"{nome} finalizada após {tempoMs}ms.");
        }
    }
}
