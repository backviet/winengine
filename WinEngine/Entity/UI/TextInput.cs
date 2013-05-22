using System;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.GamerServices;

namespace WinEngine.Entity.UI
{
    public class TextInput : Widget, IOnClickListener
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        #region 

        public event Action<TextInput> ActionResult;

        private Texture2D texture;
        private Rectangle destination;

        private Color rectangleColor;

        private bool isClicked = false;
        private bool isPressed = false;
        private bool isCompleted = false;

        #endregion
        //================================================================
        //Constructors
        //================================================================
        public TextInput(GraphicsDevice graphic, SpriteFont font, Vector2 position, string hintText, int width, int height, 
            Color rectangleColor)
            : base (position)
        {
            Position = new Vector2(position.X + width * 0.1f,
                                  position.Y + height * 0.5f - font.MeasureString(hintText).Y * 0.5f);
            HintText = hintText;
            this.rectangleColor = rectangleColor;
            Font = font;

            destination = new Rectangle((int)position.X, (int)position.Y, width, height);
            texture = new Texture2D(graphic, width, height);

            Color[] colors = new Color[width * height];
            for (int i = 0; i < colors.Length; i++)
            {
                if (i < 2 * width || colors.Length - 2 * width < i ||
                    i % width < 2 || width - 3 < i % width)
                    colors[i] = new Color(1.0f, 1.0f, 0.0f, 1.0f);
                else
                    colors[i] = new Color(0.0f, 0.0f, 0.0f, 0.4f);
            }
            texture.SetData<Color>(colors);

        }

        //================================================================
        //Getter and Setter
        //================================================================

        public string HintText { get; set; }

        public string Title { get; set; }

        public string InputText { get; set; }

        public SpriteFont Font { get; set; }

        public bool IsComplete()
        {
            return isCompleted;
        }

        //================================================================
        //Methodes
        //================================================================

        //================================================================
        //Methodes overridde
        //================================================================
        #region
        public bool ContinueCheck { get; set; }
        
        public new void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(texture, destination, Color.White);
                spriteBatch.DrawString(Font, HintText, Position, Color.Lerp(Color.White, Color.Transparent, Alpha),
                        Rotation, Origin, Scaling, Flip, 0);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (isClicked)
            {
                isClicked = false;
                if (ActionResult != null)
                {
                    this.ActionResult(this);
                }

            }
        }

        public bool OnClick(TouchLocation touch)
        {
            if (Contains(touch.Position, destination.X, destination.Y, 
                 destination.Width, destination.Height))
             {
                if (touch.State == TouchLocationState.Pressed)
                {
                    isPressed = true;
                }
                else if (touch.State == TouchLocationState.Released && isPressed)
                {
                    isClicked = true;
                    if (!Guide.IsVisible)
                    {
                        if (InputText == HintText)
                        {
                            Guide.BeginShowKeyboardInput(PlayerIndex.One, Title,
                                                         HintText, "",
                                                         delegate(IAsyncResult result)
                                                         {
                                                             String tempText = Guide.EndShowKeyboardInput(result);
                                                             if (tempText != null)
                                                             {
                                                                 if (!tempText.Equals(""))
                                                                 {
                                                                     InputText = tempText;
                                                                     if (ActionResult != null)
                                                                     {
                                                                         ActionResult(this);
                                                                     }
                                                                     isCompleted = true;
                                                                 }
                                                             }
                                                         }, null);
                        }
                        else
                        {
                            Guide.BeginShowKeyboardInput(PlayerIndex.One, Title,
                                                         HintText, InputText,
                                                         delegate(IAsyncResult result)
                                                         {
                                                             String tempText = Guide.EndShowKeyboardInput(result);
                                                             if (tempText != null)
                                                             {
                                                                 if (!tempText.Equals(""))
                                                                 {
                                                                     InputText = tempText;
                                                                     if (ActionResult != null)
                                                                     {
                                                                         ActionResult(this);
                                                                     }
                                                                     isCompleted = true;
                                                                 }
                                                             }
                                                         }, null);
                        }
                    }
                    
                }
                return ContinueCheck;
             }
             return true;
        }
        #endregion
    }
}
