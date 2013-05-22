using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using WinEngine.Screen.View;

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

        //private List<Layer> layers;
        //private List<BaseView> views;

        //private HUD hud;

        //================================================================
        //Constructors
        //================================================================
        public GameScene(string name)
            : base(0, 0)
        {
            this.idName = name;
            //layers = new List<Layer>();
            //views = new List<BaseView>();
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public string Name { get { return idName; } }
        public bool Paused { get; set; }
        public bool Hidden { get; set; }
        public bool IsShutDown { get; set; }
        public bool IsCreated { get; private set; }

        //public void SetHud(ref HUD hud)
        //{
        //    this.hud = hud;
        //}

        //public HUD GetHud()
        //{
        //    return this.hud;
        //}

        //================================================================
        //Methodes
        //================================================================

        #region Phat trien ve sau

        //public void AddLayer(ref Layer layer)
        //{
        //    this.layers.Add(layer);
        //}

        //public void AddLayer(ref Layer layer, int index)
        //{
        //    this.layers.Insert(index, layer);
        //}

        //public void RemoveLayer(ref Layer layer)
        //{
        //    layers.Remove(layer);
        //}

        //public void RemoveLayer(int index)
        //{
        //    layers.RemoveAt(index);
        //}

        //public void AddView(ref BaseView view)
        //{
        //    views.Add(view);
        //}

        //public void AddView(ref BaseView view, int index)
        //{
        //    views.Insert(index, view);
        //}

        //public void RemoveView(ref BaseView view)
        //{
        //    views.Remove(view);
        //}

        //public void RemoveView(int index)
        //{
        //    views.RemoveAt(index);
        //}

        //public virtual void Update(GameTime gameTime)
        //{
        //    foreach (Layer layer in layers)
        //    {
        //        layer.Update(gameTime);
        //    }

        //    if (hud != null)
        //    {
        //        hud.Update(gameTime);
        //    }

        //    foreach (BaseView view in views)
        //    {
        //        view.Update(gameTime);
        //    }
        //}

        //public virtual void Draw()
        //{
        //    foreach (Layer layer in layers)
        //    {
        //        layer.Draw();
        //    }

        //    if (hud != null)
        //    {
        //        hud.Draw();
        //    }

        //    foreach (BaseView view in views)
        //    {
        //        view.Draw();
        //    }
        //}
        #endregion

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
