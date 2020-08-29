using Agendamento.Models;
using Agendamento.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Agendamento.Controllers
{
    public class CadastroController: Controller
    {

        private readonly IClienteRepository clienteRepository;

        public CadastroController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }



        public IActionResult Index()
        {

            var cliente = new Cliente();
            cliente.cpf = 12344555;
            cliente.Nome = "Gustavo Oliveira";
            cliente.Celular = 9527532;
            cliente.Email = "gustavo@hotmail.com";

            clienteRepository.Cadastrar(cliente);

            return View();
        }



        
    }
}
