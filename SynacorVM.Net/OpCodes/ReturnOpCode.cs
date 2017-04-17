using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class ReturnOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var returnAddress = context.Stack.Pop();
            context.PC.SetInstructionPointer(returnAddress);
        }
    }
}
