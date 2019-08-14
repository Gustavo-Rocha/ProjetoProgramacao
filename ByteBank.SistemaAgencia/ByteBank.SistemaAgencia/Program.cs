using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(456, 456879);

            new ContaCorrente(123, 134534);

            Modelos.Funcionarios.Funcionario funcionario = null;

            Console.WriteLine(conta.Numero);

            Console.ReadLine();


        }
    }
}
