using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading_learn
{
    /*
     Метод находит количество вхождений заданного символа в строке
    Два параметра: строка и целевой символ
     */
    class LR6 : ILRs
    {
        string str;
        char sep;
        public LR6(string str, char sep)
        {
            this.str = str;
            this.sep = sep;
        }
        public void DoAction()
        {
            Console.WriteLine(str.Split(sep).Length - 1);

        }
    }
}
