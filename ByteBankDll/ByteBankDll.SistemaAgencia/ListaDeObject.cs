using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankDll.SistemaAgencia
{
    public class ListaDeObject
    {
        private Object[] _itens;
        private int _proximaPosicao;

        public int Tamanho {
            get {
                return _proximaPosicao;
            }
        }

        //ctor
        // Usando valor padrão fica evidente ao chamar o método, na sobrecarga não
        public ListaDeObject(int capacidadeInicial = 4) {
            _itens = new Object[capacidadeInicial];  
            _proximaPosicao = 0;
        }

        public void MetodoTeste(int a = 1, int b = 2) {

        }

        public void Adicionar(Object item) {
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

            Object[] novoArray = new Object[novoTamanho];

            //for (int i = 0; i < _itens.Length; i++) {
            //    novoArray[i] = _itens[i];
            //}
            //_itens = novoArray;

            Array.Copy(_itens, novoArray, _itens.Length);
        }

        public void Remover(Object item) {
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
            _itens[_proximaPosicao] = null;
        }

        public Object GetItemNoIndice(int indice) {
            if (indice < 0 || indice >= _proximaPosicao) {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        // Indexador
        public Object this[int indice] {
            get {
                return GetItemNoIndice(indice);
            }
        }

        // Params permite que o método seja chamada com vários argumentos do mesmo tipo
        public void AdicionarVarios(params Object[] itens) {
            foreach (Object conta in itens) {
                Adicionar(conta);
            }
        }
    }
}
