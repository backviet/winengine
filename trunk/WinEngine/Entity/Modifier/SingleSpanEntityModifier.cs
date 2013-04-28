using WinEngine.Util.Modifier;
using WinEngine.Util.Interpolation;

namespace WinEngine.Entity.Modifier
{
    public abstract class SingleSpanEntityModifier : BaseSingleSpanModifier<IEntity>, IEntityModifier
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
        public SingleSpanEntityModifier(double duration, double fromValueA, double toValueA)
            : base(duration, fromValueA, toValueA)
        {
        }

        public SingleSpanEntityModifier(double duration, double fromValueA, double toValueA,
            IEntityModifierListener listener, IInterpolation function)
            : base(duration, fromValueA, toValueA, listener, function)
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

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
