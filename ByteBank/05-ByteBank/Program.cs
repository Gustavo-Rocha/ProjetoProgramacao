using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cliente gabriela = new Cliente();
           // gabriela.nome = "Gabriela";
          //  gabriela.cpf = "123.456.789.00";
           // gabriela.profissao = "desenvolvedora";


            ContaCorrente conta = new ContaCorrente();
            conta.titular = new Cliente();
            conta.titular.nome = "gabriela Costa";
            conta.titular.cpf = "123.456.789.00";
            conta.titular.profissao = "desenvolvedora";

            conta.numeroAgencia = 563;
            conta.numero = 133466;
            conta.saldo = 500;

           

           // Console.WriteLine(gabriela.nome);
            Console.WriteLine(conta.titular.nome);
            Console.WriteLine(conta.titular.cpf);
            Console.WriteLine(conta.titular.profissao);

            Console.ReadLine();


        }
    }
}
