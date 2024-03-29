using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WinEngine.Texture;

namespace WinEngine.Entity.UI
{
    public class Image : Widget
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private TextureRegion region;

        //================================================================
        //Constructors
        //================================================================
        public Image(Vector2 position, TextureRegion region)
            : base(position)
        {
            this.region = region;
            Width = region.Bounds.Width;
            Height = region.Bounds.Height;
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public TextureRegion Region { get { return region; } set { this.region = value; } }

        //================================================================
        //Methodes
        //================================================================
        #region
        #endregion
        //================================================================
        //Methodes overridde
        //================================================================
        #region
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(region.Texture, Position, region.Bounds,
                    Color.Lerp(Color.White, Color.Transparent, Alpha), Rotation, Origin, Scaling, Flip, 0);
            }
            base.Draw(spriteBatch);
        }
        #endregion
    }
}
