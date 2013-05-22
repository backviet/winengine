using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

using WinEngine.Entity;
using WinEngine.Util;

namespace WinEngine.Screen.Scene
{
    public abstract class Layer
    {
        //================================================================
        //Constants
        //================================================================
        public const int CHILDREN_DEFAULT = 4;

        //================================================================
        //Fields
        //================================================================
        protected List<IEntity> children = new List<IEntity>(CHILDREN_DEFAULT);

        //================================================================
        //Constructors
        //================================================================

        //================================================================
        //Getter and Setter
        //================================================================
        #region
        public bool NeedSort { get; set; }

        #endregion
        //================================================================
        //Methodes
        //================================================================
        #region
        public void Sort()
        {
            ZIndexSorter.Instance().Sort(children);
        }

        public void Sort(IComparator<IEntity> comparator)
        {
            ZIndexSorter.Instance().Sort(children, comparator);
        }

        #endregion
        //================================================================
        //Methods for/from SuperClass/Interfaces
        //================================================================
        #region
        public abstract void Create();
        public abstract void OnTouchEvent(TouchLocation touchLocation);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw();
        public abstract void Reset();

        #endregion
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
