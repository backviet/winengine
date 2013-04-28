using Microsoft.Xna.Framework;

using WinEngine.Util.Interpolation;

namespace WinEngine.Util.Modifier
{
    public abstract class BaseSingleSpanModifier<T> : BaseDurationModifier<T>
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private double valueSpan;
        private double fromValue;

        private IInterpolation function;

        //================================================================
        //Constructors
        //================================================================
        public BaseSingleSpanModifier(double duration, double fromValue, double toValue)
            : this(duration, fromValue, toValue, null)
        {
        }

        public BaseSingleSpanModifier(double duration, double fromValue, double toValue, IInterpolation function)
            : base(duration)
        {
            this.Duration = duration;
            this.valueSpan = toValue - fromValue;
            this.fromValue = fromValue;

            this.function = function;
            if (function == null)
            {
                this.function = LinearFuntion.Instance();
            }
        }

        public BaseSingleSpanModifier(double duration, double fromValue, double toValue,
            IModifierListener<T> listener, IInterpolation function)
            : base(duration, listener)
        {
            this.Duration = duration;
            this.valueSpan = toValue - fromValue;
            this.fromValue = fromValue;

            this.function = function;
            if (function == null)
            {
                this.function = LinearFuntion.Instance();
            }
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public double FromValue
        {
            get { return fromValue; }
        }

        public double ToValue
        {
            get { return fromValue + valueSpan; }
        }
        //================================================================
        //Methodes
        //================================================================
        public abstract void SetInitilizeValue(T item, double value);

        public abstract void SetValue(T item, double percentage, double value);

        public  void Reset(double duration, double fromValue, double toValue)
        {
            base.Reset();

            this.duration = duration;
            this.fromValue = fromValue;
            this.valueSpan = toValue - fromValue;
        }
        //================================================================
        //Methodes overridde
        //================================================================
        protected override void ManagedUpdate(GameTime gameTime, T item)
        {
            double percentage = this.function.Percent(this.elapsedTime, this.duration);
            double value = this.fromValue + percentage * valueSpan;

            SetValue(item, percentage, value);
        }

        protected override void ManagedInitilize(GameTime gameTime, T item)
        {
            SetInitilizeValue(item, fromValue);
        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
