
using ByteBank.Modelos.Funcionarios;



namespace ByteBank.SistemaAgencia
{
    public class Estagiario : Funcionario
    {

        public Estagiario(double salario,string cpf) : base(salario,cpf)
        {

        }

        public override void AumentarSalario()
        {
            
        }

        protected override double GetBonificacao()
        {
            return 00.00;
        }
    }
}
