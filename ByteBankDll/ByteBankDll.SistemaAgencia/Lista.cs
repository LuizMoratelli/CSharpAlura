using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankDll.SistemaAgencia
{
    // Lista de tipo genérico
    public class Lista<T>
    {
        private T[] _itens;
        private int _proximaPosicao;

        public int Tamanho {
            get {
                return _proximaPosicao;
            }
        }

        //ctor
        // Usando valor padrão fica evidente ao chamar o método, na sobrecarga não
        public Lista(int capacidadeInicial = 4) {
            _itens = new T[capacidadeInicial];  
            _proximaPosicao = 0;
        }

        public void MetodoTeste(int a = 1, int b = 2) {

        }

        public void Adicionar(T item) {
            VerificarCapacidade(_proximaPosicao++);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        private void VerificarCapacidade(int tamanho) {
            if (_itens.Length >= tamanho) {
                return;
            } 

            int novoTamanho = _itens.Length * 2;

            if (novoTamanho < tamanho) {
                novoTamanho = tamanho;
            }

            T[] novoArray = new T[novoTamanho];

            //for (int i = 0; i < _itens.Length; i++) {
            //    novoArray[i] = _itens[i];
            //}
            //_itens = novoArray;

            Array.Copy(_itens, novoArray, _itens.Length);
        }

        public void Remover(T item) {
            int iItem = -1;

            for (int i = 0; i < _proximaPosicao; i++) {
                if (_itens[i].Equals(item)) {
                    iItem = i;
                    break;
                }
            }

            for (int i = iItem; i < _proximaPosicao--; i++) {
                _itens[i] = _itens[i++];
            }

            _proximaPosicao--;
        }

        public T GetItemNoIndice(int indice) {
            if (indice < 0 || indice >= _proximaPosicao) {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        // Indexador
        public T this[int indice] {
            get {
                return GetItemNoIndice(indice);
            }
        }

        // Params permite que o método seja chamada com vários argumentos do mesmo tipo
        public void AdicionarVarios(params T[] itens) {
            foreach (T conta in itens) {
                Adicionar(conta);
            }
        }
    }
}
