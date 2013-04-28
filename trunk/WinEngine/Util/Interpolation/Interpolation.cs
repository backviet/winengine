using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinEngine.Util.Interpolation
{
    public interface IInterpolation
    {
        double Percent(double elapsed, double duration);
    }
}
