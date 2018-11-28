using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Extensions
    {
        public static T[] Insert<T>(this T[] array, int startIndex, T item)
        {
            var tempList = array.ToList();
            tempList.Insert(startIndex, item);
            array = tempList.ToArray();
            return array;
        }
    }
}
