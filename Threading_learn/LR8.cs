using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_learn
{
    class LR8 : ILRs
    {
            /*
            Метод преобразования матрицы случайных чисел: четные
            элементы заменяются суммой косинуса и синуса
            соответствующего элемента матрицы.
            */
        Random rnd;
        int columns;
        int rows;
        double[,] matrix;
        public LR8()
        {
            rnd = new Random();
            rows = 10;
            columns = 15;
            InitMatrix();
        }


        public void DoAction()
        {
            Console.WriteLine( this.ToString());
            Console.WriteLine();
            Task.WaitAll(Task.Run(new Action(Calc)));
            Console.WriteLine( this.ToString());
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
        protected void Calc()
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[i, j] % 2 == 0) matrix[i, j] = Math.Round(Math.Sin(matrix[i,j]) + Math.Cos(matrix[i,j]), 3);
                }
            }
        }

        protected void InitMatrix()
        {
            matrix = new double[columns, rows];
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
