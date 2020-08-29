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
    public class CadastroLogica
    {
        

        public static Task Incluir(HttpContext context)
        {
            var livro = new Livro
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First()
            };

            var repositorio = new LivroRepositorioCSV();

            repositorio.Incluir(livro);

            return context.Response.WriteAsync("Livro adicionadocom sucesso na lista 'Para Ler'");
        }

        public static Task ExibirFormulario(HttpContext context)
        {
            string html = HtmlUtils.CarregaArquivoHTML("Formulario");


            return context.Response.WriteAsync(html);
        }

        public static Task NovoLivro(HttpContext context)
        {
            var livro = new Livro
            {
                Titulo = Convert.ToString(context.GetRouteValue("NomeLivro")),
                Autor = Convert.ToString(context.GetRouteValue("Autor"))
            };

            var repositorio = new LivroRepositorioCSV();

            repositorio.Incluir(livro);

            return context.Response.WriteAsync("Livro adicionadocom sucesso na lista 'Para Ler'");

        }
    }
}
