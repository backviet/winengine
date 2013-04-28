using WinEngine.Util.Modifier;

namespace WinEngine.Entity.Modifier
{
    public class LoopEntityModifier : LoopModifier<IEntity>, IEntityModifier
    {
        public LoopEntityModifier(IEntityModifier entityModifier)
            : base(entityModifier)
        {
        }

        public LoopEntityModifier(IEntityModifier entityModifier, int loopCount)
            : base(entityModifier, loopCount)
        {
        }
    }
}
