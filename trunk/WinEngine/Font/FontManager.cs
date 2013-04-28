using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework.Graphics;

namespace WinEngine.Font
{
    public static class FontManager
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private static Dictionary<string, SpriteFont> fonts = new Dictionary<string,SpriteFont>();

        //================================================================
        //Constructors
        //================================================================

        //================================================================
        //Getter and Setter
        //================================================================
        public static SpriteFont Font(string name)
        {
            if (fonts.ContainsKey(name))
            {
                return fonts[name];
            }
            return null;
        }

        //================================================================
        //Methodes
        //================================================================
        public static void AddFont(string name, SpriteFont font)
        {
            if (fonts.ContainsKey(name))
            {
                return;
            }
            fonts.Add(name, font);
        }

        public static void Dispose()
        {
            for (int i = fonts.Count - 1; i >= 0; i--)
            {
                string name = fonts.ElementAt(i).Key;
                fonts[name] = null;
            }
            fonts.Clear();
        }

        //================================================================
        //Methodes overridde
        //================================================================

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
