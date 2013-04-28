using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinEngine.Util.Sort
{
    public abstract class Sorter<T>
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

        public abstract void Sort(T[] array, int start, int end, IComparator<T> comparator);
        public abstract void Sort(List<T> list, int start, int end, IComparator<T> comparator);

	    // ===========================================================
	    // Methods
	    // ===========================================================

        public void Sort(T[] array, IComparator<T> comparator)
        {
            Sort(array, 0, array.Length, comparator);
        }

        public void Sort(List<T> list, IComparator<T> comparator)
        {
            Sort(list, 0, list.Count, comparator);
        }

	    // ===========================================================
	    // Inner and Anonymous Classes
	    // ===========================================================
    }
}
