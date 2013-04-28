using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using WinEngine.Entity;

namespace WinEngine.Screen.Scene
{
    public abstract class GameScene : GameEntity
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        protected string idName = null;

        //================================================================
        //Constructors
        //================================================================
        public GameScene(string name)
            : base(0, 0)
        {
            this.idName = name;
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public string Name { get { return idName; } }
        public bool Paused { get; set; }
        public bool Hidden { get; set; }
        public bool IsShutDown { get; set; }
        public bool IsCreated { get; private set; }

        //================================================================
        //Methodes
        //================================================================
        public virtual void Create()
        {
            IsCreated = true;
        }

        public abstract void Draw();

        public virtual void ShutDown()
        {
            IsShutDown = true;
        }
        public virtual void Pause()
        {
            Paused = true;
        }
        public virtual void Resume()
        {
            Paused = false;
        }
        public virtual void Hid()
        {
            Hidden = true;
        }
        public virtual void Show()
        {
            Hidden = false;
        }

        public virtual bool OnKeyDown(GamePadButtons button)
        {
            return true;
        }
        //================================================================
        //Methodes overridde
        //================================================================

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
