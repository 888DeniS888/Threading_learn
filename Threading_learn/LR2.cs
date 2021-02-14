using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_learn
{
   
    class LR2 : LR_base, ILRs
    {
        /*
        Метод возвращает среднее
        арифметическое элементов матрицы
        случайных чисел.
        */
        protected Func<int> calc;
        protected int[,] matrix;
        protected int columns , rows;       
        /// <summary>
        /// Create matrix
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public LR2(int rows, int columns) 
        {
            calc = CalcSum;
            this.columns = columns;
            this.rows = rows;
            InitMatrix();
        }/// <summary>
        /// Print matrix and sum of elements
        /// </summary>
        public new void DoAction()
        {
            IAsyncResult asyncResult = calc.BeginInvoke(null, null);
            PrintMatrix();
            while (!asyncResult.IsCompleted)
            {
                Thread.Sleep(50);
                log(".");
            }
            log("Summ elements -- "+ calc.EndInvoke(asyncResult) + Environment.NewLine);
        }
        protected void InitMatrix()
        {
            matrix = new int[columns, rows];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[i, j] = rand.Next(0, 10);
                }
            }
        }
        public int[,] GetMatrix()
        {
            return matrix;
        }
        protected void PrintMatrix()
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    log(matrix[i, j].ToString() + " ");
                }
                log(Environment.NewLine);
            }
        }
        protected int CalcSum()
        {
            int temp = 0;
            for (int i = 0; i < columns; i++)
                for (int j = 0; j < rows; j++)
                    temp += matrix[i, j];
            return temp;
        }
    }
}
