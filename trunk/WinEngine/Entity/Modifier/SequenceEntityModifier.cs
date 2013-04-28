using WinEngine.Util.Modifier;

namespace WinEngine.Entity.Modifier
{
    public class SequenceEntityModifier: SequenceModifier<IEntity>, IEntityModifier
    {
        public SequenceEntityModifier(params IModifier<IEntity>[] modifiers)
            : base(modifiers)
        {
        }
    }
}
