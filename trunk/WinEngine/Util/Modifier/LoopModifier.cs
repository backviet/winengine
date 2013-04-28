using System;
using System.Collections.Generic;
using System.Diagnostics;

using WinEngine.Entity;
using Microsoft.Xna.Framework;

namespace WinEngine.Util.Modifier
{
    public class LoopModifier<T> : BaseModifier<T>, IModifierListener<T>
    {
        //================================================================
        //Constants
        //================================================================
        public const int LOOP_CONTINUE = -1;

        //================================================================
        //Fields
        //================================================================
        public  event Action<LoopModifier<T>> StartLoopAction;
        public event Action<LoopModifier<T>> EndLoopAction;

        private double  secondsElapsed;

	    private readonly IModifier<T> modifier;

	    private readonly int loopCount;
	    private int loop;
        private double duration;

	    private bool modifierStartedCalled;
	    private bool finishedCached;
        //================================================================
        //Constructors
        //================================================================
        public LoopModifier(IModifier<T> modifier)
            : this(modifier, LOOP_CONTINUE)
        {
        }

        public LoopModifier(IModifier<T> modifier, int loopCount)
            : base()
        {
            this.modifier = modifier;
            this.loopCount = loopCount;
            loop = 0;
            duration = (loopCount == LOOP_CONTINUE) ? float.MaxValue : modifier.Duration * loopCount;

            modifier.AddListener(this);
        }

        //================================================================
        //Getter and Setter
        //================================================================
        #region
        public double SecondElapsedTime { get { return secondsElapsed; } }

        public override double Duration { get { return duration; } set { duration = value; } }

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
        public override double Update(GameTime gameTime, T item)
        {
            if (isFinish)
            {
                return 0;
            }
            else
            {
                double secondElapsedRemaining = gameTime.ElapsedGameTime.TotalSeconds;

                this.finishedCached = false;

                while (secondElapsedRemaining > 0 && !finishedCached)
                {
                    secondElapsedRemaining -= modifier.Update(gameTime, item);
                    //Debug.WriteLine("lap vo han value = " + modifier.Update(gameTime, item));
                }
                //Debug.WriteLine("khong lap vo han");
                finishedCached = false;

                double secondElapsedUsed = gameTime.ElapsedGameTime.TotalSeconds - secondElapsedRemaining;
                this.secondsElapsed += secondElapsedUsed;
                return secondElapsedUsed;
            }
        }

        public override void Reset()
        {
            isFinish = false;
            loop = 0;
            secondsElapsed = 0;

            this.modifierStartedCalled = false;

            modifier.Reset();
        }

        public void TaskOnStart(IModifier<T> modifier, T item)
        {
            if (!modifierStartedCalled)
            {
                modifierStartedCalled = true;
                this.ModifierStart(item);
            }
            if (StartLoopAction != null)
            {
                StartLoopAction(this);
            }
        }

        public void TaskOnFinish(IModifier<T> modifier, T item)
        {
            if (EndLoopAction != null)
            {
                EndLoopAction(this);
            }
            if (loopCount == LOOP_CONTINUE)
            {
                secondsElapsed = 0;
                modifier.Reset();
            }
            else
            {
                this.loop++;
                if (this.loop >= this.loopCount)
                {
                    this.isFinish = true;
                    this.finishedCached = true;
                    this.ModifierFinish(item);
                }
                else
                {
                    this.secondsElapsed = 0;
                    this.modifier.Reset();
                }
            }
        }

        #endregion
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================

    }
}
