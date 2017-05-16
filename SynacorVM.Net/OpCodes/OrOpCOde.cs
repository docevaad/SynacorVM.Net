using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class OrOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var destination = context.PC.GetNextMemoryValue(context.Memory);
            var left = context.PC.GetNextMemoryValue(context.Memory).UnwrapPotentialRegister(context.Registers);
            var right = context.PC.GetNextMemoryValue(context.Memory).UnwrapPotentialRegister(context.Registers);
            var result = left | right;
            context.Registers.SetRegister(destination, (ushort)result);
        }
    }
}
