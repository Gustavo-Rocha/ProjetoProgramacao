using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Funcionarios;
using ByteBank.Sistemas;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            //CalcularBonificacao();
            UsarSistema();


            Console.ReadLine();

        }

        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();

            Diretor roberta = new Diretor("123.456.789.-09");
            roberta.Nome = "Roberta";
            roberta.Senha="123";

            GerenteDeConta camila = new GerenteDeConta("089.234.989.43");
            camila.Nome = "Camila";
            camila.Senha = "123";

            ParceiroComercial parceiro= new ParceiroComercial();
            parceiro.Senha = "123";

            sistemaInterno.Logar(parceiro, "123");
            sistemaInterno.Logar(camila,"123");
            sistemaInterno.Logar(roberta, "123");
        }

        public static void CalcularBonificacao ()
        {

            GerenciadorBonificacao gerenciadorBonificacao = new GerenciadorBonificacao();

            Funcionario pedro = new Designer("111.111.111-18");
            pedro.Nome = "Pedro";

            Funcionario roberta = new Diretor("123.456.789.-09");
            roberta.Nome = "Roberta";

            Funcionario igor = new Auxiliar("345.123.456=21");
            igor.Nome = "Igor";

            Funcionario camila = new GerenteDeConta("089.234.989.43");
            camila.Nome = "Camila";

            Desenvolvedor guilherme = new Desenvolvedor("03.456.132.69");
            guilherme.Nome = "Guilherme";


            gerenciadorBonificacao.Registrar(pedro);
            gerenciadorBonificacao.Registrar(roberta);
            gerenciadorBonificacao.Registrar(igor);
            gerenciadorBonificacao.Registrar(camila );
            gerenciadorBonificacao.Registrar(guilherme);



            Console.WriteLine("TOTal de bonificação no mes" + gerenciadorBonificacao.GetTotalBonificacao());

        }

    }
}
