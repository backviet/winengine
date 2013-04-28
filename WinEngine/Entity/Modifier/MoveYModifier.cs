using WinEngine.Util.Interpolation;

namespace WinEngine.Entity.Modifier
{
    public class MoveYModifier : SingleSpanEntityModifier
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
        public MoveYModifier(double duration, double fromY, double toY)
            : this(duration, fromY, toY, null, LinearFuntion.Instance())
        {
        }

        public MoveYModifier(double duration, double fromY, double toY,
            IEntityModifierListener listener, IInterpolation function)
            : base(duration, fromY, toY, listener, function)
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
        public override void SetInitilizeValue(IEntity entity, double value)
        {
            entity.Y = (float)value;
        }

        public override void SetValue(IEntity entity, double percentage, double value)
        {
            entity.Y = (float)value;
        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
