using WinEngine.Util.Modifier;
using WinEngine.Util.Interpolation;

namespace WinEngine.Entity.Modifier
{
    public abstract class DoubleSpanEntityModifier : BaseDoubleSpanModifier<IEntity>, IEntityModifier
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================

        //================================================================
        //Constructors
        //================================================================
        public DoubleSpanEntityModifier(double duration, double fromValueA, double toValueA, double fromValueB,
            double toValueB)
            : base(duration, fromValueA, toValueA, fromValueB, toValueB)
        {
        }

        public DoubleSpanEntityModifier(double duration, double fromValueA, double toValueA, double fromValueB,
            double toValueB, IEntityModifierListener listener, IInterpolation function)
            : base(duration, fromValueA, toValueA, fromValueB, toValueB, listener, function)
        {
        }
        //================================================================
        //Getter and Setter
        //================================================================

        //================================================================
        //Methodes
        //================================================================

        //================================================================
        //Methodes overridde
        //================================================================
    }
}
