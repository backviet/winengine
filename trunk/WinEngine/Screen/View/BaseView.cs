using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using WinEngine.Screen;
using WinEngine.Util.Interpolation;
using WinEngine.Util.Modifier;
using WinEngine.Entity;
using WinEngine.Entity.UI;
using WinEngine.Texture;

namespace WinEngine.Screen.View
{
    public class BaseView
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        protected List<IEntity> childrens;
        private List<IOnClickListener> clickListener;
        private ViewBackground background;

        public Game game;
        public SpriteBatch spriteBatch;
        protected Camera2d camera;

        private Vector2 position;

        public int countchildren = 0;
        //================================================================
        //Constructors
        //================================================================
        public BaseView(Game game, Vector2 position)
        {
            this.game = game;
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            camera = new Camera2d(game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            camera.Position = new Vector2(camera.width / 2, camera.height / 2);

            childrens = new List<IEntity>();
            clickListener = new List<IOnClickListener>();

            Position = position;
            background = new ViewBackground(position);
            background.Background(this, camera.width, camera.height);
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public void SetBackground(TextureRegion region)
        {
            background.SetTexture(region);
        }

        public void SetBackground(Texture2D texture)
        {
            background.SetTexture(texture, camera.width, camera.height);
        }

        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                this.position = value;
                if (background != null)
                {
                    background.Position = position;
                }
            }
        }

        //================================================================
        //Methodes
        //================================================================
        public bool Visible { get; set; }
        public SpriteFont Font { get; set; }

        #region Widget && OnClickListener
        public void AddChild(IEntity entity, bool isText)
        {
            if (entity == null || childrens.Contains(entity))
            {
                return;
            }
            if (isText)
            {
                ((Text)entity).Font = Font;
            }
            childrens.Add(entity);

            countchildren++;
        }

        public void RegisterClick(IOnClickListener listener)
        {
            if (listener == null || clickListener.Contains(listener))
            {
                return;
            }
            clickListener.Add(listener);
        }

        public void RemoveChild(IEntity entity)
        {
            countchildren--;
            if (entity == null)
            {
                return;
            }

            if (childrens.Contains(entity))
            {
                childrens.Remove(entity);
                entity.HasParent = false;
            }
        }

        public void UnRegisterClick(IOnClickListener click)
        {
            if (click == null)
            {
                return;
            }
            if (clickListener.Contains(click))
            {
                clickListener.Remove(click);
            }
        }

        public void ClearChildren()
        {
            foreach (IEntity entity in childrens)
            {
                entity.HasParent = false;
            }
            childrens.Clear();

            countchildren = 0;
        }

        public void ClearClickListener()
        {
            clickListener.Clear();
        }
        #endregion

        public virtual void Update(GameTime gameTime)
        {
            foreach (IEntity entity in childrens)
            {
                if (entity.Visible)
                {
                    entity.Update(gameTime);
                }
            }
        }

        public void Draw()
        {
            if (Visible)
            {
                spriteBatch.Begin();
                if (background != null)
                {
                    background.Draw(spriteBatch);
                }

                foreach (IEntity entity in childrens)
                {
                    if (entity.Visible)
                    {
                        entity.Draw(spriteBatch);
                    }
                }
                spriteBatch.End();
            }
        }

        public bool OnClick(TouchLocation touch)
        {
            if (Visible)
            {
                foreach (IOnClickListener click in clickListener)
                {
                    if (click.OnClick(touch))
                    {
                        continue;
                    }
                    return false;
                }
            }

            return true;
        }
        //================================================================
        //Methodes overridde
        //================================================================

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
        internal class ViewBackground
        {
            public Texture2D texture;
            public TextureRegion region;

            public ViewBackground(TextureRegion region, Vector2 position)
            {
                this.region = region;
                Position = position;
            }

            public ViewBackground(Vector2 position)
                : this(null, position)
            {
            }

            public Vector2 Position { get; set; }

            public void SetTexture(TextureRegion region)
            {
                this.region = region;
            }

            public void SetTexture(Texture2D texture, int width, int height)
            {
                this.region = new TextureRegion();
                region.Texture = texture;
                region.Bounds = new Rectangle(0, 0, width, height);
            }

            public void Background(BaseView view, int width, int height)
            {
                texture = new Texture2D(view.game.GraphicsDevice, width, height);

                Color[] colors = new Color[width * height];

                for (int i = colors.Length - 1; i != -1; i--)
                {
                    colors[i] = new Color(0.0f, 0.0f, 0.0f, 0.4f);
                }
                texture.SetData(colors);
            }

            public void Draw(SpriteBatch spriteBatch)
            {

                spriteBatch.Draw(texture, Position, Color.White);
                if (region != null)
                {
                    spriteBatch.Draw(region.Texture, Position, region.Bounds, Color.White);
                }
            }
        }
    }
}
