using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(4564, 789684);
                ContaCorrente conta2 = new ContaCorrente(7891, 456794);

                conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                //Console.WriteLine("informações da Inner Exception(exceção interna): ");
                //Console.WriteLine(e.InnerException.Message);
                // Console.WriteLine(e.InnerException.StackTrace);

            }
            Console.WriteLine("Execução finalizada. Tecle enter para sair");
            Console.ReadLine();

        
        Console.ReadLine();
        }
        //Teste com a cadeia de chamada:
        //Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(0);
        }


        private static void TestaDivisao(int divisor)
        {
           
                int resultado = Dividir(10, divisor);
                Console.WriteLine("Resultado da divisão de 10 por " + divisor +"é"+ resultado);
           
             
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;

            }
            catch (DivideByZeroException)
            {
                 Console.WriteLine("Exceção  com numero ="+numero+"com divisor = "+divisor);
                throw;
            }
                
        }
    }
}