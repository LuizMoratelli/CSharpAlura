using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankDll.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        // método genérico de extensão de classe genérica não precisa evidenciar tipo
        // lista.AdicionarVarios(1, 2);
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens) {
            foreach (T item in itens) {
                lista.Add(item);
            }
        }
    }
}
