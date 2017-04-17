using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class CallOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var addressToJumpTo = context.PC.GetNextMemoryValue(context.Memory);
            context.Stack.Push(context.PC.GetInstructionPointer());
            context.PC.SetInstructionPointer(addressToJumpTo);
        }
    }
}
