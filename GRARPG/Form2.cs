using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GRARPG
{
    public partial class Form2 : Form
    {
        public static double newhp, newdef, newdps, neweng;
        string text1, enemyimie;
        static public int jakabron = 0, jakazbroja = 0;
        static public int hppotion = 0;
        static public int specialpotion = 0;
        public int efekt = 5, wybor;
        public int licznik = 0;
        int czyobrona = 0;
        int enemyobrona = 0;
        public dynamic Bohater
        { get; set; }
        public Enemy enemy;

        public Form2(string text2, int wybor)
        {
            InitializeComponent();


            this.text1 = text2;
            this.wybor = wybor;
            this.Bohater = HeroSelection(wybor);
            label1.Text = text1;
            statystyki();
            czylvlup();
            Bohater.lvl_next = 100;

            spawnEnemy();
            statystyki();


            

        }
        public void ChangeButtonsState()
        {
            button1.Enabled = !button1.Enabled;
            button2.Enabled = !button2.Enabled;
            button4.Enabled = !button4.Enabled;
            btn_atack2.Enabled = !btn_atack2.Enabled;
        }


        public void spawnEnemy()
        {
            pictureBox11.Image = null;
            pictureBox2.Image = null;
            this.efekt = 5;
            this.licznik = 0;
            label21.Text = ".";
            Random stat = new Random();
            int jakieimie = stat.Next(0, 10);
            string[] tabimie = { "Szkielet", "Goblin", "Drzewiec", "Zombie", "Demon", "Dzikus", "Mumia", "Yeti", "Wilkolak", "Minotaur" };
            this.enemyimie = tabimie[jakieimie];
            string imie = tabimie[jakieimie];
            switch (jakieimie)
            {
                case 0:
                    pictureBox3.Image = Properties.Resources.szkielet;
                    break;
                case 1:
                    pictureBox3.Image = Properties.Resources.goblin;
                    break;

                case 2:
                    pictureBox3.Image = Properties.Resources.drzewiec;
                    break;
                case 3:
                    pictureBox3.Image = Properties.Resources.przeklety;
                    break;
                case 4:
                    pictureBox3.Image = Properties.Resources.demon;
                    break;

                case 5:
                    pictureBox3.Image = Properties.Resources.dzikus;
                    break;
                case 6:
                    pictureBox3.Image = Properties.Resources.mumia;
                    break;
                case 7:
                    pictureBox3.Image = Properties.Resources.yeti;
                    break;

                case 8:
                    pictureBox3.Image = Properties.Resources.wilkolak;
                    break;
                default:
                    pictureBox3.Image = Properties.Resources.minotaur;
                    break;
            }
            double hp = stat.Next(Convert.ToInt32(Bohater.hp_max ), Convert.ToInt32(Bohater.hp_max + 11));
            double def = stat.Next(Convert.ToInt32(Bohater.def ), Convert.ToInt32(Bohater.def + 11));

            if (Bohater.GetType().Name == "Lotrzyk")
            {

                double str = stat.Next(Convert.ToInt32(Bohater.dex ), Convert.ToInt32(Bohater.dex + 11));
                double stamina = stat.Next(Convert.ToInt32(Bohater.sp_max - 10), Convert.ToInt32(Bohater.sp_max + 11));
                double gold =hp + stamina + str + def;
                double exp = ((hp + stamina) * 1 / 4) + str + def;
                this.enemy = Enemy.NewEnemy(imie, hp, stamina, str, def, gold, exp);
                enemystat();
            }
            else if (Bohater.GetType().Name == "Mag")
            {
                double str = stat.Next(Convert.ToInt32(Bohater.Int ), Convert.ToInt32(Bohater.Int + 11));
                double stamina = stat.Next(Convert.ToInt32(Bohater.mp_max - 10), Convert.ToInt32(Bohater.mp_max + 11));
                double gold = hp + stamina + str + def;
                double exp = ((hp + stamina) * 1 / 4) + str + def;
                this.enemy = Enemy.NewEnemy(imie, hp, stamina, str, def, gold, exp);
                enemystat();
            }
            else if (Bohater.GetType().Name == "Wojownik")
            {
                double str = stat.Next(Convert.ToInt32(Bohater.str ), Convert.ToInt32(Bohater.str + 11));
                double stamina = stat.Next(Convert.ToInt32(Bohater.rage_max - 10), Convert.ToInt32(Bohater.rage_max + 11));
                double gold = hp + stamina + str + def;
                double exp = ((hp + stamina) * 1 / 4) + str + def;
                this.enemy = Enemy.NewEnemy(imie, hp, stamina, str, def, gold, exp);
                enemystat();

            }
            label10.Text = imie;
            progressBar3.Maximum = Convert.ToInt32(enemy.hp_max);
            progressBar3.Value = Convert.ToInt32(enemy.hp);
            progressBar4.Maximum = Convert.ToInt32(enemy.stamina_max);
            progressBar4.Value = Convert.ToInt32(enemy.stamina);
            
            
            

        }
        dynamic HeroSelection(int wybor)
        {

            if (wybor == 1)
            {
                btn_atack2.Text = "Zatrute Ostrze";
                label20.Text = "max sp";
                label8.Text = "dex";
                pictureBox1.Image = Properties.Resources.icon1;
                pictureBox9.Image = Properties.Resources.sp;
                this.progressBar1.ForeColor = System.Drawing.Color.Peru;
                return new Lotrzyk(50, 900, 900, 40, 0, 0, 0, 1000, text1, 200, 200);

            }
            else if (wybor == 2)
            {
                btn_atack2.Text = "Kula Ognia";
                label20.Text = "max mp";
                label8.Text = "int";
                pictureBox1.Image = Properties.Resources.icon2;
                pictureBox9.Image = Properties.Resources.mp;
                this.progressBar1.ForeColor = System.Drawing.Color.Blue;
                return new Mag(50, 700, 700, 35, 0, 0, 0, 1000, text1, 200, 200);
            }
            else
            {
                btn_atack2.Text = "Rzut Toporem";
                pictureBox1.Image = Properties.Resources.icon3;
                pictureBox9.Image = Properties.Resources.rage;
                label8.Text = "str";
                label20.Text = "max rage";
                this.progressBar1.ForeColor = System.Drawing.Color.Peru;
                return new Wojownik(50, 650, 650, 55, 0, 0, 0, 1000, text1, 250, 250);
            }


        }
        async void cios()
        {
            Random rand = new Random();
            int stun = rand.Next(1, 11);
            if (Bohater.GetType().Name == "Lotrzyk")
            {
                atack.RunWorkerAsync();
                if (jakabron==0)
                {
                    double hit = (Bohater.dex) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.sp = this.Bohater.sp - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if(jakabron==1)
                {
                    double hit = (Bohater.dex+20) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.sp = this.Bohater.sp - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if(jakabron==2)
                {
                    double hit = (Bohater.dex+30) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.sp = this.Bohater.sp - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if(jakabron==3)
                {
                    double hit = (Bohater.dex+40) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.sp = this.Bohater.sp - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }


            }
            else if (Bohater.GetType().Name == "Mag")
            {
                magatack.RunWorkerAsync();
                if (jakabron==0)
                {
                    double hit = (Bohater.Int) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.mp = this.Bohater.mp - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if(jakabron==1)
                {
                    double hit = (Bohater.Int+20) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.mp = this.Bohater.mp - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if(jakabron==2)
                {
                    double hit = (Bohater.Int+30) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.mp = this.Bohater.mp - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if(jakabron==3)
                {
                    double hit = (Bohater.Int+40) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.mp = this.Bohater.mp - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }

            }
            else
            {
                atack.RunWorkerAsync();
                if (jakabron == 0)
                {
                    double hit = (Bohater.str) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.rage = this.Bohater.rage - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if (jakabron == 1)
                {
                    double hit = (Bohater.str+20) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.rage = this.Bohater.rage - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if (jakabron == 2)
                {
                    double hit = (Bohater.str+30) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.rage = this.Bohater.rage - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if (jakabron == 3)
                {
                    double hit = (Bohater.str+40) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.rage = this.Bohater.rage - 20;
                    label21.Text = "szybki cios " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                

            }
            ciosanim();
            await Task.Delay(500);
            pictureBox4.Image = null;
            statystyki();
            enemystat();
            if (this.enemy.hp > 0 & stun > 1)
            {
                if (enemyobrona == 1)
                {
                    enemy.def = enemy.def / 2;
                    enemyobrona = 0;
                }
                enemyaction();
                statystyki();
            }
            else if (this.enemy.hp > 0 & stun == 1)
            {
                if (enemyobrona == 1)
                {
                    enemy.def = enemy.def / 2;
                    enemyobrona = 0;
                    
                }
                pictureBox11.Image = Properties.Resources.stun;
                await Task.Delay(500);
                pictureBox4.Image = null;
                label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " ogluszyl potwora  " + enemyimie + "\n" + label21.Text;
                ChangeButtonsState();
                statystyki();
            }

            else if (Convert.ToInt32(this.enemy.hp) <= 0)
            {
                if (enemyobrona == 1)
                {
                    enemy.def = enemy.def / 2;
                    enemyobrona = 0;
                }
                enemystat();
                pictureBox4.Image = null;
                Bohater.gold = Bohater.gold + enemy.gold;
                Bohater.exp = Bohater.exp + enemy.exp;
                statystyki();
                while (Bohater.exp > Bohater.lvl_next)
                {
                    
                    czylvlup();
                    statystyki();
                }
                ChangeButtonsState();
                statystyki();
                string message = "Czy chcesz odwiedzic sklep przed nastepna walka?";
                string caption = "Zwyciestwo";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;


                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    statystyki();
                    spawnEnemy();
                    enemystat();
                }
                else
                {
                    Sklep sklep = new Sklep(wybor, Bohater.gold, jakabron, jakazbroja);
                    sklep.ShowDialog();
                    Bohater.gold = sklep.gold;
                    jakiekwipunek();
                    statystyki();
                    spawnEnemy();
                    enemystat();

                }

            }

        }
        public async void cios2()
        {
            Random rand = new Random();
            int stun = rand.Next(1, 21);
            this.efekt = rand.Next(1, 21);
            
                
            if (Bohater.GetType().Name == "Lotrzyk")
            {
                specialatack.RunWorkerAsync();
                pictureBox4.Image = Properties.Resources.kkunai;
                if (jakabron == 0)
                {
                    double hit = (1.5 * (Bohater.dex)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.sp = this.Bohater.sp - 40;
                    label21.Text = "Zatrute ostrze " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadalo " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;

                }
                else if (jakabron == 1)
                {
                    double hit = (1.5 * (Bohater.dex+20)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.sp = this.Bohater.sp - 40;
                    label21.Text = "Zatrute ostrze " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadalo " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if (jakabron == 2)
                {
                    double hit = (1.5 * (Bohater.dex+30)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.sp = this.Bohater.sp - 40;
                    label21.Text = "Zatrute ostrze " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadalo " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if (jakabron == 3)
                {
                    double hit = (1.5 * (Bohater.dex+40)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.sp = this.Bohater.sp - 40;
                    label21.Text = "Zatrute ostrze " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadalo " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                
            }
            else if (Bohater.GetType().Name == "Mag")
            {
                fireball.RunWorkerAsync();
                pictureBox4.Image = Properties.Resources.kula_ognia;
                if (jakabron == 0)
                {
                    double hit = (1.5 * (Bohater.Int)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.mp = this.Bohater.mp - 40;
                    label21.Text = "Kula ognia " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadala " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                    
                }
                else if (jakabron == 1)
                {
                    double hit = (1.5 * (Bohater.Int+20)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.mp = this.Bohater.mp - 40;
                    label21.Text = "Kula ognia " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadala " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if (jakabron == 2)
                {
                    double hit = (1.5 * (Bohater.Int+30)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.mp = this.Bohater.mp - 40;
                    label21.Text = "Kula ognia " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadala " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if (jakabron == 3)
                {
                    double hit = (1.5 * (Bohater.Int+40)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.mp = this.Bohater.mp - 40;
                    label21.Text = "Kula ognia " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadala " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                

            }
            else
            {
                specialatack.RunWorkerAsync();
                pictureBox4.Image = Properties.Resources.topor_do_rzucania;
                if (jakabron == 0)
                {
                    double hit = (1.5 * (Bohater.str)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.rage = this.Bohater.rage - 40;
                    label21.Text = "Rzut Toporem " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;

                }
                else if (jakabron == 1)
                {
                    double hit = (1.5 * (Bohater.str+20)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.rage = this.Bohater.rage - 40;
                    label21.Text = "Rzut Toporem " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if (jakabron == 2)
                {
                    double hit = (1.5 * (Bohater.str+30)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.rage = this.Bohater.rage - 40;
                    label21.Text = "Rzut Toporem " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                else if (jakabron == 3)
                {
                    double hit = (1.5 * (Bohater.str+40)) - (this.enemy.def * 0.25);
                    Convert.ToInt32(hit);
                    if (hit < 0)
                        hit = 0;
                    this.enemy.hp = this.enemy.hp - hit;
                    this.Bohater.rage = this.Bohater.rage - 40;
                    label21.Text = "Rzut Toporem " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zadal " + Convert.ToString(hit) + " obrazen przeciwnikowi " + enemyimie + "\n" + label21.Text;
                }
                
            }
            if (efekt < 5)
            {
                licznik = 3;
                if (Bohater.GetType().Name == "Lotrzyk")
                {
                    label21.Text = "Zatrute ostrze " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " zatrulo przeciwnika\n" + label21.Text;
                    pictureBox2.Image = Properties.Resources.PoisonCleansingTotem;
                }
                else if (Bohater.GetType().Name == "Mag")
                {
                    label21.Text = "Kula ognia " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " podpalila przeciwnika\n" + label21.Text;
                    pictureBox2.Image = Properties.Resources.Fire;
                }
                else
                {
                    label21.Text = "Rzut Toporem " + Convert.ToString(Bohater.GetType().Name) + "a" + " " + Bohater.name + " wywolalo krwawienie u przeeciwnika\n" + label21.Text;
                    pictureBox2.Image = Properties.Resources.BloodPresence;
                }
            }
            await Task.Delay(500);
            pictureBox4.Image = null;
            statystyki();
            enemystat();
            if (this.enemy.hp > 0 & stun >= 5)
            {
                if (enemyobrona == 1)
                {
                    enemy.def = enemy.def / 2;
                    enemyobrona = 0;
                }
                
                enemyaction();
                
                statystyki();

            }
            else if (this.enemy.hp > 0 & stun < 5)
            {
                if (enemyobrona == 1)
                {
                    enemy.def = enemy.def / 2;
                    enemyobrona = 0;
                }
                pictureBox11.Image = Properties.Resources.stun;
                await Task.Delay(500);
                pictureBox4.Image = null;
                label21.Text = Convert.ToString(Bohater.GetType().Name) +  " " + Bohater.name + " ogluszyl potwora  "  + enemyimie + "\n" + label21.Text;
                ChangeButtonsState();
                statystyki();
            }

            else if (Convert.ToInt32(this.enemy.hp) <= 0)
            {
                if (enemyobrona == 1)
                {
                    enemy.def = enemy.def / 2;
                    enemyobrona = 0;
                }
                pictureBox4.Image = null;
                enemystat();
                Bohater.gold = Bohater.gold + enemy.gold;
                Bohater.exp = Bohater.exp + enemy.exp;
                statystyki();
                while (Bohater.exp > Bohater.lvl_next)
                {
                    
                    czylvlup();
                    statystyki();
                }
                ChangeButtonsState();
                string message = "Czy chcesz odwiedzic sklep przed nastepna walka?";
                string caption = "Zwyciestwo";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    statystyki();
                    spawnEnemy();
                    enemystat();
                }
                else
                {
                    Sklep sklep = new Sklep(wybor, Bohater.gold, jakabron, jakazbroja);
                    sklep.ShowDialog();
                    Bohater.gold = sklep.gold;
                    jakiekwipunek();
                    statystyki();
                    spawnEnemy();
                    enemystat();

                }

            }
        }
        void enemystat()
        {
            if (enemy.hp < 0)
                progressBar3.Value = 0;
            else
            {
                progressBar3.Maximum = Convert.ToInt32(enemy.hp_max);
                progressBar4.Maximum = Convert.ToInt32(enemy.stamina_max);
                progressBar3.Value = Convert.ToInt32(enemy.hp);
                progressBar4.Value = Convert.ToInt32(enemy.stamina);
            }
            if ((enemy.hp / enemy.hp_max) <= 0.7 & (enemy.hp / enemy.hp_max) > 0.3)
            {
                progressBar3.ForeColor = System.Drawing.Color.Gold;
            }
            else if ((enemy.hp / enemy.hp_max) <= 0.3)
            {
                progressBar3.ForeColor = System.Drawing.Color.Red;
            }
            else if ((enemy.hp / enemy.hp_max) > 0.7)
                progressBar3.ForeColor = System.Drawing.Color.LawnGreen;
        }
        void statystyki()
        {
            if (Bohater.hp < 0)
            {

                if (Bohater.GetType().Name == "Lotrzyk")
                {


                    progressBar2.Maximum = Convert.ToInt32(Bohater.hp_max);
                    progressBar2.Value = 0;
                    progressBar1.Maximum = Convert.ToInt32(Bohater.sp_max);
                    progressBar1.Value = Convert.ToInt32(Bohater.sp);
                    label7.Text = Convert.ToString(Bohater.lvl);
                    label9.Text = Convert.ToString(Bohater.def);
                    label5.Text = Convert.ToString(Bohater.dex);
                    label4.Text = Convert.ToString(Convert.ToInt32(Bohater.gold));
                    label13.Text = Convert.ToString(Convert.ToInt32(Bohater.exp));
                    label14.Text = Convert.ToString(Bohater.lvl_next);
                    label16.Text = Convert.ToString(Bohater.hp_max);
                    label19.Text = Convert.ToString(Bohater.sp_max);
                    label27.Text = Convert.ToString(hppotion);
                    label28.Text = Convert.ToString(specialpotion);
                }
                else if (Bohater.GetType().Name == "Mag")
                {


                    progressBar2.Maximum = Convert.ToInt32(Bohater.hp_max);
                    progressBar2.Value = 0;
                    progressBar1.Maximum = Convert.ToInt32(Bohater.mp_max);
                    progressBar1.Value = Convert.ToInt32(Bohater.mp);
                    label7.Text = Convert.ToString(Bohater.lvl);
                    label9.Text = Convert.ToString(Bohater.def);
                    label4.Text = Convert.ToString(Convert.ToInt32(Bohater.gold));                    
                    label13.Text = Convert.ToString(Convert.ToInt32(Bohater.exp));
                    label5.Text = Convert.ToString(Bohater.Int);
                    label14.Text = Convert.ToString(Bohater.lvl_next);
                    label16.Text = Convert.ToString(Bohater.hp_max);
                    label19.Text = Convert.ToString(Bohater.mp_max);
                    label27.Text = Convert.ToString(hppotion);
                    label28.Text = Convert.ToString(specialpotion);


                }
                else if (Bohater.GetType().Name == "Wojownik")
                {


                    progressBar2.Maximum = Convert.ToInt32(Bohater.hp_max);
                    progressBar2.Value = 0;
                    progressBar1.Maximum = Convert.ToInt32(Bohater.rage_max);
                    progressBar1.Value = Convert.ToInt32(Bohater.rage);
                    label7.Text = Convert.ToString(Bohater.lvl);
                    label9.Text = Convert.ToString(Bohater.def);
                    label4.Text = Convert.ToString(Convert.ToInt32(Bohater.gold));
                    label13.Text = Convert.ToString(Convert.ToInt32(Bohater.exp));
                    label5.Text = Convert.ToString(Bohater.str);
                    label14.Text = Convert.ToString(Bohater.lvl_next);
                    label16.Text = Convert.ToString(Bohater.hp_max);
                    label19.Text = Convert.ToString(Bohater.rage_max);
                    label27.Text = Convert.ToString(hppotion);
                    label28.Text = Convert.ToString(specialpotion);


                }

            }



            else
            {
                if (Bohater.GetType().Name == "Lotrzyk")
                {


                    progressBar2.Maximum = Convert.ToInt32(Bohater.hp_max);
                    progressBar2.Value = Convert.ToInt32(Bohater.hp);
                    progressBar1.Maximum = Convert.ToInt32(Bohater.sp_max);
                    progressBar1.Value = Convert.ToInt32(Bohater.sp);
                    label7.Text = Convert.ToString(Bohater.lvl);
                    label9.Text = Convert.ToString(Bohater.def);
                    label4.Text = Convert.ToString(Convert.ToInt32(Bohater.gold));
                    label13.Text = Convert.ToString(Convert.ToInt32(Bohater.exp));
                    label5.Text = Convert.ToString(Bohater.dex);
                    label14.Text = Convert.ToString(Bohater.lvl_next);
                    label16.Text = Convert.ToString(Bohater.hp_max);
                    label19.Text = Convert.ToString(Bohater.sp_max);
                    label27.Text = Convert.ToString(hppotion);
                    label28.Text = Convert.ToString(specialpotion);


                }
                else if (Bohater.GetType().Name == "Mag")
                {


                    progressBar2.Maximum = Convert.ToInt32(Bohater.hp_max);
                    progressBar2.Value = Convert.ToInt32(Bohater.hp);
                    progressBar1.Maximum = Convert.ToInt32(Bohater.mp_max);
                    progressBar1.Value = Convert.ToInt32(Bohater.mp);
                    label7.Text = Convert.ToString(Bohater.lvl);
                    label9.Text = Convert.ToString(Bohater.def);
                    label5.Text = Convert.ToString(Bohater.Int);
                    label4.Text = Convert.ToString(Convert.ToInt32(Bohater.gold));
                    label13.Text = Convert.ToString(Convert.ToInt32(Bohater.exp));
                    label14.Text = Convert.ToString(Bohater.lvl_next);
                    label16.Text = Convert.ToString(Bohater.hp_max);
                    label19.Text = Convert.ToString(Bohater.mp_max);
                    label27.Text = Convert.ToString(hppotion);
                    label28.Text = Convert.ToString(specialpotion);


                }
                else if (Bohater.GetType().Name == "Wojownik")
                {


                    progressBar2.Maximum = Convert.ToInt32(Bohater.hp_max);
                    progressBar2.Value = Convert.ToInt32(Bohater.hp);
                    progressBar1.Maximum = Convert.ToInt32(Bohater.rage_max);
                    progressBar1.Value = Convert.ToInt32(Bohater.rage);
                    label7.Text = Convert.ToString(Bohater.lvl);
                    label9.Text = Convert.ToString(Bohater.def);
                    label4.Text = Convert.ToString(Convert.ToInt32(Bohater.gold));
                    label13.Text = Convert.ToString(Convert.ToInt32(Bohater.exp));
                    label5.Text = Convert.ToString(Bohater.str);
                    label14.Text = Convert.ToString(Bohater.lvl_next);
                    label16.Text = Convert.ToString(Bohater.hp_max);
                    label19.Text = Convert.ToString(Bohater.rage_max);
                    label27.Text = Convert.ToString(hppotion);
                    label28.Text = Convert.ToString(specialpotion);

                }
                if ((Bohater.hp / Bohater.hp_max) <= 0.7 & (Bohater.hp / Bohater.hp_max) > 0.3)
                {
                    progressBar2.ForeColor = System.Drawing.Color.Gold;
                }
                else if ((Bohater.hp / Bohater.hp_max) <= 0.3)
                {
                    progressBar2.ForeColor = System.Drawing.Color.Red;
                }
                else if ((Bohater.hp / Bohater.hp_max) > 0.7)
                    progressBar2.ForeColor = System.Drawing.Color.LawnGreen;
            }

        }
        public void czylvlup()
        {

            if (Bohater.exp >= Bohater.lvl_next)
            {

                SoundPlayer lvl = new SoundPlayer(GRARPG.Properties.Resources.lvlup1);
                lvl.Play();
                if (wybor == 1)
                {
                    Form3 f3 = new Form3(wybor, Bohater.hp_max, Bohater.sp_max, Bohater.def, Bohater.dex);
                    f3.ShowDialog();
                    Bohater = Lotrzyk.lvlup(Bohater.lvl, Bohater.lvl_next, Bohater.gold, Bohater.exp, Bohater.name, newhp, neweng, newdps, newdef);
                    statystyki();

                }
                else if (wybor == 2)
                {
                    Form3 f3 = new Form3(wybor, Bohater.hp_max, Bohater.mp_max, Bohater.def, Bohater.Int);

                    f3.ShowDialog();



                    Bohater = Mag.lvlup(Bohater.lvl, Bohater.lvl_next, Bohater.gold, Bohater.exp, Bohater.name, newhp, neweng, newdps, newdef);
                    statystyki();
                }
                else if (wybor == 3)
                {
                    Form3 f3 = new Form3(wybor, Bohater.hp_max, Bohater.rage_max, Bohater.def, Bohater.str);
                    f3.ShowDialog();

                    Bohater = Wojownik.lvlup(Bohater.lvl, Bohater.lvl_next, Bohater.gold, Bohater.exp, Bohater.name, newhp, neweng, newdps, newdef);
                    statystyki();



                }



            }

        }



        public async void enemyaction()
        {
            pictureBox11.Image = null;
            
            await Task.Delay(1500);
            pictureBox4.Image = null;

            if (licznik > 0)
            {
                
                if (Bohater.GetType().Name == "Lotrzyk")
                {

                    
                    label21.Text ="Efekt zatrucia zadaje potworowi "+enemy.name +" 60 obrazen\n" + label21.Text;


                }
                else if (Bohater.GetType().Name == "Mag")
                {

                    
                    label21.Text = "Efekt poparzenia zadaje potworowi " + enemy.name + " 60 obrazen\n" + label21.Text;


                }
                else
                {

                    
                    label21.Text = "Efekt krwawienia zadaje potworowi " + enemy.name + " 60 obrazen\n" + label21.Text;


                }
                enemy.hp = enemy.hp - 60;
                licznik = licznik - 1;
                
                if (Convert.ToInt32(this.enemy.hp) <= 0)
                {
                    

                    enemystat();
                    enemyobrona = 0;
                    Bohater.gold = Bohater.gold + enemy.gold;
                    Bohater.exp = Bohater.exp + enemy.exp;
                    statystyki();
                    while (Bohater.exp > Bohater.lvl_next)
                    {
                        
                        czylvlup();
                        statystyki();
                    }
                    
                    string message = "Czy chcesz odwiedzic sklep przed nastepna walka?";
                    string caption = "Zwyciestwo";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;


                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        statystyki();
                        
                        spawnEnemy();
                        enemystat();
                        
                    }
                    else
                    {
                        Sklep sklep = new Sklep(wybor, Bohater.gold, jakabron, jakazbroja);
                        sklep.ShowDialog();
                        Bohater.gold = sklep.gold;
                        jakiekwipunek();
                        statystyki();
                        
                        spawnEnemy();
                        enemystat();
                        

                    }
                    
                }
                
                if (enemy.stamina < 20)
                {

                    enemywait();

                }
                else
                {
                    if (enemy.stamina <= 40)
                    {
                        Random rand = new Random();
                        int corobic = rand.Next(1, 11);
                        if (corobic < 4)
                            Eobrona();
                        else if (corobic > 3 & corobic < 7)
                            enemywait();
                        else
                            enemyatack();
                    }
                    else if (enemy.stamina < 70 & enemy.stamina > 40)
                    {
                        Random rand = new Random();
                        int corobic = rand.Next(1, 11);
                        if (corobic < 3)
                            Eobrona();

                        else if (corobic > 3 & corobic < 8)
                            enemyatack();
                        else
                            enemyatack2();

                    }
                    else if (enemy.stamina >= 70)
                    {
                        Random rand = new Random();
                        int corobic = rand.Next(1, 11);
                        if (corobic < 4)
                            Eobrona();

                        else if (corobic > 3 & corobic < 8)
                            enemyatack();
                        else
                            enemyatack2();
                    }
                }
            }
            else
            {
                pictureBox2.Image = null;
                if (enemy.stamina < 20)
                {

                    enemywait();

                }
                else
                {
                    if (enemy.stamina <= 40)
                    {
                        Random rand = new Random();
                        int corobic = rand.Next(1, 11);
                        if (corobic < 4)
                            Eobrona();
                        else if (corobic > 3 & corobic < 7)
                            enemywait();
                        else
                            enemyatack();
                    }
                    else if (enemy.stamina < 70 & enemy.stamina > 40)
                    {
                        Random rand = new Random();
                        int corobic = rand.Next(1, 11);
                        if (corobic < 3)
                            Eobrona();

                        else if (corobic > 3 & corobic < 8)
                            enemyatack();
                        else
                            enemyatack2();

                    }
                    else if (enemy.stamina >= 70)
                    {
                        Random rand = new Random();
                        int corobic = rand.Next(1, 11);
                        if (corobic < 4)
                            Eobrona();

                        else if (corobic > 3 & corobic < 8)
                            enemyatack();
                        else
                            enemyatack2();
                    }
                }
                
            }
            await Task.Delay(1000);
            pictureBox4.Image = null;

            ChangeButtonsState();
            if (!btn_atack2.Enabled)
                ChangeButtonsState();

            if (czyobrona == 1)
            {
                Bohater.def = Bohater.def / 2;
                czyobrona = 0;
            }

            statystyki();
            pictureBox10.Image = null;
            
        }

        public void enemyatack()
        {
            pazury.RunWorkerAsync();
            Random rand = new Random();
            int stun = rand.Next(1, 11);
            if(jakazbroja==0)
            {
                double hit = ((enemy.str) - ((this.Bohater.def)* 0.25));
                Convert.ToInt32(hit);
                if (hit < 0)
                    hit = 0;
                this.Bohater.hp = this.Bohater.hp - hit;
                this.enemy.stamina = this.enemy.stamina - 20;
                label21.Text = "szybki atak  potwora " + enemy.name + " zadal " + Convert.ToString(Convert.ToInt32(hit)) + " obrazen graczowi " + Bohater.name + "\n" + label21.Text;
            }
            else if (jakazbroja == 1)
            {
                double hit = ((enemy.str) - ((this.Bohater.def+20) * 0.25));
                Convert.ToInt32(hit);
                if (hit < 0)
                    hit = 0;
                this.Bohater.hp = this.Bohater.hp - hit;
                this.enemy.stamina = this.enemy.stamina - 20;
                label21.Text = "szybki atak  potwora " + enemy.name + " zadal " + Convert.ToString(Convert.ToInt32(hit)) + " obrazen graczowi " + Bohater.name + "\n" + label21.Text;
            }
            else if (jakazbroja == 2)
            {
                double hit = ((enemy.str) - ((this.Bohater.def+30) * 0.25));
                Convert.ToInt32(hit);
                if (hit < 0)
                    hit = 0;
                this.Bohater.hp = this.Bohater.hp - hit;
                this.enemy.stamina = this.enemy.stamina - 20;
                label21.Text = "szybki atak  potwora " + enemy.name + " zadal " + Convert.ToString(Convert.ToInt32(hit)) + " obrazen graczowi " + Bohater.name + "\n" + label21.Text;
            }
            else if (jakazbroja == 3)
            {
                double hit = ((enemy.str) - ((this.Bohater.def+40) * 0.25));
                Convert.ToInt32(hit);
                if (hit < 0)
                    hit = 0;
                this.Bohater.hp = this.Bohater.hp - hit;
                this.enemy.stamina = this.enemy.stamina - 20;
                label21.Text = "szybki atak  potwora " + enemy.name + " zadal " + Convert.ToString(Convert.ToInt32(hit)) + " obrazen graczowi " + Bohater.name + "\n" + label21.Text;
            }


            pictureBox4.Image = Properties.Resources.pazury;





            statystyki();
            enemystat();

            if (this.Bohater.hp > 0 & stun == 1)
            {
                label21.Text = "Potwor " + enemy.name + " ogluszyl gracza " + Bohater.name + "\n" + label21.Text;
                pictureBox10.Image = Properties.Resources.stun;
                enemyaction();
            }

            else if (Bohater.hp <= 0)
            {
                string message = "Polegles w walce";
                string caption = "Porażka";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;


                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }
            }

                

            
        }
        public void enemyatack2()
        {
            pazury.RunWorkerAsync();
            Random rand = new Random();
            int stun = rand.Next(1, 11);
            if (jakazbroja == 0)
            {

                double hit = ((1.5*enemy.str) - ((this.Bohater.def) * 0.25));
                Convert.ToInt32(hit);
                if (hit < 0)
                    hit = 0;
                this.Bohater.hp = this.Bohater.hp - hit;
                this.enemy.stamina = this.enemy.stamina - 40;
                label21.Text = "silny atak potwora " + enemy.name + " zadal " + Convert.ToString(Convert.ToInt32(hit)) + " obrazen graczowi " + Bohater.name + "\n" + label21.Text;
            }
            else if (jakazbroja == 1)
            {
                double hit = ((1.5 * enemy.str) - ((this.Bohater.def+20) * 0.25));
                Convert.ToInt32(hit);
                if (hit < 0)
                    hit = 0;
                this.Bohater.hp = this.Bohater.hp - hit;
                this.enemy.stamina = this.enemy.stamina - 40;
                label21.Text = "silny atak potwora " + enemy.name + " zadal " + Convert.ToString(Convert.ToInt32(hit)) + " obrazen graczowi " + Bohater.name + "\n" + label21.Text;
            }
            else if (jakazbroja == 2)
            {
                double hit = ((1.5*enemy.str) - ((this.Bohater.def + 30) * 0.25));
                Convert.ToInt32(hit);
                if (hit < 0)
                    hit = 0;
                this.Bohater.hp = this.Bohater.hp - hit;
                this.enemy.stamina = this.enemy.stamina - 24;
                label21.Text = "silny atak potwora " + enemy.name + " zadal " + Convert.ToString(Convert.ToInt32(hit)) + " obrazen graczowi " + Bohater.name + "\n" + label21.Text;
            }
            else if (jakazbroja == 3)
            {
                double hit = ((1.5*enemy.str) - ((this.Bohater.def + 40) * 0.25));
                Convert.ToInt32(hit);
                if (hit < 0)
                    hit = 0;
                this.Bohater.hp = this.Bohater.hp - hit;
                this.enemy.stamina = this.enemy.stamina - 40;
                label21.Text = "silny atak potwora " + enemy.name + " zadal " + Convert.ToString(Convert.ToInt32(hit)) + " obrazen graczowi " + Bohater.name + "\n" + label21.Text;
            }

            pictureBox4.Image = Properties.Resources.pazury;

            statystyki();
            enemystat();
            if (this.Bohater.hp > 0 & stun >= 3)
            {

                statystyki();
            }
            else if (this.Bohater.hp > 0 & stun < 3)
            {
                pictureBox10.Image = Properties.Resources.stun;
                enemystat();
                label21.Text ="Potwor "  + enemy.name + " ogluszyl gracza " +Bohater.name+"\n"+ label21.Text;
                enemyaction();
            }

            else
            {
                string message = "Polegles w walce";
                string caption = "Porażka";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;


                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }
            }


        }
        public void enemywait()
        {
            wait.RunWorkerAsync();
            if (enemy.stamina > (0.6 * enemy.stamina_max))
                enemy.stamina = enemy.stamina_max;
            else
                enemy.stamina = enemy.stamina + (0.4 * enemy.stamina_max);
            label21.Text = enemy.name + " czeka " + "\n" + label21.Text;
            enemystat();
            pictureBox4.Image = Properties.Resources.klepsydra;
        }
        public void Eobrona()
        {
            shield.RunWorkerAsync();

            if (enemyobrona == 0)
            {
                enemy.def = enemy.def * 2;
                enemyobrona = 1;
                enemy.stamina = enemy.stamina - 10;
            }
            else
            {
                enemyobrona = 1;
                enemy.stamina = enemy.stamina - 10;
            }
            enemystat();
            pictureBox4.Image = Properties.Resources.shield;
            label21.Text = enemy.name + " broni sie " + "\n" + label21.Text;





        }


        public void button2_Click(object sender, EventArgs e)
        {

            ChangeButtonsState();

            if (Bohater.GetType().Name == "Lotrzyk")
            {
                if (Bohater.sp >= 10)
                {
                    shield.RunWorkerAsync();
                    if (czyobrona == 0)
                    {
                        this.Bohater.sp = this.Bohater.sp - 10;
                        Bohater.def = Bohater.def * 2;
                        czyobrona = 1;
                        statystyki();
                        enemystat();
                        label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " broni sie " + "\n" + label21.Text;
                        if (enemyobrona == 1)
                        {
                            enemy.def = enemy.def / 2;
                            enemyobrona = 0;
                        }
                        pictureBox4.Image = Properties.Resources.shield;
                        enemyaction();
                    }
                    else
                    {
                        this.Bohater.sp = this.Bohater.sp - 10;
                        czyobrona = 1;
                        statystyki();
                        enemystat();
                        label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " broni sie " + "\n" + label21.Text;
                        if (enemyobrona == 1)
                        {
                            enemy.def = enemy.def / 2;
                            enemyobrona = 0;
                        }
                        pictureBox4.Image = Properties.Resources.shield;
                        enemyaction();
                    }
                }
                else
                {
                    ChangeButtonsState();
                    MessageBox.Show("Masz za malo sp");
                }
                    


            }
            else if (Bohater.GetType().Name == "Mag")
            {
                if (Bohater.mp >= 10)
                {
                    shield.RunWorkerAsync();
                    if (czyobrona==0)
                    {
                        this.Bohater.mp = this.Bohater.mp - 10;
                        Bohater.def = Bohater.def * 2;
                        czyobrona = 1;
                        statystyki();
                        enemystat();
                        label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " broni sie " + "\n" + label21.Text;
                        if (enemyobrona == 1)
                        {
                            enemy.def = enemy.def / 2;
                            enemyobrona = 0;
                        }
                        pictureBox4.Image = Properties.Resources.shield;
                        enemyaction();
                    }
                    else
                    {
                        this.Bohater.mp = this.Bohater.mp - 10;
                        czyobrona = 1;
                        statystyki();
                        enemystat();
                        label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " broni sie " + "\n" + label21.Text;
                        if (enemyobrona == 1)
                        {
                            enemy.def = enemy.def / 2;
                            enemyobrona = 0;
                        }
                        pictureBox4.Image = Properties.Resources.shield;
                        enemyaction();
                    }
                }
                else
                {
                    ChangeButtonsState();
                    MessageBox.Show("Masz za malo mp");
                }

            }
            else
            {
                if (Bohater.rage >= 10)
                {
                    shield.RunWorkerAsync();
                    if (czyobrona==0)
                    {
                        this.Bohater.rage = this.Bohater.rage - 10;
                        Bohater.def = Bohater.def * 2;
                        czyobrona = 1;
                        statystyki();
                        enemystat();
                        label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " broni sie " + "\n" + label21.Text;
                        if (enemyobrona == 1)
                        {
                            enemy.def = enemy.def / 2;
                            enemyobrona = 0;
                        }
                        pictureBox4.Image = Properties.Resources.shield;
                        enemyaction();
                    }
                    else
                    {
                        this.Bohater.rage = this.Bohater.rage - 10;                      
                        czyobrona = 1;
                        statystyki();
                        enemystat();
                        label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " broni sie " + "\n" + label21.Text;
                        if (enemyobrona == 1)
                        {
                            enemy.def = enemy.def / 2;
                            enemyobrona = 0;
                        }
                        pictureBox4.Image = Properties.Resources.shield;
                        enemyaction();
                    }

                }
                else
                {
                    ChangeButtonsState();
                    MessageBox.Show("Masz za malo rage");
                }

            }





        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeButtonsState();
            wait.RunWorkerAsync();
            if (Bohater.GetType().Name == "Lotrzyk")
            {
                if (Bohater.sp > (0.6 * Bohater.sp_max))
                    Bohater.sp = Bohater.sp_max;
                else
                    Bohater.sp = Bohater.sp + (0.4 * Bohater.sp_max);
                label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " czeka " + "\n" + label21.Text;
            }
            else if (Bohater.GetType().Name == "Mag")
            {
                if (Bohater.mp > (0.6 * Bohater.mp_max))
                    Bohater.mp = Bohater.mp_max;
                else
                    Bohater.mp = Bohater.mp + (0.4 * Bohater.mp_max);
                label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " czeka " + "\n" + label21.Text;
            }
            else
            {
                if (Bohater.rage > (0.6 * Bohater.rage_max))
                    Bohater.rage = Bohater.rage_max;
                else
                    Bohater.rage = Bohater.rage + (0.4 * Bohater.rage_max);
                label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " czeka " + "\n" + label21.Text;
            }


            statystyki();
            if (enemyobrona == 1)
            {
                enemy.def = enemy.def / 2;
                enemyobrona = 0;
            }
            enemystat();
            pictureBox4.Image = Properties.Resources.klepsydra;

            enemyaction();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        
        

        public void jakiekwipunek()
        {
            if(jakazbroja==0)
            {
                pictureBox6.Image = Properties.Resources.koszula;
            }
            else if (jakazbroja == 1)
            {
                pictureBox6.Image = Properties.Resources.armor1;
                label32.Text = "20";
            }
            else if (jakazbroja == 2)
            {
                pictureBox6.Image = Properties.Resources.armor2;
                label32.Text = "30";
            }
            else if (jakazbroja == 3)
            {
                pictureBox6.Image = Properties.Resources.armor3;
                label32.Text = "40";
            }
            if (Bohater.GetType().Name == "Lotrzyk")
            {
                if (jakabron == 0)
                {
                    pictureBox8.Image = Properties.Resources.kij;
                }
                else if (jakabron == 1)
                {
                    pictureBox8.Image = Properties.Resources.sztylet1;
                    label31.Text = "20";
                }
                else if (jakabron == 2)
                {
                    pictureBox8.Image = Properties.Resources.sztylet2;
                    label31.Text = "30";
                }
                else if (jakabron == 3)
                {
                    pictureBox8.Image = Properties.Resources.sztylet3;
                    label31.Text = "40";
                }

            }
            else if (Bohater.GetType().Name == "Mag")
            {
                if (jakabron == 0)
                {
                    pictureBox8.Image = Properties.Resources.kij;
                }
                else if (jakabron == 1)
                {
                    pictureBox8.Image = Properties.Resources.laska1;
                    label31.Text = "20";
                }
                else if (jakabron == 2)
                {
                    pictureBox8.Image = Properties.Resources.laska2;
                    label31.Text = "30";
                }
                else if (jakabron == 3)
                {
                    pictureBox8.Image = Properties.Resources.laska3;
                    label31.Text = "40";
                }

            }
            else
            {
                if (jakabron == 0)
                {
                    pictureBox8.Image = Properties.Resources.kij;
                }
                else if (jakabron == 1)
                {
                    pictureBox8.Image = Properties.Resources.miecz1;
                    label31.Text = "20";
                }
                else if (jakabron == 2)
                {
                    pictureBox8.Image = Properties.Resources.miecz2;
                    label31.Text = "30";
                }
                else if (jakabron == 3)
                {
                    pictureBox8.Image = Properties.Resources.miecz3;
                    label31.Text = "40";
                }

            }
        }


        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void fireball_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer fireball = new SoundPlayer(GRARPG.Properties.Resources.Fireball);
            fireball.Play();
        }

        private void magatack_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer magatack = new SoundPlayer(GRARPG.Properties.Resources.magic_blast);
            magatack.Play();
        }

        private void shield_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer shield = new SoundPlayer(GRARPG.Properties.Resources.shield1);
            shield.Play();
        }

        private void wait_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer wait = new SoundPlayer(GRARPG.Properties.Resources.wait);
            wait.Play();
        }

        private void specialatack_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer specialatack = new SoundPlayer(GRARPG.Properties.Resources.rzut);
            specialatack.Play();

        }

        private void atack_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer atack = new SoundPlayer(GRARPG.Properties.Resources.sword_atack);
            atack.Play();
        }

        private void pazury_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer pazury = new SoundPlayer(GRARPG.Properties.Resources.pazury1);
            pazury.Play();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Bohater.gold = Bohater.gold + 5000;//cheat na golda do testów(trzeba kliknac slowo gold w statystykach)
            statystyki();
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (hppotion > 0)
            {
                Bohater.hp = Bohater.hp_max;
                label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " uzyl mikstury zycia " + "\n" + label21.Text;
                hppotion = hppotion - 1;
                if (enemyobrona == 1)
                {
                    enemy.def = enemy.def / 2;
                    enemyobrona = 0;
                }
                statystyki();
                enemyaction();
            }
            else
                MessageBox.Show("Nie masz juz mikstur zycia");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (Bohater.GetType().Name == "Lotrzyk")
            {
                if (specialpotion > 0)
                {
                    Bohater.sp = Bohater.sp_max;
                    label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " uzyl mikstury wytrzymalosci " + "\n" + label21.Text;
                    specialpotion = specialpotion - 1;
                    if (enemyobrona == 1)
                    {
                        enemy.def = enemy.def / 2;
                        enemyobrona = 0;
                    }
                    statystyki();
                    enemyaction();
                }
                else
                    MessageBox.Show("Nie masz juz mikstur wytrzymalosci");
            }
            else if (Bohater.GetType().Name == "Mag")
            {
                if (specialpotion > 0)
                {
                    Bohater.mp = Bohater.mp_max;
                    label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " uzyl mikstury many " + "\n" + label21.Text;
                    specialpotion = specialpotion - 1;
                    if (enemyobrona == 1)
                    {
                        enemy.def = enemy.def / 2;
                        enemyobrona = 0;
                    }
                    statystyki();
                    enemyaction();
                }
                else
                    MessageBox.Show("Nie masz juz mikstur many");
            }
            else
            {
                if (specialpotion > 0)
                {
                    Bohater.rage = Bohater.rage_max;
                    label21.Text = Convert.ToString(Bohater.GetType().Name) + " " + Bohater.name + " uzyl mikstury wscieklosci " + "\n" + label21.Text;
                    specialpotion = specialpotion - 1;
                    if (enemyobrona == 1)
                    {
                        enemy.def = enemy.def / 2;
                        enemyobrona = 0;
                    }
                    statystyki();
                    enemyaction();
                    
                }
                else
                    MessageBox.Show("Nie masz juz mikstur wscieklosci");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_atack2_Click(object sender, EventArgs e)
        {
            ChangeButtonsState();
            if (Bohater.GetType().Name == "Lotrzyk")
            {
                if (Bohater.sp >= 40)
                    cios2();
                else
                {
                    ChangeButtonsState();
                    MessageBox.Show("Masz za malo sp");
                }
            }
            else if (Bohater.GetType().Name == "Mag")
            {
                if (Bohater.mp >= 40)
                    cios2();
                else
                {
                    ChangeButtonsState();
                    MessageBox.Show("Masz za malo mp");
                }
            }
            else
            {
                if (Bohater.rage >= 40)
                    cios2();
                else
                {
                    ChangeButtonsState();
                    MessageBox.Show("Masz za malo rage");
                }
            }
        }

        void ciosanim()
        {
            
            
            
              
            if (Bohater.GetType().Name == "Lotrzyk")
            {
                if (jakabron == 0)
                    pictureBox4.Image = Properties.Resources.kij;
                else if(jakabron==1)
                    pictureBox4.Image = Properties.Resources.sztylet1;
                else if(jakabron==2)
                    pictureBox4.Image = Properties.Resources.sztylet2;
                else if(jakabron==3)
                    pictureBox4.Image = Properties.Resources.sztylet3;

            }
            else if (Bohater.GetType().Name == "Mag")
            {
                if (jakabron == 0)
                    pictureBox4.Image = Properties.Resources.kij;
                else if (jakabron == 1)
                    pictureBox4.Image = Properties.Resources.laska1;
                else if (jakabron == 2)
                    pictureBox4.Image = Properties.Resources.laska2;
                else if (jakabron == 3)
                    pictureBox4.Image = Properties.Resources.laska3;

            }
            else
            {
                if (jakabron == 0)
                    pictureBox4.Image = Properties.Resources.kij;
                else if (jakabron == 1)
                    pictureBox4.Image = Properties.Resources.miecz1;
                else if (jakabron == 2)
                    pictureBox4.Image = Properties.Resources.miecz2;
                else if (jakabron == 3)
                    pictureBox4.Image = Properties.Resources.miecz3;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeButtonsState();
            if (Bohater.GetType().Name == "Lotrzyk")
            {
                if (Bohater.sp >= 20)
                    cios();
                else
                {
                    ChangeButtonsState();
                    MessageBox.Show("Masz za malo sp");
                }
            }
            else if (Bohater.GetType().Name == "Mag")
            {
                if (Bohater.mp >= 20)
                    cios();
                else
                {
                    ChangeButtonsState();
                    MessageBox.Show("Masz za malo mp");
                }
            }
            else
            {
                if (Bohater.rage >= 20)
                    cios();
                else
                {
                    ChangeButtonsState();
                    MessageBox.Show("Masz za malo rage");
                }
            }

        }




    }
}
