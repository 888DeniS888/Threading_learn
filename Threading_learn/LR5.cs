using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_learn
{
    class LR5 : ILRs
    {
        int thradId;
        int[] mas;
        Random rnd;
        public LR5()
        {

        }
        
        public void DoAction()
        {
            int N = 10;
            int threadNum = 20;
            rnd = new Random();
            Thread[] threadMas = new Thread[threadNum];

            for (int i = 0; i < threadNum; i++)
            {
                threadMas[i] = new Thread(() =>
                {
                    thradId = Thread.CurrentThread.ManagedThreadId;
                    InitMAss(N);
                    Console.WriteLine($"Thread {thradId}. Answer: {Calc()}");
                });
                threadMas[i].Start();
            }

            for (int i = 0; i < threadNum; i++)
            {
                threadMas[i].Join();
            }
            for (int i = 0; i < threadNum; i++)
            {
                threadMas[i].Abort();
            }


            }
         private void InitMAss(int N)
        {
            Console.WriteLine($"Thread {thradId}. Massive creation...");
            mas = new int[N];
            for (int i = 0; i < N; i++)
            {
                mas[i] = rnd.Next(1000);
            }
        }
        /*Метод подсчета количества чисел, кратных 3, в массиве случайных чисел.*/

        private int Calc() 
        {
            Console.WriteLine($"Thread {thradId}. Searching count |3 elements");
            int counter = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 3 == 0)
                    counter++;
            }
            return counter;
        }

    }
}
