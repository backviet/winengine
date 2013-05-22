using Microsoft.Xna.Framework;

namespace WinEngine.Entity.ParticleSystem
{
    public interface IParticleSetting
    {
        Vector2 PositionEmitter { get; set; }
        void Setting(Particle par);
    }
}
