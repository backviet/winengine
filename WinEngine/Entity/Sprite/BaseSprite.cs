using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WinEngine.Util;
using WinEngine.Texture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WinEngine.Entity.Sprite
{
    public class BaseSprite : GameEntity
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private List<IUpdateHandler> updates = null;

        private Texture2D texture;

        //================================================================
        //Constructors
        //================================================================
        public BaseSprite(Vector2 postion, bool isUpdate)
            : base(postion)
        {
            if (isUpdate) updates = new List<IUpdateHandler>();
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public TextureRegion Region { get; set; }

        public Texture2D Texture { get { return texture; } set { texture = value; } }
        //================================================================
        //Methodes
        //================================================================
        public void RegisterUpdateHandler(IUpdateHandler update)
        {
            if (update == null || updates == null) return;

            updates.Add(update);
        }

        public void UnregisterUpdateHandler(IUpdateHandler update)
        {
            if (update == null || updates == null) return;

            updates.Remove(update);
        }

        public void ClearUpdate()
        {
            if (updates == null)
                return;
            updates.Clear();
        }

        //================================================================
        //Methodes overridde
        //================================================================

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
