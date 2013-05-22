using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

using WinEngine.Entity;
using WinEngine.Texture;

namespace WinEngine.Entity.UI
{
    public class Button : Widget, IOnClickListener
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        public event Action<Button> ButtonPressed;

        private TextureRegion[] regions;

        private int index = 0;

        private bool isPressed = false;

        //================================================================
        //Constructors
        //================================================================
        public Button(Vector2 pos, TextureRegion region)
            : base(pos)
        {
            regions = new TextureRegion[1];
            regions[0] = region;
        }

        public Button(Vector2 pos, TextureRegion general, TextureRegion press)
            : base(pos)
        {
            regions = new TextureRegion[2];
            regions[0] = general;
            regions[1] = press;
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public TextureRegion Region { get { return regions[0]; } set { this.regions[0] = value; } }

        //================================================================
        //Methodes
        //================================================================
        public void SetOriginCenter()
        {
            Origin = new Vector2(regions[0].Bounds.Width / 2, regions[0].Bounds.Height / 2);
        }

        public bool Contains(Vector2 point)
        {
            return Contains(point, (int)(X - Origin.X), (int)(Y - Origin.Y),
                 regions[index].Bounds.Width, regions[index].Bounds.Height);
        }

        //================================================================
        //Methodes overridde
        //================================================================

        public bool ContinueCheck { get; set; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(regions[index].Texture, Position, regions[index].Bounds,
                    Color.Lerp(Color.White, Color.Transparent, Alpha), Rotation, Origin, Scaling, Flip, 0);
            }
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public bool OnClick(TouchLocation touch)
        {
            if (Contains(touch.Position))
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    index = regions.Length - 1;
                    isPressed = true;
                }
                else if (touch.State == TouchLocationState.Released && isPressed)
                {
                    if (ButtonPressed != null)
                    {
                        this.ButtonPressed(this);
                    }
                    index = 0;
                }
                return ContinueCheck;
            }
            else if (isPressed && touch.State == TouchLocationState.Released)
            {
                isPressed = false;
                index = 0;
            }
            return true;
        }
    }
}
