using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using WinEngine.Util;
using WinEngine.Entity;
using WinEngine.Entity.UI;

namespace WinEngine.Screen.Scene
{
    public class HUD : GameEntity
    {
        //================================================================
        //Constants
        //================================================================
        private readonly int HUD_WIDTH;
        private readonly int HUD_HEIGHT;

        //================================================================
        //Fields
        //================================================================
        private SpriteBatch spriteBatch;

        private List<IOnClickListener> childrenClicked;
        //================================================================
        //Constructors
        //================================================================
        public HUD(GraphicsDevice graphic, int width, int height)
            : base(0, 0)
        {
            HUD_HEIGHT = height;
            HUD_WIDTH = width;

            childrenClicked = new List<IOnClickListener>();
            spriteBatch = new SpriteBatch(graphic);
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public SpriteFont Font { get; set; }

        //================================================================
        //Methodes
        //================================================================
        public void AddTextChild(IEntity element)
        {
            ((Text)element).Font = Font;
            AttachChild(element);
        }

        public void RegisterClickListener(IOnClickListener listener)
        {
            childrenClicked.Add(listener);
        }

        public void Draw()
        {
            spriteBatch.Begin();
            base.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public bool OnTouch(TouchLocation touch)
        {
            foreach (IOnClickListener click in childrenClicked)
            {
                if (click.OnClick(touch))
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        //================================================================
        //Methodes overridde
        //================================================================

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
