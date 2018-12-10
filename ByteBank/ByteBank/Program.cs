using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args) {
            //Ctrl + . com cursor na palavra para ajuda
            //Em métodos estáticos como Main apenas é possível chamar outro método da classe, se você instanciar a Classe ou torná-lo estático
            //CalcularBonificacao();

            UsarSistema();
            Console.ReadLine();
        }

        public static void UsarSistema() {
            SistemaInterno sistemaInterno = new SistemaInterno(); 
            Diretor joao = new Diretor("123.123.123-13");
            joao.Nome = "João";
            joao.Senha = "123";

            ParceiroComercial luiz = new ParceiroComercial();
            luiz.Senha = "123";

            sistemaInterno.Logar(joao, "123");
            sistemaInterno.Logar(joao, "1233");
            sistemaInterno.Logar(luiz, "123");
        }

        public static void CalcularBonificacao() {
            GerenciadorBonificacao gerenciadorBonificacao = new GerenciadorBonificacao();

            Designer pedro = new Designer("123.123.123-12");
            pedro.Nome = "Pedro";

            Diretor joao = new Diretor("123.123.123-13");
            joao.Nome = "João";

            Auxiliar igor = new Auxiliar("123.123.123-14");
            igor.Nome = "Igor";

            GerenteDeConta camila = new GerenteDeConta("123.123.123-15");
            camila.Nome = "Camila";

            gerenciadorBonificacao.Registrar(pedro);
            gerenciadorBonificacao.Registrar(joao);
            gerenciadorBonificacao.Registrar(igor);
            gerenciadorBonificacao.Registrar(camila);

            Console.WriteLine(gerenciadorBonificacao.GetTotalBonificacao());
        }
    }
}
