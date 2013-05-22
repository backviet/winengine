using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using WinEngine.Entity.Sprite;
using WinEngine.Entity;
using WinEngine.Entity.Modifier;

namespace WinEngine.Entity.UI
{
    public class Widget : GameEntity, IWidget
    {
        private List<IEntityModifier> buildUIs;

        public Widget(Vector2 pos)
            : base(pos)
        {
            buildUIs = new List<IEntityModifier>(4);
        }

        public void BuildUI()
        {
            if (NeedBuildUI)
            {
                foreach (IEntityModifier mod in buildUIs)
                {
                    mod.Reset();
                    this.RegisterModifier(mod);
                }
            }
        }

        public void AddBuildUI(IEntityModifier mod)
        {
            buildUIs.Add(mod);
        }

        public void RemoveBuildUI(IEntityModifier mod)
        {
            buildUIs.Remove(mod);
        }

        public bool NeedBuildUI { get; set; }

    }
}
