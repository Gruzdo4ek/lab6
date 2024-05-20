using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp6
{
    public class Particle
    {
        public int Radius; // радиус частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве

        public float SpeedX; // скорость перемещения по оси X
        public float SpeedY; // скорость перемещения по оси Y

        public float Life;
        public static Random rand = new Random();

        // Конструктор класса Particle, инициализирует свойства частицы
        public Particle()
        {
            var direction = (double)rand.Next(360);
            var speed = 1 + rand.Next(10);

            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }

        // Метод отрисовки частицы
        public virtual void Draw(Graphics g)
        {
            // Вычисляем коэффициент прозрачности и значение альфа-канала
            float k = Math.Min(1f, Life / 100);
            int alpha = (int)(k * 255);
            alpha = Math.Max(0, Math.Min(255, alpha)); // Убеждаемся, что alpha в допустимом диапазоне

            var color = Color.FromArgb(alpha, Color.Empty);
            var b = new SolidBrush(color);

            // Рисуем круг, представляющий частицу
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            b.Dispose();
        }
    }

    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;

        // Смешивает два цвета с заданным коэффициентом
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        // отрисовки частицы с цветовым переходом от FromColor к ToColor
        public override void Draw(Graphics g)
        {
            // Вычисляем коэффициент прозрачности и убеждаемся, что он в допустимом диапазоне
            float k = Math.Max(0, Math.Min(1f, Life / 100));
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            // Рисуем круг, представляющий частицу
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            // Освобождаем ресурсы, занятые кистью
            b.Dispose();
        }
    }

}
