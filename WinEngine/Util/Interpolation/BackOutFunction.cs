using System;

using WinEngine.Util.MathUtil;

namespace WinEngine.Util.Interpolation
{
    public class BackOutFunction : IInterpolation
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private static BackOutFunction INSTANCE;

        //================================================================
        //Constructors
        //================================================================
        BackOutFunction()
        {
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public static BackOutFunction Instance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new BackOutFunction();
            }

            return INSTANCE;
        }

        //================================================================
        //Methodes
        //================================================================
        private double Value(double elapsed, double duration, double percent)
        {
            double t = percent - 1;
            return 1 + 2 * t * t * ((1.70158f + 1) * t + 1.70158f);
        }

        //================================================================
        //Methodes overridde
        //================================================================
        public double Percent(double elapsed, double duration)
        {
            return Value(elapsed, duration, elapsed / duration);
        }
    }
}
