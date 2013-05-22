using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WinEngine.Texture;

namespace WinEngine.Entity.ParticleSystem
{
    public class ParticleFactory
    {
        private List<Particle> particles;
        private ParticlePool pool;
        public IParticleSetting particleSetting;
        
        private int limit;
        private int particlePerCreate;

        public ParticleFactory(int limit, int particlePerCreate, IParticleSetting setting, params TextureRegion[] regions)
        {
            this.pool = new ParticlePool(regions);
            particles = new List<Particle>();
            this.limit = limit;
            this.particlePerCreate = particlePerCreate;
            if (setting == null)
            {
                throw new Exception("setting must be not null");
            }
            particleSetting = setting;
        }

        public bool IsCreate { get; set; }

        public void Update(GameTime gameTime)
        {
            if (IsCreate && particles.Count < limit - particlePerCreate)
            {
                for (int i = 0; i < particlePerCreate; i++)
                {
                    Particle par = pool.Obtains();
                    particleSetting.Setting(par);
                    particles.Add(par);
                }
            }

            Particle particle;
            for (int i = particles.Count - 1; i >= 0; i--)
            {
                particle = particles[i];
                particle.Update(gameTime);
                if (!particle.Alive)
                {
                    pool.Recycle(particle);
                    particles.Remove(particle);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Particle par in particles)
            {
                par.Draw(spriteBatch);
            }
        }

        public void Clear()
        {
            Particle particle;
            for (int i = particles.Count - 1; i >= 0; i--)
            {
                particle = particles[i];
                {
                    pool.Recycle(particle);
                    particles.Remove(particle);
                }
            }
        }
    }
}
