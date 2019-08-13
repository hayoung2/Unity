using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Monster
{
    public string name;
    public int hp;
    public int attack;
    public int maxhp;
   

    public Monster(string name, int hp , int attack)
    {
        this.name = name;
        this.hp = hp;
        this.attack = attack;
        this.maxhp = hp;
    }

    public bool Heal()
    {
        hp = maxhp;
        return false;
    }
    
    public bool Attack(int atk)
    {
        this.hp -= atk;
        return false;
    }
   

}
