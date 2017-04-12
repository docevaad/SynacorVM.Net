using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class NoOpOpCode : IOpCode
    {
        public void dispatchOpCode(SynacorVM vm)
        {
        }
    }
}
