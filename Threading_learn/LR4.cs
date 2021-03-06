﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_learn
{
    class LR4 : LR2, ILRs
    {
        Func<int> someFunc;
        public LR4(int rows, int columns):base(rows, columns)
        {
            someFunc = CalcMaxMin;
        }
        public new void DoAction()
        {
            PrintMatrix();
           someFunc.BeginInvoke(ar => 
            {
                log(someFunc.EndInvoke(ar).ToString());
            }, null);
            log(Environment.NewLine);
            Thread.Sleep(500); // Без паузы фунция завершается до окончания вычислений
        }

        /*
        Метод возвращает разницу
        максимального и
        минимального элементов
        матрицы целых случайных
        чисел
        */
        public int CalcMaxMin()
        {
            int max_ = 0,
                min_ = 101;
            for (int i = 0; i < columns; i++)
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[i, j] > max_) max_ = matrix[i, j];
                    if (matrix[i, j] < min_) min_ = matrix[i, j];
                }
            return max_ - min_;
        }
    }
}
