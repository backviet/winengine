using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace WinEngine.Util
{
    public class RunnableUpdateHandler : IUpdateHandler
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private List<Runnable> runnables;

        //================================================================
        //Constructors
        //================================================================
        public RunnableUpdateHandler()
        {
            runnables = new List<Runnable>();
        }

        //================================================================
        //Getter and Setter
        //================================================================

        //================================================================
        //Methodes
        //================================================================
        public void post(Runnable run)
        {
            if (run != null)
            {
                runnables.Add(run);
            }
        }

        //================================================================
        //Methodes overridde
        //================================================================
        public void Update(GameTime gameTime)
        {
            List<Runnable> runs = this.runnables;
            foreach (Runnable run in runs)
            {
                run.Run();
            }
            runs.Clear();
        }

        public void Reset()
        {
            runnables.Clear();
        }

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
