using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        List<Monster> theMob = new List<Monster>();
        Random rnd = new Random();
        bool isPrev = false;
        bool isNext = false;
        string input="start";
        int num = rnd.Next(2, 10); 

        Console.WriteLine("\t선수 소개합니다 !");

        for(int i=0; i < (num % 2 == 0 ? num : num+1); i++)
        {
            theMob.Add(new Monster((i+1).ToString(), rnd.Next(1, 20), rnd.Next(1, 5)));
            Console.WriteLine("Name : ",theMob[i].name," HP :", theMob[i].hp," Attack : ", theMob[i].attack);

            if (i == num)
                num += 1;
        }

        while (input.Equals("Exit"))
        {
            for (int i = 0; ; i++) {

                Console.WriteLine(" 첫번째 상대를 골라주세요 ");
                string player1 = Console.ReadLine();
                Console.WriteLine(" 두번째 상대를 골라주세요 ");
                string player2 = Console.ReadLine();

                while(isPrev || isNext)
                {
                    if (isPrev)
                    {

                    }
                }

            }
            
        }
        



        


        


    }
}

