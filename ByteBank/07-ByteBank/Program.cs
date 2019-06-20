using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(7522,86054104);

            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);
            conta.Numero = 86054104;

            //conta.Agencia = 7522;
            // conta.Agencia = -10;

            ContaCorrente contaDaGabriela = new ContaCorrente(7531, 8604655);
            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);


            Console.WriteLine(conta.Agencia);
            Console.WriteLine(conta.Numero);
            Console.ReadLine();


        }
    }
}
