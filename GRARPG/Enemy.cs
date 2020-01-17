using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRARPG
{
    public class Enemy
    {
        public string name;
        public double hp;
        public double hp_max;
        public double str;
        public double stamina;
        public double stamina_max;
        public double def;
        public double gold;
        public double exp;
        public Enemy(string name,double hp, double stamina, double str, double def, double gold, double exp)
        {
            this.name = name;
            this.hp = hp;
            this.hp_max = hp;
            this.stamina = stamina;
            this.stamina_max = stamina;
            this.str = str;
            this.def = def;
            this.gold = gold;
            this.exp = exp;
        }
        public static Enemy NewEnemy(string name, double hp, double stamina, double str, double def, double gold, double exp)
        {
            return new Enemy(name, hp, stamina, str, def, gold, exp);
        }

    }
}
            