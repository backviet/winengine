using Microsoft.Xna.Framework.Input.Touch;

using WinEngine.Entity.Modifier;

namespace WinEngine.Entity.UI
{
    public interface IOnClickListener
    {
        bool OnClick(TouchLocation touch);
        bool ContinueCheck { get; set; }
    }

    public interface IWidget
    {
        void BuildUI();
        void AddBuildUI(IEntityModifier mod);
        void RemoveBuildUI(IEntityModifier mod);
        bool NeedBuildUI { get; set; }
    }
}
