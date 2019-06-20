using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
   public abstract class Funcionario
    {
        //0- funcionario
        //1-diretor
        //2-designer
        //3-gerente de conta corrente
        //4-coordenador


        public static int TotalDeFuncionarios { get; private set; }
    
        private int _tipo;
        public string Nome { get; set; }
        public string CPF { get; private  set; }
        public double Salario { get; protected set; }
       

        public Funcionario(double salario,String cpf)
        {

            Console.WriteLine("Cirando Funcionario");
            CPF = cpf;
            Salario = salario;

            TotalDeFuncionarios++;
        }

        public abstract void AumentarSalario();

        public abstract double GetBonificacao();


       
        
    }
}
