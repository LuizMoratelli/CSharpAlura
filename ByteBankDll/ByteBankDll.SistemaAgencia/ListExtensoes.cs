using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankDll.SistemaAgencia
{
    public static class ListExtensoes
    {
        // Uma classe static só pode ter métodos static
        // Método de Extensão
        // O this antes do parametro em um método static de uma classe static permite chamar o método a partir de uma classe
        // List.AdicionarVarios(1, 2, 3);
        public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens) {
            foreach (int item in itens) {
                listaDeInteiros.Add(item);
            }
        }
    }
}
