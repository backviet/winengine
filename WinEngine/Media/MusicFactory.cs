using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace WinEngine.Media
{
    public class MusicFactory
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        public static Dictionary<string, Song> musics = new Dictionary<string, Song>();

        //================================================================
        //Constructors
        //================================================================

        //================================================================
        //Getter and Setter
        //================================================================
        public static string AssetPath { private get; set; }
        public static ContentManager ContentManager { get; set; }

        public static Song Song(string name)
        {
            if (musics.ContainsKey(name))
            {
                return musics[name];
            }
            return null;
        }

        //================================================================
        //Methodes
        //================================================================
        public static void LoadMusic(string name)
        {
            if (ContentManager != null)
            {
                if (musics.ContainsKey(name))
                {
                    return;
                }

                Song song = ContentManager.Load<Song>(AssetPath + name);
                musics.Add(name, song);
            }
        }

        //================================================================
        //Methodes overridde
        //================================================================

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
