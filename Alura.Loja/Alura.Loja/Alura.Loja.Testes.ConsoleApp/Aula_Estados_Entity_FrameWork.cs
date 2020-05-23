using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Aula_Estados_Entity_FrameWork
    {
        static void Main(string[] args)
        {
            using (var contexto = new LojaContext())
            {

                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();


                ExibirEntries(contexto.ChangeTracker.Entries());

                var novoProduto = new Produto()
                {
                    Nome = "sabão em pó",
                    Categoria = "Limpeza",
                    Preco = 5.00

                };


                contexto.Produtos.Add(novoProduto);
                ExibirEntries(contexto.ChangeTracker.Entries());
                contexto.Produtos.Remove(novoProduto);

                ExibirEntries(contexto.ChangeTracker.Entries());

                // contexto.SaveChanges();

                var entry = contexto.Entry(novoProduto);
                Console.WriteLine("\n\n" + entry.Entity.ToString() + " - " + entry.State);

                ExibirEntries(contexto.ChangeTracker.Entries());

            }
            Console.ReadLine();
        }

        private static void ExibirEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("\n ================== \n");

            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }
    }
}
