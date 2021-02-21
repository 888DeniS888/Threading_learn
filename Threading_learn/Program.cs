using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;



namespace Threading_learn
{
    static class Program
    {
        static void Main()
        {
            try
            {
                ILRs lr;
                int numTask = 0;

                while (true)
                {
                    Console.Write("Input number of task -- ");
                    numTask = Convert.ToInt32(Console.ReadLine());
                    lr = Menu(numTask);
                    lr.DoAction();
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error! Wrong value!");
            }
            Console.ReadKey();

        }
        static private ILRs Menu(int num)
        {
            switch (num)
            {
                case 1: return new LR1(); break;
                case 2: return new LR2( 5 , 6); break;
                case 3: return new LR3( 5 , 6); break;
                case 4: return new LR4( 5 , 6); break;
                case 5: return new LR5(); break;
                case 6: return new LR6("so1me1 1 str1ng1", '1'); break;
                case 7: return new LR7(); break;
                case 8: return new LR8(); break;
                case 9: return new LR9(); break;
                default: return null;
            }
        }
    }
}
