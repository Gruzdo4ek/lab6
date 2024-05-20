
using static WinFormsApp6.Particle;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        EnterPort port;
        AntiGravityPoint antig;
        PrintPoint printPoint;
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 20,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 0,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
            emitters.Add(this.emitter);

            antig = new AntiGravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2
            };
            emitter.impactPoints.Add(antig);

            port = new EnterPort
            {
                X2 = picDisplay.Width / 2 - 300,
                Y2 = picDisplay.Height / 2,
                X = picDisplay.Width / 2 + 200,
                Y = picDisplay.Height / 2 + 100,
            };
            emitter.impactPoints.Add(port);


            printPoint = new PrintPoint
            {
                Color = Color.Pink,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2 - 150,
            };
            emitter.impactPoints.Add(printPoint);
        }

        private void picDisplay_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // тут теперь обновляем эмиттер

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // а тут теперь рендерим через эмиттер
            }

            picDisplay.Invalidate();

        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
            antig.X = e.X;
            antig.Y = e.Y;

        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            port.Power = tbGraviton1.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            printPoint.Power = tbGraviton2.Value;
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                port.X = e.X;
                port.Y = e.Y;
            }
            else
            {
                port.X2 = e.X;
                port.Y2 = e.Y;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbParticleCount_Scroll(object sender, EventArgs e)
        {
            emitter.AdjustParticleCount(tbParticleCount.Value);
            lblCount.Text = $"{emitter.ParticlesCount} particles";
        }
    }
}