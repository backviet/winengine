using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WinEngine.Texture;

namespace WinEngine.Entity.ParticleSystem
{
    public class Particle : GameEntity
    {
        private TextureRegion region;

        public Particle(Vector2 pos, TextureRegion region)
            : base(pos)
        {
            if (region == null)
            {
                throw new Exception("null region particle");
            }

            this.region = region;
        }

        public bool Alive { get; set; }                 // life of the particle
        public Vector2 Velocity { get; set; }           // The speed of the particle at the current instance
        public float RotationVelocity { get; set; }     // The speed that the angle is changing
        public double TTL { get; set; }                 // The 'time to live' of the particle

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(region.Texture, Position, region.Bounds, Color, Rotation, Origin, Scaling, Flip, 0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            TTL -= gameTime.ElapsedGameTime.TotalSeconds;
            if (TTL <= 0)
            {
                Alive = false;
            }
            Position += Velocity;
            Rotation += RotationVelocity;
        }

        public override void Reset()
        {
            base.Reset();
            Alive = true;
        }
    }
}
