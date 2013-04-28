using WinEngine.Util.Interpolation;

namespace WinEngine.Entity.Modifier
{
    public class RotationModifier : SingleSpanEntityModifier
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
        public RotationModifier(double duration, double fromX, double toX)
            : this(duration, fromX, toX, null, LinearFuntion.Instance())
        {
        }

        public RotationModifier(double duration, double fromX, double toX,
            IEntityModifierListener listener, IInterpolation function)
            : base(duration, fromX, toX, listener, function)
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
            entity.Rotation = (float)value;
        }

        public override void SetValue(IEntity entity, double percentage, double value)
        {
            entity.Rotation = (float)value;
        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
