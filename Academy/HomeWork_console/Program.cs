using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        static List<Monster> theMob = new List<Monster>();
        static Random rnd = new Random(); //rnd 
        static bool start = true;
        static string input = "start";
        static int num = rnd.Next(2, 10);
        static bool result = false;

        static void Main(string[] args)
        {


            Console.WriteLine("\t선수 소개합니다 !");

            for (int i = 0; i < (num % 2 == 0 ? num : num + 1); i++)
            {
                theMob.Add(new Monster((i + 1).ToString(), rnd.Next(1, 20), rnd.Next(1, 5)));
                Console.WriteLine("Name : {0} \t HP : {1} \t Attack : {2}", theMob[i].name, theMob[i].hp, theMob[i].attack);

                if (i == num)
                    num += 1;
            }

            while (!input.Equals("Exit"))
            {

                for (int i = 0; i < theMob.Count / 2; i++)
                {

                    Console.WriteLine(" 첫번째 상대를 골라주세요 ");
                    string player1 = Console.ReadLine();
                    while (theMob[int.Parse(player1) - 1].check)
                    {
                        Console.WriteLine("그 선수는 이미.. ㅠㅠ 다시 골라 주세요!");
                        Console.WriteLine(" 첫번째 상대를 골라주세요 ");
                        player1 = Console.ReadLine();

                    }
                    Console.WriteLine(" 두번째 상대를 골라주세요 ");

                    string player2 = Console.ReadLine();
                    while (theMob[int.Parse(player1) - 1].check)
                    {
                        Console.WriteLine("그 선수는 이미.. ㅠㅠ 다시 골라 주세요!");
                        Console.WriteLine(" 두번째 상대를 골라주세요 ");
                        player2 = Console.ReadLine();

                    }

                    Console.Clear();

                    while (!theMob[int.Parse(player1) - 1].check && !theMob[int.Parse(player2) - 1].check || start)
                    {

                        if (theMob[int.Parse(player1) - 1].check && theMob[int.Parse(player2) - 1].check)
                        {
                            Console.WriteLine("둘 다 죽음");

                            break;

                        }
                        else if (theMob[int.Parse(player1) - 1].check)
                        {
                            Console.WriteLine("'{0}' 승리 ", player2);
                            theMob[int.Parse(player2) - 1].Heal();


                            break;

                        }
                        else if (theMob[int.Parse(player2) - 1].check)
                        {
                            Console.WriteLine("'{0}' 승리 ", player1);
                            theMob[int.Parse(player1) - 1].Heal();


                            break;

                        }

                        Console.WriteLine("{0} 선수 : {1} 공격\t남은 HP : {2} ", player1, theMob[int.Parse(player2) - 1].name, theMob[int.Parse(player1) - 1].hp);
                        theMob[int.Parse(player1) - 1].Attack(theMob[int.Parse(player2) - 1].attack);
                        Console.WriteLine("{0} 선수 : {1} 공격\t남은 HP : {2} ", player2, theMob[int.Parse(player1) - 1].name, theMob[int.Parse(player2) - 1].hp);
                        theMob[int.Parse(player2) - 1].Attack(theMob[int.Parse(player1) - 1].attack);
                        Thread.Sleep(3000);
                        Console.Clear();




                    }

                    Introduce();
                    input = Console.ReadLine();
                    if (result)
                        break;
                }

            }










        }

        public static void Introduce()
        {
            for (int i = 0; i < theMob.Count; i++)
            {
                if (theMob[i].check == false)
                    Console.WriteLine("Name : {0} \t HP : {1} \t Attack : {2}", theMob[i].name, theMob[i].hp, theMob[i].attack);
            }
            if (theMob.Count <= 1)
                result = true;

        }
    }
}