using Microsoft.Xna.Framework;

using WinEngine.Util.Interpolation;

namespace WinEngine.Entity.Modifier
{
    public class MoveModifier : DoubleSpanEntityModifier
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
        public MoveModifier(double duration, double fromX, double toX, double fromY, double toY)
            : base(duration, fromX, toX, fromY, toY)
        {
        }

        public MoveModifier(double duration, double fromX, double toX, double fromY, double toY,
            IEntityModifierListener listener, IInterpolation function)
            : base(duration, fromX, toX, fromY, toY, listener, function)
        {
        }

        public MoveModifier(double duration, Vector2 from, Vector2 to)
            : this(duration, from.X, to.X, from.Y, to.Y)
        {
        }

        public MoveModifier(double duration, Vector2 from, Vector2 to, IEntityModifierListener listener,
            IInterpolation function)
            : this(duration, from.X, to.X, from.Y, to.Y, listener, function)
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
        protected override void SetInitilizeValue(IEntity entity, double valueA, double valueB)
        {
            entity.Position = new Vector2((float)valueA, (float)valueB);
        }

        protected override void SetValue(IEntity entity, double percentage, double valueA, double valueB)
        {
            entity.Position = new Vector2((float)valueA, (float)valueB);
        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
