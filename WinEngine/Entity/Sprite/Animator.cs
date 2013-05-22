using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using WinEngine.Util;

namespace WinEngine.Entity.Sprite
{
    public class Animator : IUpdateHandler
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private bool isAnimationProcess;
        private bool isFinished;

        private int frameIndex;
        private int totalFrame;

        private int length;
        private int startFrame;
        public int countLoop;
        private int currentLoop;
        private int timePerCycle;

        private int duration;
        private double AnimationProcess;
        //================================================================
        //Constructors
        //================================================================
        public Animator(int time, int frame)
        {
            duration = time;
            totalFrame = frame;

            frameIndex = 0;
            isAnimationProcess = false;
            currentLoop = 0;
            timePerCycle = duration * frame;
            countLoop = AnimatedSprite.UNLIMITED;
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public int TotalFrame { get { return totalFrame; } set { totalFrame = value; } }
        public int Index { get { return frameIndex; } }
        public double TimeProcess { get { return AnimationProcess; } }
        public int CurrentLoop { get { return currentLoop; } }
        public int Duration { get { return duration; } }
        public bool IsFinished { get { return isFinished; } }

        //================================================================
        //Methodes
        //================================================================
        public void Start()
        {
            isAnimationProcess = true;
            startFrame = 0;
            frameIndex = 0;
            length = totalFrame;
        }

        public void Start(int time)
        {
            isAnimationProcess = true;
            duration = time;
            startFrame = 0;
            frameIndex = 0;
            timePerCycle = time * totalFrame;
            length = totalFrame;
        }

        public void Start(int time, int start, int end)
        {
            isAnimationProcess = true;
            duration = time;
            frameIndex = 0;
            startFrame = start;
            length = end - startFrame;
            timePerCycle = time * length;
        }

        public void Stop()
        {
            duration = 0;
            isAnimationProcess = false;
        }

        public void Stop(int index)
        {
            duration = 0;
            frameIndex = index;
            isAnimationProcess = false;
        }

        //================================================================
        //Methodes overridde
        //================================================================
        public void Update(GameTime gameTime)
        {
            if (!isAnimationProcess) return;

            AnimationProcess += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (AnimationProcess > timePerCycle * currentLoop)
            {
                if (currentLoop == countLoop)
                {
                    isFinished = true;
                    isAnimationProcess = false;
                }
                currentLoop++;
            }

            int index = 0;

            index = (int)(AnimationProcess / duration);

            frameIndex = index % length;
            frameIndex += startFrame;
        }

        public void Reset()
        {
            isFinished = false;
            AnimationProcess = 0;
            frameIndex = 0;
            currentLoop = 0;
        }

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================

    }
}
