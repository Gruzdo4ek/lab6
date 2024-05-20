using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp6
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;

        // Метод, определяющий воздействие точки на частицу
        public abstract void ImpactParticle(Particle particle);

        // Метод для рендеринга точки
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }

    public class GravityPoint : IImpactPoint
    {
        public int Power = 100;

        // Воздействие гравитационной точки на частицу
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < Power / 2)
            {
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
        }

        // Метод для рендеринга гравитационной точки
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
        }
    }

    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100;

        // Воздействие антигравитационной точки на частицу
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= gX * Power / r2;
            particle.SpeedY -= gY * Power / r2;
        }
    }

    public class EnterPort : IImpactPoint //Класс для создания объектов входа и выхода телепортов
    {
        public int Power = 100;
        public float X2, Y2;

        private int enterCount = 0; // Счетчик входов
        private int exitCount = 0;  // Счетчик выходов

        // Воздействие точки телепорта на частицу
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < Power / 2)
            {
                enterCount++;
                exitCount++;
                particle.X += X2 - this.X;
                particle.Y += Y2 - this.Y;
            }
        }



        // Метод для рендеринга точки телепорта
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                new Pen(Color.Blue),
                X - Power / 2,
                Y - Power / 2,
                Power,
                Power
            );
            g.DrawEllipse(
                new Pen(Color.Orange),
                X2 - Power / 2,
                Y2 - Power / 2,
                Power,
                Power
            );

            // Рендерим количество входов и выходов
            DrawCenteredText(g, enterCount.ToString(), X, Y, Color.White);
            DrawCenteredText(g, exitCount.ToString(), X2, Y2, Color.White);
        }

        // Метод для рисования текста в центре круга
        private void DrawCenteredText(Graphics g, string text, float x, float y, Color color)
        {
            using (Font font = new Font("Arial", 12, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(color))
            {
                SizeF textSize = g.MeasureString(text, font);
                g.DrawString(text, font, brush, x - textSize.Width / 2, y - textSize.Height / 2);
            }
        }

    }

    public class PrintPoint : IImpactPoint //краситель частиц
    {
        public int Power = 100;
        internal Color Color;

        // Воздействие точки красителя на частицу
        public override void ImpactParticle(Particle particle)
        {

            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < Power / 2)
            {

                if (particle is ParticleColorful)
                {
                    var p = (particle as ParticleColorful);
                    p.FromColor = Color;
                    p.ToColor = Color;
                }
            }
        }

        // Метод для рендеринга точки красителя
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
            new Pen(Color.Pink),
            X - Power / 2,
            Y - Power / 2,
            Power,
            Power
            );
        }
    }
}
