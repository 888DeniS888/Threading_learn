using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_learn
{
    class LR3 : LR2, ILRs
    {
        /*
        Метод возвращает среднее
        арифметическое элементов матрицы
        случайных чисел.
        */
        public LR3(int rows, int columns):base(rows, columns)
        {
        }
        public new void DoAction()
        {
            IAsyncResult asyncResult = calc.BeginInvoke(null, null);
            PrintMatrix();

            while (true)
            {
                log(".");
                if (asyncResult.AsyncWaitHandle.WaitOne(50, false))
                {
                    log(Environment.NewLine + "Get result now" + Environment.NewLine);
                    break;
                }
            }
            log("Summ elements -- " + calc.EndInvoke(asyncResult) + Environment.NewLine);
        }
    }
}
