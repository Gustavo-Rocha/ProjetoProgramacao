using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosLogica
    {

        

        public static Task Detalhes(HttpContext context)
        {
            var repositorio = new LivroRepositorioCSV();
            var idRota = Convert.ToInt32(context.GetRouteValue("id").ToString());

            var livro = repositorio.Todos.First(l => l.Id == idRota);
            return context.Response.WriteAsync(livro.Detalhes());

        }

        public static String CarregaLista(IEnumerable<Livro> livros)
        {

            //var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lista");
            foreach (var livro in livros)
            {
                conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li> #NOVO-ITEM#");
            }

           // conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", "");

            return conteudoArquivo.Replace("#NOVO-ITEM#", "");

        }

        //-----------------------------


        public static Task ParaLer(HttpContext context)
        {

            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.ParaLer.Livros);
            
            return context.Response.WriteAsync(html);

        }

        public static Task Lendo(HttpContext context)
        {

            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.Lendo.Livros);

             

            return context.Response.WriteAsync(html);

        }

        public static Task Lidos(HttpContext context)
        {

            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("Lidos");
            var html = CarregaLista(_repo.Lidos.Livros);
           
            return context.Response.WriteAsync(html);

        }




    }
}
