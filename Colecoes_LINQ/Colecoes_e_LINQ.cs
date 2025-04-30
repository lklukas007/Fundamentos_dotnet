using System;
using System.Collections.Generic;
using System.Linq;

namespace Colecoes_LINQ
{
    public static class Colecoes_e_LINQ
    {
        public static void Executar()
        {
            Console.WriteLine("=== Exemplo: Coleções e LINQ ===");

            // --- LIST<T> ---
            var nomes = new List<string> { "Ana", "Bruno", "Carlos", "Amanda", "Beatriz" };

            Console.WriteLine("\n--- Lista Original ---");
            nomes.ForEach(n => Console.WriteLine(n));

            // Filtrar nomes que começam com 'A'
            var comecaComA = nomes.Where(n => n.StartsWith("A")).ToList();

            Console.WriteLine("\n--- Nomes que começam com 'A' ---");
            comecaComA.ForEach(n => Console.WriteLine(n));

            // Ordenar a lista
            var ordenados = nomes.OrderBy(n => n).ToList();

            Console.WriteLine("\n--- Lista Ordenada ---");
            ordenados.ForEach(n => Console.WriteLine(n));

            // Verificar se existe um nome com mais de 6 letras
            bool existeNomeLongo = nomes.Any(n => n.Length > 6);
            Console.WriteLine($"\nExiste nome com mais de 6 letras? {(existeNomeLongo ? "Sim" : "Não")}");

            // Pegar o primeiro nome com 'z' ou retornar null (safe)
            var nomeComZ = nomes.FirstOrDefault(n => n.Contains("z"));
            Console.WriteLine($"Primeiro nome com 'z': {(nomeComZ ?? "Nenhum encontrado")}");

            Console.WriteLine($"\nTotal de nomes: {nomes.Count}");

            // --- ARRAYS ---
            var numeros = new[] { 1, 2, 3, 4, 5, 6 };

            var pares = numeros.Where(n => n % 2 == 0);
            var dobrados = numeros.Select(n => n * 2);

            Console.WriteLine("\n--- Números Pares ---");
            foreach (var n in pares)
                Console.WriteLine(n);

            Console.WriteLine("\n--- Números Dobrados ---");
            foreach (var n in dobrados)
                Console.WriteLine(n);

            Console.WriteLine($"Soma total: {numeros.Sum()}");

            // --- DICIONÁRIO ---
            var contatos = new Dictionary<string, string>
            {
                { "Lucas", "1234-5678" },
                { "Maria", "9876-5432" }
            };

            Console.WriteLine("\n--- Contatos (Dictionary) ---");
            foreach (var contato in contatos)
                Console.WriteLine($"{contato.Key}: {contato.Value}");

            // Buscar chave
            if (contatos.TryGetValue("Lucas", out string? telefone))
                Console.WriteLine($"Telefone do Lucas: {telefone}");

            // --- HASHSET ---
            var conjunto = new HashSet<int> { 1, 2, 2, 3 };
            Console.WriteLine("\n--- HashSet (sem duplicatas) ---");
            foreach (var item in conjunto)
                Console.WriteLine(item);
        }
    }
}
