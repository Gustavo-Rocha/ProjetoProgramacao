using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class Agenda
    {

        public DateTime Data { get; set; }
       
        public Cliente cliente { get; set; }

    }
}
