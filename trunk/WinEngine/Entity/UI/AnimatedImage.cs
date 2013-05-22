using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WinEngine.Entity.Sprite;
using WinEngine.Texture;

namespace WinEngine.Entity.UI
{
    public class AnimatedImage : Widget
    {
         //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private TextureRegion[] regions;
        protected Animator animation;

        protected int index;

        public event Action<AnimatedImage> StartAnimation;
        public event Action<AnimatedImage> FinishAnimation;

        private int countLoop;

        //================================================================
        //Constructors
        //================================================================
        public AnimatedImage(Vector2 position, int time, TextureRegion[] regions)
            : base(position)
        {
            this.regions = regions;
            animation = new Animator(time, regions.Length);
        }

        //================================================================
        //Getter and Setter
        //================================================================

        //================================================================
        //Methodes
        //================================================================
        #region
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

        #endregion
        //================================================================
        //Methodes overridde
        //================================================================
        #region
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(regions[index].Texture, Position, regions[index].Bounds, Color.White,
                    Rotation, Origin, Scaling, Flip, 0);
            }
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            animation.Update(gameTime);
            index = animation.Index;

            if (animation.IsFinished)
            {
                if (FinishAnimation != null)
                {
                    FinishAnimation(this);
                }
            }
        }
        #endregion
    }
}
