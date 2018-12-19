using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections1
{
    static class ExtensaoLista
    {
        public static void AddMultiple<T>(this List<T> list, params T[] items)
        {
            foreach (var item in items)
            {
                list.Add(item);
            }
        }
    }
}
