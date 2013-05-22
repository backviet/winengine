using WinEngine.Util.Interpolation;

namespace WinEngine.Entity.Modifier
{
    public class EquationMoveModifier : SingleSpanEntityModifier
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private IEquation equation;

        //================================================================
        //Constructors
        //================================================================
        public EquationMoveModifier(double duration, double fromX, double toX)
            : this(duration, fromX, toX, null, LinearFuntion.Instance())
        {
        }

        public EquationMoveModifier(double duration, double fromX, double toX,
            IEntityModifierListener listener, IInterpolation function)
            : base(duration, fromX, toX, listener, function)
        {
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public void Equation(IEquation equation)
        {
            this.equation = equation;
        }

        //================================================================
        //Methodes
        //================================================================

        //================================================================
        //Methodes overridde
        //================================================================
        public override void SetInitilizeValue(IEntity entity, double value)
        {
            entity.X = (float)value;
            if (equation != null)
            {
                equation.CalculateY(entity);
            }
        }

        public override void SetValue(IEntity entity, double percentage, double value)
        {
            entity.X = (float)value;
            if (equation != null)
            {
                equation.CalculateY(entity);
            }
        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }

    public interface IEquation
    {
        void CalculateY(IEntity entity);
    }
}
