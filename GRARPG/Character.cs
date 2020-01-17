using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRARPG
{

    abstract class Hero 
    {
        public double hp
        { get; set; }       
        public double hp_max
        { get; set; }
        public double def
        { get; set; }
        
        public double lvl
        { get; set; }
        public double exp
        { get; set; }
        public double lvl_next
        { get; set; }
        public double gold
        { get; set; }
        public string name
        { get; set; }


    }
    class Mag:Hero
    {
        public double Int
        { get; set; }
        public double mp
        { get; set; }
        public double mp_max
        { get; set; }

        public Mag(double Int, double hp, double hp_max, double def, double lvl, double exp, double lvl_next, double gold, string name, double mp, double mp_max)
        {
            this.Int = Int;
            this.hp = hp;
            this.hp_max = hp_max;
            this.def = def;
            this.lvl = lvl;
            this.lvl_next = lvl_next;
            this.exp = exp;
            this.gold = gold;
            this.name = name;
            this.mp = mp;
            this.mp_max = mp_max;

        }
        public static Mag lvlup(double lvl, double lvl_next, double gold, double exp, string name, double newhp, double neweng, double newdps, double newdef)
        {
            double lvlnew = lvl + 1;
            double lvl_nextnew = lvl_next * 2;
            return new Mag(newdps, newhp, newhp, newdef, lvlnew, exp, lvl_nextnew, gold, name, neweng, neweng);
        }

    }
    class Wojownik:Hero
    {
        public double str
        { get; set; }
        public double rage
        { get; set; }
        public double rage_max
        { get; set; }
        public Wojownik(double str, double hp, double hp_max, double def, double lvl, double exp, double lvl_next, double gold, string name, double rage, double rage_max)
        {
            this.str = str;
            this.hp = hp;
            this.hp_max = hp_max;
            this.def = def;
            this.lvl = lvl;
            this.lvl_next = lvl_next;
            this.exp = exp;
            this.gold = gold;
            this.name = name;
            this.rage = rage;
            this.rage_max = rage_max;

        }
        public static Wojownik lvlup(double lvl, double lvl_next, double gold, double exp, string name, double newhp, double neweng, double newdps, double newdef)
        {
            double lvlnew = lvl+1;
            double lvl_nextnew = lvl_next * 2;
            return new Wojownik(newdps, newhp, newhp, newdef, lvlnew, exp, lvl_nextnew, gold, name, neweng, neweng);
        }
    }
    class Lotrzyk:Hero
    {
        public double dex
        { get; set; }
        public double sp
        { get; set; }
        public double sp_max
        { get; set; }
        public Lotrzyk(double dex, double hp, double hp_max, double def, double lvl, double exp, double lvl_next, double gold, string name, double sp, double sp_max)
        {
            this.dex = dex;
            this.hp = hp;
            this.hp_max = hp_max;
            this.def = def;
            this.lvl = lvl;
            this.lvl_next = lvl_next;
            this.exp = exp;
            this.gold = gold;
            this.name = name;
            this.sp = sp;
            this.sp_max = sp_max;

        }
        public static Lotrzyk lvlup(double lvl, double lvl_next, double gold, double exp, string name, double newhp, double neweng, double newdps, double newdef)
        {
            double lvlnew = lvl + 1;
            double lvl_nextnew = lvl_next * 2;
            return new Lotrzyk(newdps, newhp, newhp, newdef, lvlnew, exp, lvl_nextnew, gold, name, neweng, neweng);
        }

    }
        
}
