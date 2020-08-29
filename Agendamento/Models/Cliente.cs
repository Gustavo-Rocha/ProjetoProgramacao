using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public double cpf { get; set; }
        public string Nome { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }
       // public IList<Agenda> agendamento { get; set; }

    }
}
