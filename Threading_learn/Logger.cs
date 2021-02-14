using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading_learn
{
    static class Logger
    {
        public static void Log(object s)
        {
            Console.Write(s.ToString());
        }
    }
}
