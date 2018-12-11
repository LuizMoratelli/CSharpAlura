using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
// Referencias >> Adicionar >> Projetos >> Projeto;
using ByteBankDll.Modelos;
using ByteBankDll.Modelos.Funcionarios;
using Humanizer;

namespace ByteBankDll.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args) {
            string url = "pagina?argumentos";

            int indiceInterrogacao = url.IndexOf('?');
            // Classe string é imutavel
            // Substring é inclusivo, inclue o indice solicitado
            string argumentos = url.Substring(indiceInterrogacao++);

            ExtratatorValorDeArgumentosURL extrator = new ExtratatorValorDeArgumentosURL("pagina?url=123&numero=123");
            Console.WriteLine(extrator.GetValor("url"));

            //string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            //string padrao = "[0-9]{4}[-][0-9]{4}";
            string padrao = "[0-9]{4,5}[-]?[0-9]{4}";
            string textoDeTeste = "Luiz 91234-1234";
            //Console.WriteLine(Regex.IsMatch(textoDeTeste, padrao));
            Console.WriteLine(Regex.Match(textoDeTeste, padrao));
              
            //Console.WriteLine(argumentos);

            //ContaCorrente conta = new ContaCorrente(123, 133);
            
            //DateTime dataFimPagamento = new DateTime(2018, 8, 17);
            //DateTime dataCorrente = DateTime.Now;

            //// Quando subtrai-se uma data de outra utiliza-se TimeSpan
            //TimeSpan diferenca = dataFimPagamento - dataCorrente;

            //// Ferramentas >> Gerenciador de Pacotes Nuget >> Console
            //string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            //Console.WriteLine(mensagem);
            Console.ReadLine();

            //.Equals pode verificar a igualdade de dois objetos
        }
    }
}
