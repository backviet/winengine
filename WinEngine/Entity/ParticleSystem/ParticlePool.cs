using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using WinEngine.Util.Pool;
using WinEngine.Texture;

namespace WinEngine.Entity.ParticleSystem
{
    public class ParticlePool : GenericPool<Particle>
    {
        private readonly TextureRegion[] regions;
        private int index;
        private int lenght;

        public ParticlePool(params TextureRegion[] regions)
            : base()
        {
            this.regions = regions;
            index = 0;
            lenght = regions.Length;
        }

        public ParticlePool(int capacity, params TextureRegion[] regions)
            : base(capacity)
        {
            this.regions = regions;
            index = 0;
            lenght = regions.Length;
        }

        public override Particle NewObject()
        {
            index %= lenght;
            Particle par = new Particle(new Vector2(0, 0), regions[index].DeepCopy());
            index++;
            return par;
        }

        public override void OnRecycle(Particle obj)
        {
            obj.Reset();
        }
    }
}
