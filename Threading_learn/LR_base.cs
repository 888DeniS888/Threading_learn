using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading_learn
{
    class LR_base: ILRs
    {
        protected Action<string> log; 
        protected Random rand;
        protected LR_base()
        {
            log = Logger.Log;
            rand = new Random();
        }
       public virtual void DoAction()
        {
        }
    }
}
