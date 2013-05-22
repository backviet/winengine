using WinEngine.Util.Interpolation;


namespace WinEngine.Entity.Modifier
{
    public class ScaleModifier : SingleSpanEntityModifier
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
        public ScaleModifier(double duration, double fromX, double toX)
            : this(duration, fromX, toX, null, LinearFuntion.Instance())
        {
        }

        public ScaleModifier(double duration, double fromX, double toX,
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
            entity.Scaling = (float)value;
        }

        public override void SetValue(IEntity entity, double percentage, double value)
        {
            entity.Scaling = (float)value;
        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
