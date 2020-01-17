using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRARPG
{
    public partial class Form1 : Form
    {
        int wybor;
        public Form1()
        {
            
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.dex3;
            pictureBox2.Image = Properties.Resources.mag;
            pictureBox3.Image = Properties.Resources.woj;
            backgroundWorker1.RunWorkerAsync();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            wybor = 1;
            btn_dex.BackColor = Color.Goldenrod;
            btn_int.BackColor = Color.Black;
            button3.BackColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        public void btn_start_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                this.Hide();
                Form2 f2 = new Form2(textBox1.Text, wybor);
                f2.ShowDialog();
                this.Close();
            }
            
            else
                MessageBox.Show("Musisz podac Imie");
            
        }

        private void btn_int_Click(object sender, EventArgs e)
        {

            wybor = 2;
            btn_int.BackColor = Color.Goldenrod;
            btn_dex.BackColor = Color.Black;
            button3.BackColor = Color.Black;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            wybor = 3;
            btn_dex.BackColor = Color.Black;
            btn_int.BackColor = Color.Black;
            button3.BackColor = Color.Goldenrod;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
 
            SoundPlayer audio = new SoundPlayer(GRARPG.Properties.Resources.menu1); 
            audio.PlayLooping();
        }

        private void Autor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor:\n" + "Bartosz Tomaszewski");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
