using System;

using WinEngine.Util.MathUtil;

namespace WinEngine.Util.Interpolation
{
    public class ElasticOutFunction : IInterpolation
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private static ElasticOutFunction INSTANCE;

        //================================================================
        //Constructors
        //================================================================
        ElasticOutFunction()
        {
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public static ElasticOutFunction Instance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ElasticOutFunction();
            }

            return INSTANCE;
        }

        //================================================================
        //Methodes
        //================================================================
        private double Value(double elapsed, double duration, double percent)
        {
            if (elapsed == 0)
                return 0;
            if (elapsed == duration)
                return 1;

            double p = duration * 0.3;
            double s = p * 0.25;

            return 1 + Math.Pow(2, -10 * percent) * Math.Sin(percent * duration - s) * MathConstant.PI_TWICE / p;
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
