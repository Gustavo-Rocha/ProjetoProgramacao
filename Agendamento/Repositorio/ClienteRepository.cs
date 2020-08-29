using Agendamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Repositorio
{
    public class ClienteRepository:IClienteRepository
    {
        public ClienteRepository(ApplicationContext context) 
        {
        }

        

        public void Cadastrar(Cliente cliente)
        {
            // var cliente = new Cliente();

            var context = new ApplicationContext();
            

                //cliente.cpf = 1234455;
                //cliente.Nome = "Gustavo Oliveira";
                //cliente.Celular = 9527532;
                //cliente.Email = "gustavo@hotmail.com";


                context.Clientes.Add(cliente);

                context.SaveChanges();


            

        }
    }
}
