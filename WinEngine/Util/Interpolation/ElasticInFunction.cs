using System;

using WinEngine.Util.MathUtil;

namespace WinEngine.Util.Interpolation
{
    public class ElasticInFunction : IInterpolation
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private static ElasticInFunction INSTANCE;

        //================================================================
        //Constructors
        //================================================================
        ElasticInFunction()
        {
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public static ElasticInFunction Instance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ElasticInFunction();
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

            double t = percent - 1;
            return -Math.Pow(2, 10 * t) * Math.Sin(t * duration - s) * MathConstant.PI_TWICE / p;
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
