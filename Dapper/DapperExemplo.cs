using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

namespace AcessoDadosDapper
{
    public class DapperExemplo
    {
        private const string _masterConnection = "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";
        private const string _dbName = "DapperFundamentosDb";
        private static string _dbConnection = $"Server=localhost;Database={_dbName};Trusted_Connection=True;TrustServerCertificate=True;";

        public static void Executar()
        {
            Console.WriteLine("=== Exemplo: Acesso a Dados com Dapper ===");

            CriarBancoESeNecessario();
            CriarTabelaSeNecessario();

            InserirProduto("Mouse Logitech", 199.90m);
            InserirProduto("Teclado Mecânico", 299.99m);

            var produtos = ListarProdutos();

            Console.WriteLine("\n--- Produtos Cadastrados ---");
            foreach (var p in produtos)
                Console.WriteLine($"Id: {p.Id} | Nome: {p.Nome} | Preço: {p.Preco:C}");
        }

        private static void CriarBancoESeNecessario()
        {
            using var conexao = new SqlConnection(_masterConnection);
            conexao.Open();

            var checkDbSql = $"IF DB_ID('{_dbName}') IS NULL CREATE DATABASE {_dbName};";
            conexao.Execute(checkDbSql);
        }

        private static void CriarTabelaSeNecessario()
        {
            using var conexao = new SqlConnection(_dbConnection);
            conexao.Open();

            var sql = @"
                IF OBJECT_ID('dbo.Produto', 'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.Produto (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Nome NVARCHAR(100) NOT NULL,
                        Preco DECIMAL(10, 2) NOT NULL
                    );
                END";
            conexao.Execute(sql);
        }

        public static void InserirProduto(string nome, decimal preco)
        {
            using var conexao = new SqlConnection(_dbConnection);
            var sql = "INSERT INTO Produto (Nome, Preco) VALUES (@Nome, @Preco)";
            conexao.Execute(sql, new { Nome = nome, Preco = preco });
        }

        public static IEnumerable<Produto> ListarProdutos()
        {
            using var conexao = new SqlConnection(_dbConnection);
            var sql = "SELECT * FROM Produto";
            return conexao.Query<Produto>(sql);
        }

        public class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }
        }
    }
}