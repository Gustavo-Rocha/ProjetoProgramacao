using Alura.ListaLeitura.App.Logica;
using Alura.ListaLeitura.App.Mvc;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection service)
        {
           //service.AddRouting();
            service.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();



            //--------------------USANDO MVC-----------------------------

            //var builder = new RouteBuilder(app);

            //builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);
            ////builder.MapRoute("Livros/ParaLer", LivrosLogica.ParaLer);
            ////builder.MapRoute("Livros/Lendo", LivrosLogica.Lendo);
            ////builder.MapRoute("Livros/Lidos", LivrosLogica.Lidos);
            ////builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.Detalhes);
            ////builder.MapRoute("Cadastro/NovoLivro/{NomeLivro}/{Autor}", CadastroLogica.NovoLivro);
            ////builder.MapRoute("Cadastro/ExibirFormulario", CadastroLogica.ExibirFormulario);
            ////builder.MapRoute("Cadastro/Incluir", CadastroLogica.Incluir);
            //var rotas = builder.Build();



            //app.Run(Roteamento);
        }


        //public Task Roteamento(HttpContext context)
        //{
        //    var repositorio = new LivroRepositorioCSV();

        //    var caminhos = new Dictionary<string, RequestDelegate>
        //    {
        //        { "/Livros/ParaLer", LivrosParaLer},
        //        { "/Livros/Lendo", LivrosLendo},
        //        { "/Livros/Lidos", LivrosLidos}

        //    };


        //    if(caminhos.ContainsKey(context.Request.Path))
        //    {
        //        RequestDelegate metodo = caminhos[context.Request.Path];

        //        return metodo.Invoke(context);
        //    }

        //    context.Response.StatusCode = 404;
        //    return context.Response.WriteAsync("Caminho não encontrado, Maluco!!");


        //}


       

       
    }
}