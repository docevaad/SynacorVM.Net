using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class JfOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var value = context.PC.GetNextMemoryValue(context.Memory);
            if (value.ValidRegister())
                value = context.Registers.GetRegister(value);

            var address = context.PC.GetNextMemoryValue(context.Memory);
            if (value == 0)
                context.PC.SetInstructionPointer(address);
        }
    }
}
