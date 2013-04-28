using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinEngine.Util.Sort
{
    public class InsertionSort<T> : Sorter<T>
    {
        // ===========================================================
        // Constants
        // ===========================================================

        // ===========================================================
        // Fields
        // ===========================================================

        // ===========================================================
        // Constructors
        // ===========================================================

        // ===========================================================
        // Getter & Setter
        // ===========================================================

        // ===========================================================
        // Methods for/from SuperClass/Interfaces
        // ===========================================================

        /**
         * Sap xep theo chieu tang dan thuoc tinh
         * */
        public override void Sort(T[] array, int start, int end, IComparator<T> comparator)
        {
            for (int i = start + 1; i < end; i++)
            {
                T current = array[i];
                T prev = array[i - 1];

                if (comparator.Compare(current, prev) < 0)
                {
                    int j = i;
                    do
                    {
                        array[j--] = prev;
                    } while (j > start && comparator.Compare(current, prev = array[j - 1]) < 0);
                }
            }
        }

        public override void Sort(List<T> list, int start, int end, IComparator<T> comparator)
        {
            for (int i = start + 1; i < end; i++)
            {
                T current = list[i];
                T prev = list[i - 1];

                if (comparator.Compare(current, prev) < 0)
                {
                    int j = i;
                    do
                    {
                        list[j--] = prev;
                    } while (j > start && comparator.Compare(current, prev = list[j - 1]) < 0);
                }
            }
        }

        // ===========================================================
        // Methods
        // ===========================================================

        // ===========================================================
        // Inner and Anonymous Classes
        // ===========================================================
       
    }
}
