using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.HelpClasses
{
    public class SkipTakeParameters
    {
        const int takeMaxSize = 100;
        private int TakeSize = 10;
        public int take
        {
            get
            {
                return TakeSize;
            }
            set
            {
                TakeSize= (value > takeMaxSize || value < 1 ) ? takeMaxSize : value;
            } 
        }

        //private SkipSize = 0
        public int skip { get; set; } //kanske vill göra samma sak som över. fast att den ska vara = 0
    }
}
