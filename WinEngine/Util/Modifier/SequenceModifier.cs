using System;

namespace WinEngine.Util.Modifier
{
    public class SequenceModifier<T> : BaseModifier<T>, IModifierListener<T>
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        public event Action<SequenceModifier<T>> StartSequenceAction;
        public event Action<SequenceModifier<T>> FinishSequenceAction;

        private IModifier<T>[] subSequenceModifiers;
        private int currentSubSequenceModifierIndex;
        private double secondElapsed;
        private readonly double duration;
        private bool finishCached;

        //================================================================
        //Constructors
        //================================================================
        public SequenceModifier(params IModifier<T>[] modifiers) 
            : base()
        {
            if (modifiers.Length == 0)
            {
                throw new Exception("modifiers must be empty");
            }

            for (int i = modifiers.Length - 1; i >= 0; i--)
            {
                if (modifiers[i] == null)
                {
                    throw new Exception("modifiers must be difference from null");
                }
            }

            subSequenceModifiers = modifiers;
            duration = 0;

            for (int i = modifiers.Length - 1; i >= 0; i--)
            {
                duration += modifiers[i].Duration;
            }
            currentSubSequenceModifierIndex = 0;
            modifiers[0].AddListener(this);
        }

        //================================================================
        //Getter and Setter
        //================================================================
        #region
        public double SecondElapsedTime() 
        {
            return secondElapsed;
        }

        public override double Duration
        {
            get { return duration; }
        }

        #endregion
        //================================================================
        //Methodes
        //================================================================
        #region
        #endregion
        //================================================================
        //Methodes overridde
        //================================================================
        #region

        public override double Update(Microsoft.Xna.Framework.GameTime gameTime, T item)
        {
            if (isFinish)
            {
                return 0;
            }

            double secondElapsedTimeRemaining = gameTime.ElapsedGameTime.TotalSeconds;
            finishCached = false;
            while(secondElapsedTimeRemaining > 0 && !finishCached)
            {
                secondElapsedTimeRemaining -= subSequenceModifiers[currentSubSequenceModifierIndex].Update(gameTime, item);
            }
            finishCached = false;
            double secondElapsedUsed = gameTime.ElapsedGameTime.TotalSeconds - secondElapsedTimeRemaining;
            secondElapsed += secondElapsedUsed;
            return secondElapsedUsed;
        }

        public override void Reset()
        {
            if (isFinish) 
            {
                subSequenceModifiers[subSequenceModifiers.Length - 1].RemoveListener(this);
            }
            else
            {
                subSequenceModifiers[currentSubSequenceModifierIndex].RemoveListener(this);
            }
            currentSubSequenceModifierIndex = 0;
            isFinish = false;
            secondElapsed = 0;
            subSequenceModifiers[0].AddListener(this);

            for (int i = subSequenceModifiers.Length - 1; i >= 0; i--)
            {
                subSequenceModifiers[i].Reset();
            }
        }

        public void TaskOnStart(IModifier<T> modifier, T item)
        {
            if (currentSubSequenceModifierIndex == 0)
            {
                ModifierStart(item);
            }
            if (StartSequenceAction != null)
            {
                StartSequenceAction(this);
            }
        }

        public void TaskOnFinish(IModifier<T> modifier, T item)
        {
            if (FinishSequenceAction != null)
            {
                FinishSequenceAction(this);
            }
            modifier.RemoveListener(this);
            currentSubSequenceModifierIndex ++;
            if (currentSubSequenceModifierIndex < subSequenceModifiers.Length) 
            {
                subSequenceModifiers[currentSubSequenceModifierIndex].AddListener(this);
            }
            else 
            {
                isFinish = true;
                finishCached = true;
                ModifierFinish(item);
            }
        }
        #endregion
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================

    }
}
