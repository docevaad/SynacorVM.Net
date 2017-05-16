using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class JumpOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var address = context.PC.GetNextMemoryValue(context.Memory);
            if (address.ValidRegister())
                address = context.Registers.GetRegister(address);

            context.PC.SetInstructionPointer(address);
        }
    }
}
