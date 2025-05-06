using System;

namespace Exceptions
{
    public static class TratamentoDeExcecoes
    {
        public static void Executar()
        {
            Console.WriteLine("=== Exemplo: Tratamento de Exceptions ===");

            try
            {
                Console.Write("\nDigite um número inteiro: ");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out int numero))
                    throw new FormatException("O valor informado não é um número inteiro válido.");

                Console.WriteLine($"Número informado: {numero}");

                // Simulando divisão
                Console.Write("Digite um divisor: ");
                int divisor = int.Parse(Console.ReadLine()!);

                int resultado = Dividir(numero, divisor);
                Console.WriteLine($"Resultado da divisão: {resultado}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro de formatação: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Erro matemático: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nFinalizando execução do exemplo.");
            }
        }

        private static int Dividir(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Não é possível dividir por zero.");
            return a / b;
        }
    }
}
