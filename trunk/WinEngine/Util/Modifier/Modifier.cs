using Microsoft.Xna.Framework;

namespace WinEngine.Util.Modifier
{
    public interface IModifier<T>
    {
        bool Finish { get; }
        double Duration { get; set; }
        bool AutoUnregisterListener { get; set; }
        void AddListener(IModifierListener<T> listener);
        void RemoveListener(IModifierListener<T> listener);
        double Update(GameTime gameTime, T item);
        void Reset();
    }

    public interface IModifierListener<T>
    {
        void TaskOnStart(IModifier<T> modifier, T item);
        void TaskOnFinish(IModifier<T> modifier, T item);
    }
}
