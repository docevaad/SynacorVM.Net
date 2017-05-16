using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class PushOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var value = context.PC.GetNextMemoryValue(context.Memory).UnwrapPotentialRegister(context.Registers);
            context.Stack.Push(value);
        }
    }
}
