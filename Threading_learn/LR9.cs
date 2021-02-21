using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_learn
{
    /*
     Генерация массива случайных
    чисел (размер определяется
    случайным образом)
    3 задачи: расчет суммы кубов
    нечетных элементов; поиск
    максимального элемента; поиск
    минимального элемента.
    */
    class LR9 : ILRs
    {

        Random rnd;
        int columns;
        int rows;
        int[,] matrix;
        public LR9()
        {
            rnd = new Random();
            rows = rnd.Next(5, 20);
            columns = rnd.Next(5, 20);
            InitMatrix();
        }


        public void DoAction()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine();
            Task t_1 = new Task(Task_1);
            Task t_2 = t_1.ContinueWith(base_task => { Task_2(); });
            Task t_3 = t_2.ContinueWith(base_task => { Task_3(); });
            t_1.Start();
            Task.WaitAll(t_1, t_2, t_3);

                        
        }


        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    str += matrix[i, j].ToString() + " ";
                }
                str += "\n";
            }
            return str;
        }
        protected void Task_1()
        {
            int summ = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[i, j] % 2 != 0) summ += matrix[i, j] * matrix[i, j] * matrix[i, j];
                }
            }
            Console.WriteLine($"Task_1 -- {summ}");
        }

        protected void Task_2()
        {
            int max = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[i, j] > max) max = matrix[i, j];
                }
            }
            Console.WriteLine($"Task_2 -- {max}");
        }

        protected void Task_3()
        {
            int min = 101;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[i, j] < min) min = matrix[i, j];
                }
            }
            Console.WriteLine($"Task_3 -- {min}");
        }




        protected void InitMatrix()
        {
            matrix = new int[columns, rows];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[i, j] = rnd.Next(0, 100);
                }
            }
        }



    }

}
