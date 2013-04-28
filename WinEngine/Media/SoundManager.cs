using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace WinEngine.Media
{
    public class SoundManager
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private static Dictionary<string, SoundPool> soundList = new Dictionary<string, SoundPool>();

        //================================================================
        //Constructors
        //================================================================

        //================================================================
        //Getter and Setter
        //================================================================
        public static string AssetPath { private get; set; }

        //================================================================
        //Methodes
        //================================================================
        #region
        public static ContentManager ContentManager { get; set; }

        public static void LoadSound(string name)
        {
            if (ContentManager != null)
            {
                if (soundList.ContainsKey(name))
                {
                    return;
                }

                SoundEffect sound = ContentManager.Load<SoundEffect>(AssetPath + name);
                SoundPool pool = new SoundPool(ref sound);

                soundList.Add(name, pool);
            }
        }

        public static SoundEffect GetSound(string name)
        {
            if (soundList.ContainsKey(name))
            {
                return soundList[name].Sound();
            }
            return null;
        }

        public static SoundEffectInstance GetSoundInstance(string name)
        {
            if (soundList.ContainsKey(name))
            {
                return soundList[name].Obtains();
            }
            return null;
        }

        public static void Dispose()
        {
            for (int i = soundList.Count - 1; i >= 0; i--)
            {
                soundList.ElementAt(i).Value.Dispose();
            }
            soundList.Clear();
            soundList = null;
        }
        #endregion
        //================================================================
        //Methodes overridde
        //================================================================
        #region
        #endregion
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
