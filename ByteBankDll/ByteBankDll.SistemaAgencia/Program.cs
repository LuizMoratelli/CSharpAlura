using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            ContaCorrente conta = new ContaCorrente(123, 133);
            
            DateTime dataFimPagamento = new DateTime(2018, 8, 17);
            DateTime dataCorrente = DateTime.Now;

            // Quando subtrai-se uma data de outra utiliza-se TimeSpan
            TimeSpan diferenca = dataFimPagamento - dataCorrente;

            // Ferramentas >> Gerenciador de Pacotes Nuget >> Console
            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);
            Console.ReadLine();
        }
    }
}
