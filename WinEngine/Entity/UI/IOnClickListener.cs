using Microsoft.Xna.Framework.Input.Touch;

namespace WinEngine.Entity.UI
{
    public interface IOnClickListener
    {
        bool OnClick(TouchLocation touch);
        bool ContinueCheck { get; set; }
    }
}
