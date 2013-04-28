using System;
using System.Collections.Generic;

using WinEngine.Entity;
using Microsoft.Xna.Framework;

namespace WinEngine.Util.Modifier
{
    public class ModifierList<T> : List<IModifier<T>>, IUpdateHandler
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private T taget;

        //================================================================
        //Constructors
        //================================================================
        public ModifierList(T item) 
            : this (item, 4)
        {
            
        }

        public ModifierList(T item, int capacity)
            : base(capacity)
        {
            this.taget = item;
        }
        //================================================================
        //Getter and Setter
        //================================================================

        //================================================================
        //Methodes
        //================================================================

        //================================================================
        //Methodes overridde
        //================================================================
        public void AddModifier(IModifier<T> modifier) 
        {
            if (modifier == null)
            {
                throw new Exception("modifier must be diffrent from null");
            }

            if (this.Contains(modifier))
            {
                return;
            }

            base.Add(modifier);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                IModifier<T> mod = this[i];
                mod.Update(gameTime, taget);
                if (mod.Finish && mod.AutoUnregisterListener)
                {
                    this.Remove(mod);
                }
            }
        }

        public void Reset()
        {
            foreach (IModifier<T> mod in this)
            {
                mod.Reset();
            }
        }

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
