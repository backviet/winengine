using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WinEngine.Util;
using WinEngine.Screen;
using WinEngine.Entity.Modifier;

namespace WinEngine.Entity.UI
{
    public class Text : GameEntity
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private string text;
        private Vector2 size;

        private Vector2 position;

        //================================================================
        //Constructors
        //================================================================
        public Text(Vector2 position, Color color, Vector2 origin)
            : base(position)
        {
            Color = color;
            TextRender = "";

            Origin = origin;
        }

        public Text(Vector2 position, Color color)
            : base(position)
        {
            Color = color;
            TextRender = "";
        }
        //================================================================
        //Getter and Setter
        //================================================================
        public string TextRender
        {
            get { return text; }
            set
            {
                text = value;
            }
        }

        public SpriteFont Font { get; set; }

        //================================================================
        //Methodes
        //================================================================

        //================================================================
        //Methodes overridde
        //================================================================

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible && !TextRender.Equals(""))
            {
                spriteBatch.DrawString(Font, TextRender, Position, Color.Lerp(Color, Color.Transparent, Alpha),
                    Rotation, Origin, Scaling, Flip, 0);
            }
            base.Draw(spriteBatch);
        }
    }
}
