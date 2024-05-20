using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp6;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WinFormsApp6
{
    public class Emitter
    {
        List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        public int MousePositionX;
        public int MousePositionY;

        public float GravitationX = 0;
        public float GravitationY = 1;

        public int ParticlesCount => particles.Count;

        public int X;
        public int Y;

        public int Direction = 0;
        public int Spreading = 360;

        public int SpeedMin = 1;
        public int SpeedMax = 10;

        public int RadiusMin = 2;
        public int RadiusMax = 10;

        public int LifeMin = 20;
        public int LifeMax = 100;

        public int ParticlesPerTick = 0;

        public Color ColorFrom = Color.White;
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        public void AdjustParticleCount(int newCount)
        {
            int difference = newCount - ParticlesCount;

            ParticlesPerTick = newCount; 

            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                {
                    var particle = CreateParticle();
                    ResetParticle(particle);
                    particles.Add(particle);
                }
            }
            else if (difference < 0)
            {
                particles.RemoveRange(0, -difference);
            }
        }

        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                if (particle.Life < 0)
                {
                    ResetParticle(particle);
                }
                else
                {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                    particle.Life -= 1;

                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }

            int particlesToCreate = ParticlesPerTick - particles.Count;
            if (particlesToCreate > 0)
            {
                for (int i = 0; i < particlesToCreate; i++)
                {
                    var particle = CreateParticle();
                    ResetParticle(particle);
                    particles.Add(particle);
                }
            }
        }

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }

        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction
            + (double)Particle.rand.Next(Spreading)
                - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);

            // Сброс цветовых параметров частицы
            if (particle is ParticleColorful colorfulParticle)
            {
                colorfulParticle.FromColor = ColorFrom;
                colorfulParticle.ToColor = ColorTo;
            }
        }

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
    }
}
