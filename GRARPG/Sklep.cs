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
    public partial class Sklep : Form
    {
        public int  jakabron, jakabron2,jakazbroja2,  wybor, koszt = 0, jakazbroja, kosztbroni, kosztzbroi, hppotion, specialpotion;
        public double gold;

        private void button3_Click(object sender, EventArgs e)
        {
            kosztbroni = 15000;
            jakabron = 3;
            koszt = kosztbroni + kosztzbroi;
            label3.Text = Convert.ToString(koszt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kosztzbroi = 5000;
            jakazbroja = 1;
            koszt = kosztbroni + kosztzbroi;
            label3.Text = Convert.ToString(koszt);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kosztzbroi = 10000;
            jakazbroja = 2;
            koszt = kosztbroni + kosztzbroi;
            label3.Text = Convert.ToString(koszt);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (hppotion > 0)
            {
                hppotion = hppotion - 1;
                gold = gold + 500;
                label4.Text = Convert.ToString(Convert.ToInt32(gold));
                label21.Text = Convert.ToString(hppotion);
            }
            else
                MessageBox.Show("Nie masz mikstur na sprzedarz");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(this.gold>=500)
            {
                specialpotion = specialpotion + 1;
                gold = gold - 500;
                label4.Text = Convert.ToString(Convert.ToInt32(gold));
                label22.Text = Convert.ToString(specialpotion);
            }
            else
                MessageBox.Show("Nie masz dosc zlota");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (specialpotion > 0)
            {
                specialpotion = specialpotion - 1;
                gold = gold + 500;
                label4.Text = Convert.ToString(Convert.ToInt32(gold));
                label22.Text = Convert.ToString(specialpotion);
            }
            else
                MessageBox.Show("Nie masz mikstur na sprzedarz");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            jakabron = jakabron2;
            kosztbroni = 0;
            koszt = kosztzbroi+kosztbroni;
            label3.Text = Convert.ToString(koszt);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            jakazbroja = jakazbroja2;
            kosztzbroi = 0;
            koszt = kosztzbroi + kosztbroni;
            label3.Text = Convert.ToString(koszt);
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            if (gold >= koszt)
            {
                Form2.jakabron = jakabron;
                Form2.jakazbroja = jakazbroja;
                Form2.specialpotion = Form2.specialpotion + specialpotion;
                Form2.hppotion = Form2.hppotion + hppotion;
                gold = gold - koszt;
                koszt = 0;
                this.Close();
            }
            else
                MessageBox.Show("Nie masz wystarczajaco zlota");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            kosztzbroi = 15000;
            jakazbroja = 3;
            koszt = kosztbroni + kosztzbroi;
            label3.Text = Convert.ToString(koszt);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.gold >= 500)
            {
                hppotion = hppotion + 1;
                gold = gold - 500;
                label4.Text = Convert.ToString(Convert.ToInt32(gold));
                label21.Text = Convert.ToString(hppotion);
            }
            else
                MessageBox.Show("Nie masz dosc zlota");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            kosztbroni = 5000;
            jakabron = 1;
            koszt = kosztbroni + kosztzbroi;
            label3.Text = Convert.ToString(koszt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kosztbroni = 10000;
            jakabron = 2;
            koszt = kosztbroni + kosztzbroi;
            label3.Text = Convert.ToString(koszt);
        }

        

        public Sklep(int wybor, double gold, int jakabron, int jakazbroja)
        {
            InitializeComponent();
            this.gold = gold;
            this.wybor = wybor;           
            this.jakabron = jakabron;
            this.jakazbroja = jakazbroja;
            this.jakabron2 = jakabron;
            this.jakazbroja2 = jakazbroja;
            label4.Text = Convert.ToString(Convert.ToInt32(gold));
            label3.Text = Convert.ToString(koszt);
            pictureBox2.Image = Properties.Resources.armor1;
            pictureBox3.Image = Properties.Resources.armor2;
            pictureBox4.Image = Properties.Resources.armor3;


            if (wybor == 1)
            {     
                pictureBox1.Image = Properties.Resources.icon1;
                pictureBox9.Image = Properties.Resources.sp;
                pictureBox5.Image = Properties.Resources.sztylet1;
                pictureBox6.Image = Properties.Resources.sztylet2;
                pictureBox7.Image = Properties.Resources.sztylet3;

            }
            if (wybor == 2)
            {
                pictureBox1.Image = Properties.Resources.icon2;
                pictureBox9.Image = Properties.Resources.mp;
                pictureBox5.Image = Properties.Resources.laska1;
                pictureBox6.Image = Properties.Resources.laska2;
                pictureBox7.Image = Properties.Resources.laska3;
            }
            else if (wybor == 3)
            {
                pictureBox1.Image = Properties.Resources.icon3;
                pictureBox9.Image = Properties.Resources.rage; 
                pictureBox5.Image = Properties.Resources.miecz1;
                pictureBox6.Image = Properties.Resources.miecz2;
                pictureBox7.Image = Properties.Resources.miecz3;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
