using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRARPG
{
    public partial class Form3 : Form
    {

        public int pkt = 5;
        public int wybor;
        public double hp2, eng2, def2, dps2, hp, eng, def, dps;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(pkt==0)
            {
                Form2.newhp = hp;
                Form2.newdef = def;
                Form2.neweng = eng;
                Form2.newdps = dps;
                
                this.Close();
            }
            else
                MessageBox.Show("Wykorzystaj wszytskie pkt umiejetnosci");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hp = hp2;
            eng = eng2;
            def = def2;
            dps = dps2;
            pkt = 5;
            label7.Text = Convert.ToString(pkt);
            label8.Text = Convert.ToString(hp);
            label11.Text = Convert.ToString(def);
            label10.Text = Convert.ToString(dps);
            label9.Text = Convert.ToString(eng);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pkt > 0)
            {
                def=def+5;
                label11.Text = Convert.ToString(def);
                pkt--;
                label7.Text = Convert.ToString(pkt);
            }
            else
                MessageBox.Show("Masz za malo pkt umiejetnosci");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pkt > 0)
            {
                dps=dps+5;
                label10.Text = Convert.ToString(dps);
                pkt--;
                label7.Text = Convert.ToString(pkt);
            }
            else
                MessageBox.Show("Masz za malo pkt umiejetnosci");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pkt > 0)
            {
                eng=eng+10;
                label9.Text = Convert.ToString(eng);
                pkt--;
                label7.Text = Convert.ToString(pkt);
            }
            else
                MessageBox.Show("Masz za malo pkt umiejetnosci");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if(pkt>0)
            {
                hp=hp+10;
                label8.Text = Convert.ToString(hp);
                pkt--;
                label7.Text = Convert.ToString(pkt);
            }
            else
                MessageBox.Show("Masz za malo pkt umiejetnosci");

        }

        public Form3(int wybor, double hp, double eng, double def, double dps)
        {
            InitializeComponent();
            this.wybor = wybor;
            this.hp = hp;
            this.eng = eng;
            this.def = def;
            this.dps = dps;
            hp2 = hp;
            def2 = def;
            dps2 = dps;
            eng2 = eng;
            label7.Text = Convert.ToString(pkt);
            label8.Text = Convert.ToString(hp);
            label11.Text = Convert.ToString(def);
            label10.Text = Convert.ToString(dps);
            label9.Text = Convert.ToString(eng);
            if (wybor == 1)
            {
                label4.Text = "dex";
                label3.Text = "max sp";
                pictureBox1.Image = Properties.Resources.icon1;


            }
            if (wybor == 2)
            {
                label3.Text = "max mp";
                label4.Text = "int";
                pictureBox1.Image = Properties.Resources.icon2;

            }
            else if(wybor==3)
            {
                label3.Text = "max rage";
                pictureBox1.Image = Properties.Resources.icon3;
                label4.Text = "str";
                
            }
        }

        
    }
}
