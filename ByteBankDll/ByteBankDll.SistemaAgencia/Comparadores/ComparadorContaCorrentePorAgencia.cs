using ByteBankDll.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankDll.SistemaAgencia.Comparadores
{
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y) {
            if (x.Agencia == y.Agencia) 
                return 0;
            else if (x.Agencia < y.Agencia || y == null)
                return -1;
            else 
                return 1;
            // Poderia usar x.Agencia.CompareTo(y.Agencia), pois o int já implementa o IComparable
        }
    }
}
