using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController:Controller
    {

        public IEnumerable<Livro> Livros { get; set; }

        public String Detalhes(int id)
        {
            var repositorio = new LivroRepositorioCSV();
          

            var livro = repositorio.Todos.First(l => l.Id == id);
            return livro.Detalhes();

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


        public IActionResult ParaLer()
        {

            var _repo = new LivroRepositorioCSV();
            //var html = CarregaLista(_repo.ParaLer.Livros);
           // var html = new ViewResult { ViewName = "ParaLer" };
            ViewBag.Livros = _repo.ParaLer.Livros;
            return View("Lista");

        }

        public IActionResult Lendo()
        {

            var _repo = new LivroRepositorioCSV();
            //var html = CarregaLista(_repo.Lendo.Livros);
            ViewBag.Livros = _repo.Lendo.Livros;
             

            return View("Lista");

        }

        public IActionResult Lidos()
        {

            var _repo = new LivroRepositorioCSV();
            //var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("Lidos");
            ViewBag.Livros=_repo.Lidos.Livros;
           
            return View("Lista");

        }

        public string Teste()
        {
            return "Nova funcionalidade implementada.";
        }


    }
}
