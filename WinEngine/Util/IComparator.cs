using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinEngine.Util
{
    public interface IComparator<T>
    {
        int Compare(T obj1, T obj2);
    }
}
