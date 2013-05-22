using WinEngine.Util.Modifier;

namespace WinEngine.Entity.Modifier
{
    public abstract class EntityModifier : BaseModifier<IEntity>, IEntityModifier
    {
        public EntityModifier()
            : base()
        {
        }

        public EntityModifier(IEntityModifierListener listener)
            : base(listener)
        {
        }
    }

    public interface IEntityModifier : IModifier<IEntity>
    {
        
    }

    public interface IEntityModifierListener : IModifierListener<IEntity>
    {
    }

    public interface IEntiyMatcher : IMatcher<IModifier<IEntity>>
    {
    }

    public interface IMatcher<T> 
    {
        void matches(T obj);
    }
}
