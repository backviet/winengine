using Microsoft.Xna.Framework;

namespace WinEngine.Util.Modifier
{
    public abstract class BaseDurationModifier<T> : BaseModifier<T>
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        protected double duration;
        protected double elapsedTime = 0;

        //================================================================
        //Constructors
        //================================================================
        public BaseDurationModifier(double duration)
        {
            this.duration = duration;
        }

        public BaseDurationModifier(double duration, IModifierListener<T> listener)
            :base(listener)
        {
            this.duration = duration;
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public override double Duration
        {
            get { return duration; }
            set { this.duration = value; }
        }

        public double ElapsedTime { get { return elapsedTime; } }

        //================================================================
        //Methodes
        //================================================================
        protected abstract void ManagedUpdate(GameTime gameTime, T item);

        protected abstract void ManagedInitilize(GameTime gameTime, T item);

        //================================================================
        //Methodes overridde
        //================================================================
        public override double Update(GameTime gameTime, T item)
        {
            if (isFinish)
            {
                return 0;
            }

            if (elapsedTime == 0)
            {
                ManagedInitilize(gameTime, item);
                ModifierStart(item);
            }

            double elapsed;

            if (elapsedTime + gameTime.ElapsedGameTime.TotalSeconds < duration)
            {
                elapsed = gameTime.ElapsedGameTime.TotalSeconds; ;
            }
            else
            {
                elapsed = duration - elapsedTime;
            }

            elapsedTime += elapsed;
            ManagedUpdate(gameTime, item);

            if (duration != -1 && elapsedTime >= duration)
            {
                
                isFinish = true;
                elapsedTime = duration;
                ModifierFinish(item);
            }

            return elapsed;
        }

        public override void Reset()
        {
            isFinish = false;
            elapsedTime = 0;
        }

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================

    }
}
