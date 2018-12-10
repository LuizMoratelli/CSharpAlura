using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel
    {
        // Quando chamamos o contrutor de uma classe tambem chamamos (antes) da que fora herdada
        public Diretor(string cpf) : base(5000, cpf) {

        }

        // Quando existe processamento (não gratuíto) é uma convenção ser um método
        // Override, sobreescreve o método do pai (tem que ser virtual)
        public override double GetBonificacao() { 
            // Base é utilizado para chamar as propriedades e métodos da classe base 
            //return Salario + base.GetBonificacao();
            return Salario * 0.5;
        }

        public override void AumentarSalario() {
            Salario *= 1.15;
        }
    }
}
