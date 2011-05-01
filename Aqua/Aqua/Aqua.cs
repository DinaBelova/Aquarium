using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aqua
{
    public partial class Aqua : Form
    {
        private int fishCount = 15;
        private AquaCore aquaCore = AquaCore.Instance;
               
        public Aqua()
        {
            InitializeComponent();
        }
        private void Aqua_Load(object sender, EventArgs e)
        {
            aquaCore.Initialize(fishCount, this.Width, this.Height);
            Timer.Enabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            aquaCore.Resize(Width, Height);
            aquaCore.Refresh(Width, Height);
            Bitmap bitmap = new Bitmap(ImagePool.Instance.background, Width, Height);
            Graphics g = Graphics.FromImage(bitmap);
            aquaCore.Draw(g);
            pictureBox.Image = bitmap;
            pictureBox.Refresh();

         }     

        private void Aqua_MouseClick(object sender, MouseEventArgs e)
        {
            aquaCore.Select(e.X, e.Y);
        }

        private void Aqua_Paint(object sender, PaintEventArgs e)
        {
            AquaCore.Instance.Draw(e.Graphics);
        }


       
    }
}
