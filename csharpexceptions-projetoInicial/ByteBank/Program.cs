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
                ContaCorrente contaCorrente = new ContaCorrente(10, 12345);
                ContaCorrente conta2 = new ContaCorrente(456, 78945);

                conta2.Transferir(-456, contaCorrente);


                contaCorrente.Depositar(50);
                Console.WriteLine(contaCorrente.Saldo);
                contaCorrente.Sacar(-500);
            }

            catch(ArgumentException e)
            {
                if(e.ParamName=="numero")
                {

                }

                
                Console.WriteLine("argumento com problema: "+e.ParamName);
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException");
                Console.WriteLine(e.Message);
                
            }

            catch(SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
            }

            catch(Exception e)
            {
              //  Console.WriteLine(erro.StackTrace);
                Console.WriteLine(e.Message);
            }
            

            
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