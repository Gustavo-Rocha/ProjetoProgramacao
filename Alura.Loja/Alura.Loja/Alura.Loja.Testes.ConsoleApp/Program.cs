using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {

            using (var contexto = new LojaContext())
            {

                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                //var update = new ProdutoDAOEntity();
                //var lista = update.Produtos();
                Produto prod = new Produto();

                var atualiza = contexto.Produtos.Where(p => p.Id == 3002).ToList();
                foreach(var item in atualiza)
                {
                    prod = item;

                    Console.WriteLine($"o preço do produto {item.Nome} é de {item.PrecoUnitario} e a compra é {item.Compras} ");
                }
                prod.PrecoUnitario = 3;
                
                contexto.Produtos.Update(prod);

                // atualizando  uma compra

                Compra comp = new Compra();


                //comp.Produto = prod;
                //comp.Quantidade = 10;
                //comp.ProdutoId = 3002;
                //comp.Preco = comp.Quantidade * prod.PrecoUnitario;

                //contexto.Compras.Add(comp);

                var Listacompra = contexto.Compras.Where(lc => lc.Id ==1).ToList();


                foreach (var item in Listacompra)
                {
                    // item.Produto = prod; 

                     comp = item;
                    Console.WriteLine("O retorno da compra que  tem no banco eeeee "+comp);
                }

                comp.Produto = prod;
                comp.Quantidade = 6;
                comp.ProdutoId = 3002;
                comp.Preco = comp.Quantidade * prod.PrecoUnitario;



                contexto.Compras.Update(comp);
                Console.WriteLine("Atualizando a compraaaaaaaaaaaaa do pão frances" + comp);
                ExibirEntries(contexto.ChangeTracker.Entries());
                 contexto.SaveChanges();
                



                var cliente = contexto.Clientes.Include(c=> c.EnderecoDeEntrega).FirstOrDefault();

                Console.WriteLine("O endereço do cliente é: "+ cliente.EnderecoDeEntrega.Logradouro);


               var produto= contexto.Produtos.Include(c=>c.Compras).Where(p => p.Id == 3002).FirstOrDefault();

                contexto.Entry(produto)
                .Collection(p => p.Compras)
                .Query()
                .Where(c => c.Preco > 2)
                .Load();

                Console.WriteLine($"mostrando as compras do produto {produto.Nome}");

                foreach(var item in produto.Compras)
                {
                    Console.WriteLine("\t" + item);
                }
               
            }
            Console.ReadLine();
        }

        public static void ExibeProdutosDaPromocao()
        {
            using (var contexto2 = new LojaContext())
            {
                var serviceProvider = contexto2.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = contexto2.Promocoes
                    .Include(p => p.PromocaoProdutos)                   // include: fazendo join para preencher a propriedade "Promocoes"
                    .ThenInclude(pp => pp.Produto)                      // select* from promocoes p  inner join PromocaoProdutos
                    .FirstOrDefault();                                  //pp.promocaoId = p.Id  inner join Produto ppp
                                                                        //ppp.id==pp.ProdutoId
                                                                        //promoção tem uma lsita deprodutos -> m-n



                Console.WriteLine("\nMotrando os produtos da promoção...");
                foreach (var item in promocao.PromocaoProdutos)
                {
                    Console.WriteLine(item.Produto);
                }

            }
        }

        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());


                var promocao = new Promocao();
                //promocao.Descricao = "Queima Total 2017";
                //promocao.DataInicio = new DateTime(2017, 1, 1);
                //promocao.DataTermino = new DateTime(2017, 1, 31);
                promocao = contexto.Promocoes.FirstOrDefault();
               var produtos = contexto.Produtos.Where(p => p.Categoria == "Bebidas" && p.Nome == "Café").ToList();

                //var produtos = contexto.Produtos.Where(p => p.Id == 3002 ).ToList();
                // Exemplo de where com AND/OR
                // var produtos = contexto.Produtos.Where(p => p.Categoria == "Bebidas" && p.Nome == "Café").ToList();

                foreach (var p in produtos)
                {
                    promocao.IncluiProduto(p);
                }

                contexto.Promocoes.Add(promocao);

                contexto.SaveChanges();

                ExibirEntries(contexto.ChangeTracker.Entries());



            }
        }

        private static void UmParaUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Cuzinho da silva";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos Inválidos",
                Complemento = "sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };



            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());


                contexto.Clientes.Add(fulano);
                ExibirEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
                ExibirEntries(contexto.ChangeTracker.Entries());
            }

            Console.ReadLine();
        }

        private static void MuitosParaMuitos()
        {

            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };


            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);



            //compra de 6 pães franceses
            //var paoFrances = new Produto();
            //paoFrances.Nome = "Pão Francês";
            //paoFrances.PrecoUnitario = 0.40;
            //paoFrances.Unidade = "Unidade";
            //paoFrances.Categoria = "Padaria";

            //var compra = new Compra();
            //compra.Quantidade = 6;
            //compra.Produto = paoFrances;
            //compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;


            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                //contexto.Promocoes.Add(promocaoDePascoa);
                // var promocao = contexto.Promocoes.Find();

                contexto.Promocoes.Remove(contexto.Promocoes.Find(1));

                ExibirEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();


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
