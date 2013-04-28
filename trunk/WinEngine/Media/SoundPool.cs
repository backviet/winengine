using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

using WinEngine.Util.Pool;

namespace WinEngine.Media
{
    public class SoundPool : GenericPool<SoundEffectInstance>
    {
        private SoundEffect sound;

        public SoundPool(ref SoundEffect soundEffect)
            : base(4)
        {
            sound = soundEffect;
        }

        public override SoundEffectInstance NewObject()
        {
            return sound.CreateInstance();
        }

        public override void OnRecycle(SoundEffectInstance obj)
        {
            obj.IsLooped = false;
            obj.Stop();
            obj.Volume = 1;
        }

        public override void Dispose()
        {
            base.Dispose();
            foreach (SoundEffectInstance sf in freeObject)
            {
                sf.Dispose();
            }
            freeObject.Clear();
            sound.Dispose();
        }

        public SoundEffect Sound()
        {
            return sound;
        }
    }
}
