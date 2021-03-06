﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections1
{
    class Program
    {
        static Queue<string> pedagio = new Queue<string>();

        static void Main(string[] args)
        {
            string veiculo = "carro";
            pedagio.Enqueue(veiculo);

            veiculo = "van";
            pedagio.Enqueue(veiculo);

            pedagio.Dequeue();

            // saber o proximo carro
            Console.WriteLine(pedagio.Peek());

            if (pedagio.Any())
            {
                pedagio.Dequeue();
            }

            foreach (var carro in pedagio)
            {
                Console.WriteLine(carro);
            }

            Console.ReadLine();
        }

        private static void EstudandoStack()
        {
            var navegador = new Navegador();

            navegador.NavegarPara("google.com");
            navegador.NavegarPara("alura.com.br");

            navegador.Anterior();
            navegador.Anterior();
            navegador.Proximo();
            navegador.Proximo();
        }

        private static void EstudandoLinkedLists()
        {
            List<string> frutas = new List<string>
            {
                "abacate", "banana", "caqui"
            };

            foreach (var fruta in frutas)
            {
                Console.WriteLine(fruta);
            }

            LinkedList<string> dias = new LinkedList<string>();

            var d4 = dias.AddFirst("Quarta");

            var d2 = dias.AddBefore(d4, "Segunda");

            var d3 = dias.AddAfter(d2, "Terça");

            var d7 = dias.AddLast("Sábado");

            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }

            var quarta = dias.Find("Quarta");
            dias.Remove(d4);
            dias.Remove("Segunda");
            dias.RemoveFirst();
            dias.RemoveLast();

            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }
        }

        private static void MatriculasColecoes()
        {
            Curso csharpColecoes = new Curso("C# Coleções", "Marcelo Oliveira");
            csharpColecoes.Adicionar(new Aula("Trabalhando com Listas", 21));
            csharpColecoes.Adicionar(new Aula("Criando uma Aula", 20));
            csharpColecoes.Adicionar(new Aula("Modelando com Coleções", 24));

            var a1 = new Aluno("Luiz", 1);
            var a2 = new Aluno("Ike", 2);
            var a3 = new Aluno("Camila", 3);

            csharpColecoes.Matricular(a1);
            csharpColecoes.Matricular(a2);
            csharpColecoes.Matricular(a3);

            Console.WriteLine("Alunos matriculados");
            foreach (var aluno in csharpColecoes.Alunos)
            {
                Console.WriteLine(aluno.Nome);
            }

            Console.WriteLine($"O aluno a1 {a1.Nome} está matriculado?");
            Console.WriteLine(csharpColecoes.EstaMatriculado(a1));

            Console.WriteLine($"Qual o aluno da matrícula 1?");
            try
            {
                Console.WriteLine(csharpColecoes.BuscaMatriculado(1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            var a4 = new Aluno("Teste", 4);
            csharpColecoes.SubstituiAluno(a4);
        }

        private static void ImplementandoHash()
        {
            // Set de Alunos
            // Conjunto
            ISet<string> alunos = new HashSet<string>();
            alunos.Add("Teste");
            alunos.Add("Rafael");
            alunos.Add("Gustavo");

            Console.WriteLine(alunos);
            Console.WriteLine(string.Join(",", alunos));

            alunos.Add("Camila");
            alunos.Add("Luiz");

            alunos.Remove("Teste");
            alunos.Add("Marcelo");

            Console.WriteLine(string.Join(",", alunos));

            // Conjunto não garante a posição
            alunos.Add("Marcelo");
            // Evita a duplicidade, não faz nada

            // Vantagem: mais rápido
            // Não vare do primeiro ao ultimo, utiliza a tabela de espalhamento
            // Escalável em performance, mas consome mais memória

            // Para ordenar basta colocar em lista
            List<string> alunosEmLista = new List<string>(alunos);
            alunosEmLista.Sort();

            Console.WriteLine(string.Join(", ", alunosEmLista));

            Console.ReadLine();
        }

        private static void TestesAulas()
        {
            //var aulaIntro = new Aula("Introdução às Coleções", 20);
            //var aulaModelando = new Aula("Modelando a Classe Aula", 18);
            //var aulaSets = new Aula("Trabalhando com Conjuntos", 16);

            //var aulas = new List<Aula>();
            //aulas.AddMultiple(aulaIntro, aulaModelando, aulaSets);

            //aulas.Sort();

            //ImprimirAulas(aulas);

            //aulas.Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo));

            Curso csharpColecoes = new Curso("C# Collections", "Marcelo Oliveira");
            // Exposição indecente, code smell.
            csharpColecoes.Adicionar(new Aula("Trabalhando com Listas", 21));
            csharpColecoes.Adicionar(new Aula("Criando uma aula", 20));
            csharpColecoes.Adicionar(new Aula("Modelando com Coleções", 19));

            //csharpColecoes.Aulas.Sort();
            var aulasCopiadas = new List<Aula>(csharpColecoes.Aulas);
            aulasCopiadas.Sort();

            ImprimirAulas(csharpColecoes.Aulas);
            ImprimirAulas(aulasCopiadas);

            Console.WriteLine(csharpColecoes.TempoTotal);
            Console.WriteLine(csharpColecoes);

            Console.ReadLine();
        }

        private static void ImprimirAulas(IList<Aula> aulas)
        {
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }
        }

        private static void ListProgram()
        {
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com Conjuntos";

            //var listaAulas = new List<string>()
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaSets
            //};

            var listaAulas = new List<string>();

            listaAulas.Add(aulaIntro);
            listaAulas.Add(aulaModelando);
            listaAulas.Add(aulaSets);

            imprimirLista(listaAulas);

            Console.WriteLine($"A primeira aula é: {listaAulas.First()}");
            Console.WriteLine($"A última aula é: {listaAulas.Last()}");

            //Console.WriteLine($"Primeira aula 'Trabalhando' é: " +
            //    $"{listaAulas.First(aula => aula.Contains("Trabalhando"))}");

            // Trata se não tiver nenhum que contém para não dar exceção
            Console.WriteLine($"Primeira aula 'Trabalhando' é: " +
                $"{listaAulas.FirstOrDefault(aula => aula.Contains("Trabalhando"))}");

            Console.WriteLine($"A última aula 'Trabalhando' é:" +
                $"{listaAulas.Last(aula => aula.Contains("Aula"))}");

            // Inverte a ordem das aulas
            listaAulas.Reverse();

            // indice para remover
            listaAulas.RemoveAt(listaAulas.Count - 1);

            // Organiza em ordem alfabética
            listaAulas.Sort();

            // Copia os 2 ultimos elementos
            var listaTemp = listaAulas.GetRange(listaAulas.Count - 2, 2);
            imprimirLista(listaTemp);

            // clonagem
            var listaClone = new List<string>(listaAulas);
            imprimirLista(listaClone);

            // Remove os 2 ultimos 
            listaClone.RemoveRange(listaClone.Count - 2, 2);
        }

        private static void imprimirLista(List<string> aulas)
        {
            //foreach (var aula in aulas)
            //{
            //    Console.WriteLine(aula);
            //}

            //for (int i = 0; i < aulas.Count; i++)
            //{
            //    Console.WriteLine(aulas[i]);
            //}

            aulas.ForEach(aula => 
            {
                Console.WriteLine(aula);
            });
        }
        
        private static void ArrayProgram()
        {
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com Conjuntos";

            //string[] aulas = new string[]
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaSets
            //};

            string[] aulas = new string[3];
            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSets;

            // cw
            Console.WriteLine(aulas);
            Imprimir(aulas);

            Console.WriteLine(aulas[0]);
            Console.WriteLine(aulas[aulas.Length - 1]);

            aulaIntro = "Trabalhando com Arrays";
            Imprimir(aulas);

            aulas[0] = "Trabalhando com Arrays";

            // Primeiro match
            Console.WriteLine($"Aula modelando está no índice " + Array.IndexOf(aulas, aulaModelando));
            // Ultimo match
            Console.WriteLine(Array.LastIndexOf(aulas, aulaModelando));

            // Array invertido
            // Idempotente (se executar 2x volta ao normal)
            Array.Reverse(aulas);
            Imprimir(aulas);

            // Redimensionar o array
            // Copia interna invisível
            Array.Resize(ref aulas, 2);
            Imprimir(aulas);

            Array.Resize(ref aulas, 3);
            // 2 = número mágico
            aulas[aulas.Length - 1] = "Conclusão";
            Imprimir(aulas);

            Array.Sort(aulas);
            Imprimir(aulas);

            string[] copia = new string[2];
            // Copia os 2 ultimos elementos para o copia
            Array.Copy(aulas, 1, copia, 0, 2);

            string[] clone = aulas.Clone() as string[];
            Imprimir(clone);

            // Limpa os 2 ultimos elementos
            Array.Clear(clone, 1, 2);
            Imprimir(clone);
        }

        // Ctrl + . para transformar seleção em método
        private static void Imprimir(string[] aulas)
        {
            //foreach (var aula in aulas)
            //{
            //    Console.WriteLine(aula);
            //}

            for (int i = 0; i < aulas.Length; i++)
            {
                Console.WriteLine(aulas[i]);
            }
        }
    }
}
