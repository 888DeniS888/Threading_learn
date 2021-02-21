using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_learn
{
    class LR7 : ILRs
    {
        public static Random rnd;
        List<Matrix> matrices;
        public LR7()
        {
            rnd = new Random();
            matrices = new List<Matrix>();  
        }
        /*
         Метод находит разницу максимального и минимального элементов 
        матрицы целых случайных чисел
        Класс описывает
        матрицу случайных чисел 
        (размер матрицы выбираетсяслучайным образом)
         */
        public void DoAction()
        {
    
            int numElem = 1000;
            for (int i = 0; i < numElem; i++)
            {
                matrices.Add(new Matrix(rnd.Next(5, 20), rnd.Next(5, 20)));
            }
         
            Thread.Sleep(2000);
        }

        
    }

    class Matrix
    {
        Random rnd;
        int columns;
        int rows;
        int[,] matrix;
        public Matrix(int rows, int columns) 
        {
            rnd = new Random();
            this.rows = rows;
            this.columns = columns;
            InitMatrix();
            ThreadPool.QueueUserWorkItem(CalcMaxMin, new object());
        }
        public override string ToString()
        {
            string str = "";
            for ( int i = 0; i < columns; i++)
            {
                for ( int j = 0; j < rows; j++)
                {
                    str += matrix[i, j].ToString() + " ";
                }
                str += "\n";
            }
            return str;
        }
        protected void CalcMaxMin(object obj)
        {
            int max_ = 0,
                min_ = 101;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[i, j] > max_) max_ = matrix[i, j];
                    if (matrix[i, j] < min_) min_ = matrix[i, j];
                }
            }
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} - Answer {max_ - min_}");
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
