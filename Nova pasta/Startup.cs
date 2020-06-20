using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //a cada requisição será gerada uma nova instancia do serviço passado na requisição 

            //services.AddTransient<ICatalogo,Catalogo>();
            //services.AddTransient<IRelatorio,Relatorio>();


            //a cada  requisição no browser e dentro da requisição pode ter a instancia do objeto 
            //e só será gerado uma instancia do serviço dentro da mesma requisição

            services.AddScoped<ICatalogo, Catalogo>();
            services.AddScoped<IRelatorio, Relatorio>();

            // enquanto a aplicação estiver rodando o padrão singleton vai trabalhar com uma unica instancia do serviço

            var catalogo = new Catalogo();
            services.AddSingleton<ICatalogo>(catalogo);
            services.AddSingleton<IRelatorio>(new Relatorio(catalogo));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ICatalogo  catalogo = serviceProvider.GetService<ICatalogo>();
            IRelatorio relatorio = serviceProvider.GetService<IRelatorio>();



            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await relatorio.Imprimir(context);
                    //await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
