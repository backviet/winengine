using System;

using WinEngine.Util.Interpolation;

namespace WinEngine.Util.Modifier
{
    public abstract class BaseDoubleSpanModifier<T> : BaseSingleSpanModifier<T>
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private double fromValueB;
        private double valueSpanB;

        //================================================================
        //Constructors
        //================================================================
        public BaseDoubleSpanModifier(double duration, double fromValueA, double toValueA, double fromValueB,
            double toValueB)
            : this(duration, fromValueA, toValueA, fromValueB, toValueB, null)
        {
        }

        public BaseDoubleSpanModifier(double duration, double fromValueA, double toValueA, double fromValueB,
            double toValueB, IModifierListener<T> listener)
            : base(duration, fromValueA, toValueA, listener, null)
        {
            this.fromValueB = fromValueB;
            this.valueSpanB = toValueB - fromValueB;
        }

        public BaseDoubleSpanModifier(double duration, double fromValueA, double toValueA, double fromValueB,
            double toValueB, IModifierListener<T> listener, IInterpolation function)
            : base(duration, fromValueA, toValueA, listener, function)
        {
            this.fromValueB = fromValueB;
            this.valueSpanB = toValueB - fromValueB;
        }
        //================================================================
        //Getter and Setter
        //================================================================

        //================================================================
        //Methodes
        //================================================================
        protected abstract void SetInitilizeValue(T item, double valueA, double valueB);

        protected abstract void SetValue(T item, double percentage, double valueA, double valueB);

        public void Reset(double duration, double fromValueA, double toValueA, double fromValueB,
            ref double toValueB)
        {
            base.Reset(duration, fromValueA, toValueA);

            this.fromValueB = fromValueB;
            this.valueSpanB = toValueB - fromValueB;
        }
        //================================================================
        //Methodes overridde
        //================================================================
        public override void SetInitilizeValue(T item, double value)
        {
            SetInitilizeValue(item, value, this.fromValueB);
        }

        public override void SetValue(T item, double percentage, double value)
        {
            double valueB = this.fromValueB + percentage * this.valueSpanB;
            SetValue(item, percentage, value, valueB);
        }

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
