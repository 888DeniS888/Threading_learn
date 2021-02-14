using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading_learn
{
    class LR1 :LR_base, ILRs
    {
        Func<Action<string>, float, float> func;
        
        public LR1()
        {
            func = (Action<string> action, float y) => { action(y.ToString() + "  "); return y * 10; };            
        }

        public new void DoAction()
        {
            float first = 3.2f;
            float second = 5.1f;
            float third = -7.5f;
            log(func((Action<string>)log, first).ToString() + Environment.NewLine);
            log(func((Action<string>)log, second).ToString() + Environment.NewLine);
            log(func((Action<string>)log, third).ToString() + Environment.NewLine);
        }

        
    }
}
