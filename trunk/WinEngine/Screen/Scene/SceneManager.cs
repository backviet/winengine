using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace WinEngine.Screen.Scene
{
   public static class SceneManager
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
       private static Dictionary<string, GameScene> scenes = new Dictionary<string, GameScene>();

       private static GameScene current = null;
       private static GameScene privious = null;

        private static bool isStarted = false;
        //================================================================
        //Constructors
        //================================================================

        //================================================================
        //Getter and Setter
        //================================================================
        public static string GetCurrentName()
        {
            return current.Name;
        }

        public static GameScene GetCurrentScene()
        {
            return current;
        }


        public static GameScene GetScene(string name)
        {
            if (Contains(name))
                return scenes[name];
            return null;
        }

        public static string Privious()
        {
            return privious.Name;
        }
        //================================================================
        //Methodes
        //================================================================
        public static void Create()
        {
            isStarted = true;
            if (current != null)
            {
                current.Create();
            }
        }

        public static int Count { get { return scenes.Count; } }

        public static bool Contains(string name)
        {
            if (scenes.ContainsKey(name))
            {
                return true;
            }
            return false;
        }

        public static void AddScene(GameScene scene)
        {
            if (scene == null || scenes.ContainsKey(scene.Name))
            {
                return;
            }
            scenes.Add(scene.Name, scene);
        }

        public static void GoToScene(string name)
        {
            if (Contains(name))
            {
                privious = current;
                if (current != null)
                {
                    if (!current.IsShutDown)
                        current.Hid();
                }
                current = scenes[name];
                if (!current.IsCreated)
                {
                    current.Create();
                }
                else
                {
                    if (current.Hidden)
                    {
                        current.Show();
                    }
                    else if (current.Paused)
                    {
                        current.Resume();
                    }
                    else if (current.IsShutDown)
                    {
                        current.Reset();
                    }
                    else
                    {
                        current.Show();
                    }
                }
            }
        }

        public static void back(string name)
        {
            if (privious != null)
            {
                GoToScene(privious.Name);
            }
        }

        public static void Update(GameTime gameTime)
        {
            
            current.Update(gameTime);
        }
        public static void Draw()
        {
            current.Draw();
        }

        //================================================================
        //Methodes overridde
        //================================================================

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
