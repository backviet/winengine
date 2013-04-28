using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinEngine.Util.Interpolation
{
    public class LinearFuntion : IInterpolation
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private static LinearFuntion INSTANCE;

        //================================================================
        //Constructors
        //================================================================
        private LinearFuntion()
        {
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public static LinearFuntion Instance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new LinearFuntion();
            }

            return INSTANCE;
        }

        //================================================================
        //Methodes
        //================================================================

        //================================================================
        //Methodes overridde
        //================================================================
        public double Percent(double elapsed, double duration)
        {
            return elapsed / duration;
        }

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================

    }
}
