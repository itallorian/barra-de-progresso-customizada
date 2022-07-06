namespace Barra_de_Progresso_Customizada
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        double pbUnit;
        int pbWIDTH, pbHEIGHT, pbComplete;

        Bitmap bmp;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbWIDTH = picboxPB.Width;
            pbHEIGHT = picboxPB.Height;

            pbUnit = pbWIDTH / 100.0;

            pbComplete = 0;

            bmp = new Bitmap(pbWIDTH, pbHEIGHT);

            t.Interval = 50;    
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);
            
            g.Clear(Color.LightSkyBlue);
            g.FillRectangle(Brushes.CornflowerBlue, new Rectangle(0, 0, (int)(pbComplete * pbUnit), pbHEIGHT));
            g.DrawString(pbComplete + "%", new Font("Arial", pbHEIGHT / 2), Brushes.Black, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));

            picboxPB.Image = bmp;

            pbComplete++;

            if (pbComplete > 100)
            {
                g.Dispose();
                t.Stop();
            }

        }
    }
}