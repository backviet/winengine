using WinEngine.Util.Interpolation;

namespace WinEngine.Entity.Modifier
{
    public class MoveXModifier : SingleSpanEntityModifier
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
        public MoveXModifier(double duration, double fromX, double toX)
            : this(duration, fromX, toX, null, LinearFuntion.Instance())
        {
        }

        public MoveXModifier(double duration, double fromX, double toX,
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
            entity.X = (float)value;
        }

        public override void SetValue(IEntity entity, double percentage, double value)
        {
            entity.X = (float)value;
        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
