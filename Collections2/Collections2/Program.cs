using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections2
{
    class Program
    {
        static void Main(string[] args)
        {
            var meses = new List<string>
            {
                "Janeiro",
                "Fevereiro",
                "Março"
            };
            foreach (var item in meses)
            {
                Console.WriteLine(item);
            }
        }

        private static void ImplementandoCovariancia()
        {
            //convertendo(implicita) string -> object
            string titulo = "meses";
            object obj = titulo;
            Console.WriteLine(obj);

            //convertendo List<string> -> List<object>
            IList<string> listaMeses = new List<string>
            {
                "Janeiro",
                "Fevereiro",
                "Março"
            };
            //IList<object> listaObj = listaMeses;

            //convertendo(implicita) string[] -> object[]
            //Covariancia mesmo nível (EVITAR)
            string[] arrayMeses = new string[]
            {
                "Janeiro",
                "Fevereiro",
                "Março"
            };
            object[] arrayObj = arrayMeses;
            arrayObj[0] = "Primeiro Mês";
            //Apesar de ser declarado como array de objetos ele é um array de string
            //arrayObj[0] = 1;
            Console.WriteLine(arrayObj);
            foreach (var item in arrayObj)
            {
                Console.WriteLine(item);
            }

            //convertendo(implicito) List<string> -> IEnumerable<object>;
            //Covariancia Segura
            IEnumerable<object> enumObj = listaMeses;
            foreach (var item in enumObj)
            {
                Console.WriteLine(item);
            }
            //enumObj[0] = 123;
        }

        private static void ImplementandoLINQTerceiraParte()
        {
            string[] seq1 = { "janeiro", "fevereiro", "março" };
            string[] seq2 = { "fevereiro", "MARÇO", "abril" };

            //A + B
            var consulta = seq1.Concat(seq2);
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //A U B
            var consulta2 = seq1.Union(seq2);
            foreach (var item in consulta2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //A U B
            var consulta3 = seq1.Union(seq2, StringComparer.InvariantCultureIgnoreCase);
            foreach (var item in consulta3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //A /\ B
            var consulta4 = seq1.Intersect(seq2);
            foreach (var item in consulta4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //A - B
            var consulta5 = seq1.Except(seq2);
            foreach (var item in consulta5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void ImplementandoLINQSegundaParte()
        {
            List<Mes> meses = new List<Mes>
            {
                new Mes("Janeiro", 31),
                new Mes("Fevereiro", 28),
                new Mes("Março", 31),
                new Mes("Abril", 30),
                new Mes("Maio", 31),
                new Mes("Junho", 30),
                new Mes("Julho", 31),
                new Mes("Agosto", 31),
                new Mes("Setembro", 30),
                new Mes("Outubro", 31),
                new Mes("Novembro", 30),
                new Mes("Dezembro", 31)
            };

            //QUantidade de meses para obter
            var consulta = meses.Take(3);

            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var consulta2 = meses.Skip(3);
            foreach (var item in consulta2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var consulta3 = meses.Skip(6).Take(3);
            foreach (var item in consulta3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var consulta4 = meses.TakeWhile(m => !m.Nome.StartsWith("S"));
            foreach (var item in consulta4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var consulta5 = meses.SkipWhile(m => !m.Nome.StartsWith("S"));
            foreach (var item in consulta5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void ImplementandoLINQPrimeiraParte()
        {
            List<Mes> meses = new List<Mes>
            {
                new Mes("Janeiro", 31),
                new Mes("Fevereiro", 28),
                new Mes("Março", 31),
                new Mes("Abril", 30),
                new Mes("Maio", 31),
                new Mes("Junho", 30),
                new Mes("Julho", 31),
                new Mes("Agosto", 31),
                new Mes("Setembro", 30),
                new Mes("Outubro", 31),
                new Mes("Novembro", 30),
                new Mes("Dezembro", 31)
            };

            //LINQ = Consulta Integrada à Linguagem

            IEnumerable<string>
                consulta = meses
                            //Verifica se
                            .Where(m => m.QuantidadeDias == 31)
                            //Organiza
                            .OrderBy(m => m.Nome)
                            //Altera o atributo
                            .Select(m => m.Nome.ToUpper());

            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }

        private static void ImplementandoJaggedArray()
        {
            string[][] familias = new string[3][];
            //{
            //    { "Fred", "Vilma", "Pedrita" },
            //    { "Homer", "Marge", "Lisa", "Bart", "Maggie" },
            //    { "Florinda", "Kiko" }
            //};
            familias[0] = new string[] { "Fred", "Vilma", "Pedrita" };
            familias[1] = new string[] { "Homer", "Marge", "Lisa", "Bart", "Maggie" };
            familias[2] = new string[] { "Florinda", "Kiko" };

            foreach (var familia in familias)
            {
                Console.WriteLine(string.Join(", ", familia));
            }
        }

        private static void ImplementandoArrayMultiDimensional()
        {
            string[,] resultados = new string[4, 3];
            //{
            //    { "Alemanha", "Espanha", "Itália" },
            //    { "Argentina", "Holanda", "França" },
            //    { "Holanda", "Alemanha", "Alemanha" }
            //};

            resultados[0, 0] = "Alemanha";
            resultados[1, 0] = "Argentina";
            resultados[2, 0] = "Holanda";
            resultados[3, 0] = "Brasil";

            resultados[0, 1] = "Espanha";
            resultados[1, 1] = "Holanda";
            resultados[2, 1] = "Alemanha";
            resultados[3, 1] = "Uruguai";

            resultados[0, 2] = "Itália";
            resultados[1, 2] = "França";
            resultados[2, 2] = "Alemanha";
            resultados[3, 2] = "Portugual";

            //foreach (var selecao in resultados)
            //{
            //    Console.WriteLine(selecao);
            //}
            for (int copa = 0; copa <= resultados.GetUpperBound(1); copa++)
            {
                int ano = 2014 - copa * 4;
                //tabular com 12 caracteres
                Console.Write(ano.ToString().PadRight(12));
            }
            Console.WriteLine();

            //Pega maior indíce de uma posição
            for (int posicao = 0; posicao <= resultados.GetUpperBound(0); posicao++)
            {
                for (int copa = 0; copa <= resultados.GetUpperBound(1); copa++)
                {
                    Console.Write(resultados[posicao, copa].PadRight(12));
                }
                Console.WriteLine();
            }
        }

        private static void ImplementandoSortedSet()
        {
            //Hashset = desordenado
            //SortedSet = ordenado, utiliza uma ordem binária, não possui chaves apenas valores
            ISet<string> alunos = new SortedSet<string>(new ComparadorMinusculo())
            {
                "Vanesa",
                "Ana",
                "Rafael",
                "Priscila"
            };

            alunos.Add("João");
            //Não insere
            alunos.Add("Rafael");
            //Insere caso o ComparadorMinusculo não seja evidenciado
            alunos.Add("ANA");

            Console.WriteLine();
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            ISet<string> outroConjunto = new HashSet<string>();
            //é um subconjunto de outro?
            alunos.IsSubsetOf(outroConjunto);

            //é um superconjunto de outro?
            alunos.IsSupersetOf(outroConjunto);

            //São identicos?
            alunos.SetEquals(outroConjunto);

            //diferença de conjuntos
            alunos.ExceptWith(outroConjunto);

            //intersecção dos conjuntos
            alunos.IntersectWith(outroConjunto);

            //Quais elementos que não estão na intersecção
            alunos.SymmetricExceptWith(outroConjunto);

            //União
            alunos.UnionWith(outroConjunto);
        }

        private static void ImplementandoSortedDictionary()
        {
            //SortedDictionary exibe semelhante a sortedList, mas a implementação interna é diferente,
            //as chaves são uma KeyCollection e para valores um ValueCollection
            //Chave em estrutura de árvores binárias balanceada
            //Mais ágil
            IDictionary<string, Aluno> sorted = new SortedDictionary<string, Aluno>();
            sorted.Add("VT", new Aluno("Vanessa", 34672));
            sorted.Add("AL", new Aluno("Ana", 5617));
            sorted.Add("RN", new Aluno("Rafael", 17645));
            sorted.Add("WM", new Aluno("Wanderson", 11287));

            Console.WriteLine();
            foreach (var aluno in sorted)
            {
                Console.WriteLine(aluno);
            }
        }

        private static void ImplementandoSortedList()
        {
            //SortedList = dicionario ordenado (uma lista de chaves e outra de valores)
            //Melhor com dados pré estabelecidos
            IDictionary<string, Aluno> sorted = new SortedList<string, Aluno>();
            sorted.Add("VT", new Aluno("Vanessa", 34672));
            sorted.Add("AL", new Aluno("Ana", 5617));
            sorted.Add("RN", new Aluno("Rafael", 17645));
            sorted.Add("WM", new Aluno("Wanderson", 11287));

            Console.WriteLine();
            foreach (var aluno in sorted)
            {
                Console.WriteLine(aluno);
            }
        }

        private static void ImplementandoIDictionary()
        {
            //chave, tipoValor
            //Chaves são de maneira não ordenada, e sim do código de espalhamento
            IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>();
            alunos.Add("VT", new Aluno("Vanessa", 34672));
            alunos.Add("AL", new Aluno("Ana", 5617));
            alunos.Add("RN", new Aluno("Rafael", 17645));
            alunos.Add("WM", new Aluno("Wanderson", 11287));

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            alunos.Remove("AL");
            alunos.Add("MO", new Aluno("Marcelo", 12345));

            Console.WriteLine();
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
        }
    }
}