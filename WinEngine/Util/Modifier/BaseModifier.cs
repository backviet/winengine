using System.Collections.Generic;
using System;

using Microsoft.Xna.Framework;

namespace WinEngine.Util.Modifier
{
    public abstract class BaseModifier<T> : IModifier<T>
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private List<IModifierListener<T>> modifierListener = new List<IModifierListener<T>>();

        public event Action<BaseModifier<T>> StartModifierAction;
        public event Action<BaseModifier<T>> FinishModifierAction;

        protected bool isFinish = false;

        //================================================================
        //Constructors
        //================================================================
        public BaseModifier()
        {
            AutoUnregisterListener = true;
        }

        public BaseModifier(IModifierListener<T> listener)
            : this()
        {
            this.AddListener(listener);
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public virtual double Duration { get; set; }

        //================================================================
        //Methodes
        //================================================================
        public void ModifierStart(T item)
        {
            for (int i = 0; i < modifierListener.Count; i++)
            {
                IModifierListener<T> listener = modifierListener[i];
                listener.TaskOnStart(this, item);
            }

            if (StartModifierAction != null)
            {
                StartModifierAction(this);
            }
        }

        public void ModifierFinish(T item)
        {
            for (int i = 0; i < modifierListener.Count; i++)
            {
                IModifierListener<T> listener = modifierListener[i];
                listener.TaskOnFinish(this, item);
            }

            if (FinishModifierAction != null)
            {
                FinishModifierAction(this);
            }
        }
        //================================================================
        //Methodes overridde
        //================================================================
        public bool Finish { get { return isFinish; } }

        public bool AutoUnregisterListener { get; set; }

        public void AddListener(IModifierListener<T> listener)
        {
            if (listener == null || modifierListener.Contains(listener))
            {
                return;
            }
            modifierListener.Add(listener);
        }

        public void RemoveListener(IModifierListener<T> listener)
        {
            if (listener == null || !modifierListener.Contains(listener))
            {
                return;
            }
            modifierListener.Remove(listener);
        }
        
        public virtual double Update(GameTime gameTime, T item)
        {
            return 0;
        }

        public virtual void Reset()
        {
        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
