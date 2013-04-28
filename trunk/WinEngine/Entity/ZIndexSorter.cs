using System;
using System.Collections.Generic;

using WinEngine.Util;
using WinEngine.Util.Sort;

namespace WinEngine.Entity
{
    public class ZIndexSorter : InsertionSort<IEntity>
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private static ZIndexSorter INSTANCE;

        private ZIndexComparator zIndexComparator = new ZIndexComparator();
        //================================================================
        //Constructors
        //================================================================
        public ZIndexSorter()
        {
        }

        //================================================================
        //Getter and Setter
        //================================================================
        #region
        public static ZIndexSorter Instance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ZIndexSorter();
            }

            return INSTANCE;
        }

        #endregion
        //================================================================
        //Methodes
        //================================================================
        #region
        public void Sort(IEntity[] array)
        {
            Sort(array, zIndexComparator);
        }

        public void Sort(IEntity[] array, int start, int end)
        {
            Sort(array, start, end, zIndexComparator);
        }

        public void Sort(List<IEntity> list)
        {
            Sort(list, zIndexComparator);
        }

        public void Sort(List<IEntity> list, int start, int end)
        {
            Sort(list, start, end, zIndexComparator);
        }

        #endregion
        //================================================================
        //Methodes overridde
        //================================================================
        #region
        #endregion
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }

    internal class ZIndexComparator : IComparator<IEntity>
    {
        public int Compare(IEntity obj1, IEntity obj2)
        {
            return obj1.ZIndex - obj2.ZIndex;
        }
    }
}
