using Microsoft.Xna.Framework;

namespace WinEngine.Util
{
    public interface IUpdateHandler
    {
        void Update(GameTime gameTime);
        void Reset();
    }
}
