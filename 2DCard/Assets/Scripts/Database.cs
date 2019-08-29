using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Database : MonoSingleton<Database>
{
    private int score = 0;

    public int Score {

        get => score;

        set {
            score += value;
        }
    } 
}


