using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
// Referencias >> Adicionar >> Projetos >> Projeto;
using ByteBankDll.Modelos;
using ByteBankDll.Modelos.Funcionarios;
using ByteBankDll.SistemaAgencia.Extensoes;
using Humanizer;

namespace ByteBankDll.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args) {
            
            Console.ReadLine();
        }

        static void LinqLambda() {
            // Lista genérica
            Lista<int> idades = new Lista<int>();

            //List<ContaCorrente> listaContas = new List<ContaCorrente>();
            var listaContas = new List<ContaCorrente>();
            listaContas.AdicionarVarios(
                new ContaCorrente(1, 3),
                new ContaCorrente(4, 2),
                new ContaCorrente(2, 1)
            );

            //IOrderedEnumerable<ContaCorrente> contasOrdenadas = listaContas.OrderBy(conta => conta.Numero);
            // Mas não trata o null
            // x => y expressão lambda
            //var contasOrdenadas = listaContas.OrderBy(conta => conta.Numero);
            var contasOrdenadas = listaContas.OrderBy(conta => { 
                if (conta == null) 
                    return int.MaxValue;

                return conta.Numero; 
            });

            var contasOrdenadas2 = listaContas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);


            foreach (var conta in contasOrdenadas) {
                if (conta != null)
                    Console.WriteLine(conta.Numero);
            }

            // Inferencia de tipo de variável
            Lista<GerenteDeConta> gerenciador = new Lista<GerenteDeConta>();
            // É igual à
            var gerenciador2 = new Lista<GerenteDeConta>();

            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            // Podendo-se passar apenas um parametro, o outro fica o valor padrão
            lista.MetodoTeste(b: 5);

            // Para comparar ou usar .Sort em classes precisa implementar a interface IComparable
            // no .Sort() da pra passar um new Comparable

            // IOrderedEnumerable<ContaCorrente> listaOrdenada = contas.OrderBy(conta => conta.Numero);
            // Foreach na listaOrdenada
        }

        static void Array() {
            // Sintatic Sugar de array
            ContaCorrente[] contas = new ContaCorrente[] {
                new ContaCorrente(123, 123),
                new ContaCorrente(234, 234),
                new ContaCorrente(345, 345),
            };

            for (int i = 0; i < contas.Length; i++) {
                if (contas[i] != null)
                    Console.WriteLine($"Conta: {contas[i].Numero}, Agencia: {contas[i].Agencia}, Saldo: {contas[i].Saldo}");
            }

            Console.ReadLine();
        }

        static void TestaURL() {
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
