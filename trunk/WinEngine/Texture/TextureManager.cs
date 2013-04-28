using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WinEngine.Texture
{
    public class TextureManager
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private static Dictionary<string, TextureAtlas> textureAtlas = new Dictionary<string, TextureAtlas>();
        private static Game gameEngine;

        private static string assetPath;
        private static string atlasPath;
        //================================================================
        //Constructors
        //================================================================
        
        //================================================================
        //Getter and Setter
        //================================================================
        public static void SetGame(Game game)
        {
            gameEngine = game;
        }

        public static string Path
        {
            get { return assetPath; }
            set
            { 
                assetPath = value;
                atlasPath = "Content\\" + assetPath;
            }
        }
        //================================================================
        //Methodes
        //================================================================
        public static TextureAtlas Atlas(string name)
        {
            if (textureAtlas.ContainsKey(name))
            {
                return textureAtlas[name];
            }
            return null;
        }
        
        public static int Count { get { return textureAtlas.Count; } }

        public static void Dispose()
        {
            for (int i = textureAtlas.Count - 1; i >= 0; i--)
            {
                textureAtlas.ElementAt(i).Value.Texture.Dispose();
            }
            textureAtlas.Clear();
        }

        public static void LoadContentAtlas(string name)
        {
            TextureAtlas atlas = new TextureAtlas();
            atlas.LoadContent(atlasPath + name);

            atlas.Texture = gameEngine.Content.Load<Texture2D>(assetPath + atlas.Image);
            textureAtlas.Add(atlas.Image, atlas);
        }

        //================================================================
        //Methodes overridde
        //================================================================

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
