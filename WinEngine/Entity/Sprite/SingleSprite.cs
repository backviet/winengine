using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WinEngine.Texture;
using WinEngine.Util;
using WinEngine.Entity.Modifier;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WinEngine.Entity.Sprite
{
    public class SingleSprite : GameEntity
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        protected TextureRegion region;

        //================================================================
        //Constructors
        //================================================================
        public SingleSprite(Vector2 postion, TextureRegion region)
            : base(postion)
        {
            this.region = region;
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
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(region.Texture, Position, region.Bounds,
                Color.Lerp(Color.White, Color.Transparent, Alpha), Rotation, Origin, Scaling, Flip, 0);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
