using WinEngine.Util.Modifier;

namespace WinEngine.Entity.Modifier
{
    public class EntityModifierList : ModifierList<IEntity>
    {
        public EntityModifierList(IEntity entity)
            : base(entity)
        {
        }

        public EntityModifierList(IEntity entity, int capacity)
            : base(entity, capacity)
        {
        }
    }
}
