using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WinEngine.Util;
using WinEngine.Texture;

namespace WinEngine.Entity.Sprite
{
    public class AnimatedSprite : GameEntity
    {
        //================================================================
        //Constants
        //================================================================
        public const int UNLIMITED = int.MaxValue;

        //================================================================
        //Fields
        //================================================================
        protected TextureRegion[] regions;

        protected Animator animation;

        public event Action<AnimatedSprite> StartAnimation;
        public event Action<AnimatedSprite> FinishAnimation;

        protected List<IUpdateHandler> updates = null;

        private int countLoop;

        protected int frameIndex;

        //================================================================
        //Constructors
        //================================================================
        public AnimatedSprite(Vector2 position, int time, bool isUpdate, params TextureRegion[] regions)
            : base(position)
        {
            this.regions = regions;
            if (isUpdate) updates = new List<IUpdateHandler>();

            animation = new Animator(time, regions.Length);
            countLoop = UNLIMITED;
        }

        public AnimatedSprite(float x, float y, int time, bool isUpdate, params TextureRegion[] regions)
            : base(x, y)
        {
            this.regions = regions;
            if (isUpdate) updates = new List<IUpdateHandler>();

            countLoop = UNLIMITED;
            animation = new Animator(time, regions.Length);
        }
        //================================================================
        //Getter and Setter
        //================================================================

        public int CountLoop
        {
            get { return countLoop; }
            set
            { 
                this.countLoop = value;
                animation.countLoop = countLoop;
            }
        }

        public bool IsFinished { get { return animation.IsFinished; } }

        public TextureRegion Region { get { return regions[animation.Index]; } }

        //================================================================
        //Methodes
        //================================================================
        public void Animation()
        {
            animation.Start();
            if (StartAnimation != null)
            {
                StartAnimation(this);
            }
        }

        public void Animation(int time)
        {
            animation.Start(time);
            if (StartAnimation != null)
            {
                StartAnimation(this);
            }
        }

        public void Animation(int time, int start, int end)
        {
            animation.Start(time, start, end);
            if (StartAnimation != null)
            {
                StartAnimation(this);
            }
        }

        public void Stop()
        {
            animation.Stop();
        }

        public void Stop(int index)
        {
            animation.Stop(index);
        }

        public void RegisterUpdateHandler(IUpdateHandler update)
        {
            if (update == null)
                return;
            updates.Add(update);
        }

        public void UnregisterUpdateHandler(IUpdateHandler update)
        {
            if (update == null)
                return;
            updates.Remove(update);
        }

        public void ClearUpdate()
        {
            updates.Clear();
        }

        public bool CollisionWith(IEntity entity)
        {
            if ((X < entity.X && X + Width > entity.X && Y < entity.Y && Y + Height > entity.Y)
                || (entity.X < X && entity.X + entity.Width > X && entity.Y < Y && entity.Y + entity.Height > Y))
            {
                return true;
            }

            return false;
        }

        //================================================================
        //Methodes overridde
        //================================================================
        public virtual void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (updates != null)
            {
                foreach (IUpdateHandler update in updates)
                {
                    update.Update(gameTime);
                }
            }
            animation.Update(gameTime);
            frameIndex = animation.Index;

            if (animation.IsFinished)
            {
                if (FinishAnimation != null)
                {
                    FinishAnimation(this);
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(regions[frameIndex].Texture, Position, regions[frameIndex].Bounds, Color.White,
                    Rotation, Origin, Scaling, Flip, 0);
            }
            base.Draw(spriteBatch);
        }

        public virtual void Reset()
        {
            base.Reset();

            animation.Reset();
        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
