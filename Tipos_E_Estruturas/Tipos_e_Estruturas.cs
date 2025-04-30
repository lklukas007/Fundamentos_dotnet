namespace TiposEstruturasDotNet.Topicos
{
    public static class TiposEestruturas
    {
        public static void Executar()
        {
            Console.WriteLine("=== Exemplo: Tipos e Estruturas ===");

            // Struct (tipo por valor)
            var ponto1 = new Ponto(2, 3);
            var ponto2 = ponto1;
            ponto2.Mover(1, 1);

            Console.WriteLine($"Ponto1: {ponto1.X}, {ponto1.Y}");
            Console.WriteLine($"Ponto2: {ponto2.X}, {ponto2.Y}");

            // Classe (tipo por referência)
            var pessoa1 = new Pessoa { Nome = "Lucas", Idade = 25 };
            var pessoa2 = pessoa1;
            pessoa2.Aniversario();

            Console.WriteLine($"Pessoa1: {pessoa1.Nome}, {pessoa1.Idade}");
            Console.WriteLine($"Pessoa2: {pessoa2.Nome}, {pessoa2.Idade}");
        }

        public struct Ponto
        {
            public int X;
            public int Y;

            public Ponto(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Mover(int dx, int dy)
            {
                X += dx;
                Y += dy;
            }
        }

        public class Pessoa
        {
            public string? Nome { get; set; }
            public int Idade { get; set; }

            public void Aniversario() => Idade++;
        }
    }
}
