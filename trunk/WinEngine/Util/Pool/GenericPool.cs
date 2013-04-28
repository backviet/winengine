using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WinEngine.Util.Pool
{
    public abstract class GenericPool<T> : IDisposable
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        public List<T> freeObject;
        private bool isCheck = false;

        //================================================================
        //Constructors
        //================================================================
        public GenericPool(int capacity)
        {
            freeObject = new List<T>(capacity);
        }

        public GenericPool()
        {
            freeObject = new List<T>(16);
        }
        //================================================================
        //Getter and Setter
        //================================================================
        public void Check(bool isCheck)
        {
            this.isCheck = isCheck;
        }

        //================================================================
        //Methodes
        //================================================================
        public abstract T NewObject();
        public abstract void OnRecycle(T obj);

        public T Obtains()
        {
            T obj;
            if (freeObject.Count > 0)
            {
                obj = freeObject[0];
                freeObject.RemoveAt(0);
            }
            else
            {
                obj = NewObject();
            }

            return obj;
        }

        public void Recycle(T obj)
        {
            OnRecycle(obj);

            freeObject.Add(obj);
        }

        public virtual void Dispose()
        {

        }
        //================================================================
        //Methodes overridde
        //================================================================

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================

    }
}
