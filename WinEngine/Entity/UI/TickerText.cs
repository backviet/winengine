using System;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WinEngine.Entity.UI
{
    public class TickerText : Text
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        public event Action<TickerText> ActionFinish;

        private StringBuilder builder;

        private int characterPerSecond = 0;
        private int characterVisible = 0;
        private double duration;
        private double elapsedTime = 0;

        private double count = 0;
        private double timeDisplay;

        private bool isFinish = false;
        public bool isVisibleWhenFinish = false;

        //================================================================
        //Constructors
        //================================================================
        public TickerText(Vector2 pos, Color color, int characterPerSecond, int max)
            : base(pos, color)
        {
            builder = new StringBuilder();
            this.characterPerSecond = characterPerSecond;
            duration = max * characterPerSecond;
        }

        //================================================================
        //Getter and Setter
        //================================================================
        #region
        public string GetTextRender()
        {
            builder.Clear();
            string t = TextRender;
            for (int i = 0; i < characterVisible; i++)
            {
                builder.Append(t[i]);
            }
            return builder.ToString();
        }

        public int CharacterPerSecond
        {
            get { return characterPerSecond; }
            set { characterPerSecond = value; }
        }

        public double Dration
        {
            get { return duration; }
            set { duration = value; }
        }

        public double Display
        {
            get { return timeDisplay; }
            set { timeDisplay = value; }
        }

        #endregion
        //================================================================
        //Methodes
        //================================================================
        #region
        public void Start()
        {
            if (TextRender == null || TextRender.Equals(""))
            {
                return;
            }
            isFinish = false;
        }

        #endregion
        //================================================================
        //Methodes overridde
        //================================================================
        #region
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible && !TextRender.Equals(""))
            {
                string t = isFinish ? TextRender : GetTextRender();
                spriteBatch.DrawString(Font, t, Position, Color.Lerp(Color, Color.Transparent, Alpha),
                    Rotation, Origin, Scaling, Flip, 0);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!isFinish)
            {
                this.elapsedTime = Math.Min(this.duration, this.elapsedTime + gameTime.ElapsedGameTime.TotalSeconds);
                this.characterVisible = (int)(this.elapsedTime * this.characterPerSecond);
                if (characterVisible == TextRender.Length)
                {
                    isFinish = true;
                    if (ActionFinish != null)
                    {
                        ActionFinish(this);
                    }
                }
            }
            else
            {
                if (isVisibleWhenFinish)
                {
                    count += gameTime.ElapsedGameTime.TotalSeconds;

                    if (count >= timeDisplay)
                    {
                        Visible = false;
                    }
                }
            }
        }

        public override void Reset()
        {
            base.Reset();
            builder.Clear();
            elapsedTime = 0;
            characterVisible = 0;
            count = 0;
        }
        #endregion
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
