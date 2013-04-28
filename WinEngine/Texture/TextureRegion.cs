using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WinEngine.Texture
{
    public class TextureRegion
    {
        public Texture2D Texture { get; set; }
        public Rectangle Bounds { get; set; }
        public Vector2 OriginTopLeft { get; set; }
        public Vector2 OriginCenter { get; set; }
        public Vector2 OriginBottomRight { get; set; }
        public bool Rotated { get; set; }
        public TextureRegion DeepCopy()
        {
            TextureRegion result = new TextureRegion();

            result.Texture = Texture;
            result.Bounds = new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
            if (OriginTopLeft != null) {
                result.OriginTopLeft = new Vector2(OriginTopLeft.X, OriginTopLeft.Y);
            }

            if (OriginCenter != null)
            {
                result.OriginCenter = new Vector2(OriginCenter.X, OriginCenter.Y);
            }

            if (OriginBottomRight != null)
            {
                result.OriginBottomRight = new Vector2(OriginBottomRight.X, OriginBottomRight.Y);
            }
            result.Rotated = Rotated;

            return result;
        }
    }
}
