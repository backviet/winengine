using Microsoft.Xna.Framework;

using WinEngine.Util.Interpolation;

namespace WinEngine.Entity.Modifier
{
    public class AlphaModifier : SingleSpanEntityModifier
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
        public AlphaModifier(double duration, double fromX, double toX)
            : this(duration, fromX, toX, null, LinearFuntion.Instance())
        {
        }

        public AlphaModifier(double duration, double fromX, double toX,
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
            entity.Alpha = (float)value;

            if (entity.Alpha <= 0 || entity.Alpha >= 1)
            {
                entity.Alpha = MathHelper.Clamp(entity.Alpha, 0, 1);
            }
        }

        public override void SetValue(IEntity entity, double percentage, double value)
        {
            entity.Alpha = (float)value;

            if (entity.Alpha <= 0 || entity.Alpha >= 1)
            {
                entity.Alpha = MathHelper.Clamp(entity.Alpha, 0, 1);
            }
        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
