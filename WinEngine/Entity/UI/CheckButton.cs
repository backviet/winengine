using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using WinEngine.Texture;

namespace WinEngine.Entity.UI
{
    public class CheckButton: Widget, IOnClickListener
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        public event Action<CheckButton> CheckedAction;
        
        private TextureRegion[] regions;

        private int index = 0;

        private bool isPressed = false;
        private bool value = false;
        
        //================================================================
        //Constructors
        //================================================================
        public CheckButton(Vector2 pos, TextureRegion general, TextureRegion press)
            : base(pos)
        {
            regions = new TextureRegion[2];
            regions[0] = general;
            regions[1] = press;
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public bool Value
        {
            get { return value; }
            set
            {
                this.value = value;
                if (this.value)
                {
                    index = 1;
                }
                else
                {
                    index = 0;
                }
            }
        }

        public bool ContinueCheck { get; set; }
        //================================================================
        //Methodes
        //================================================================

        //================================================================
        //Methodes overridde
        //================================================================

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(regions[index].Texture, Position, regions[index].Bounds,
                    Color.Lerp(Color.White, Color.Transparent, Alpha), Rotation, Origin, Scaling, Flip, 0);
            }
            base.Draw(spriteBatch);
        }

        public bool OnClick(TouchLocation touch)
        {
             if (Contains(touch.Position, (int)Position.X, (int)Position.Y, 
                 regions[index].Bounds.Width, regions[index].Bounds.Height))
             {
                if (touch.State == TouchLocationState.Pressed)
                {
                    index = (~index) & 1;
                    isPressed = true;
                }
                else if (touch.State == TouchLocationState.Released && isPressed)
                {
                    isPressed = false;
                    if (CheckedAction != null)
                    {
                        this.CheckedAction(this);
                    }
                }
                return ContinueCheck;
             }
             else if (isPressed && touch.State == TouchLocationState.Released)
             {
                 index = (~index) & 1;
                 index = 0;
             }
             return true;
        }
    }
}
