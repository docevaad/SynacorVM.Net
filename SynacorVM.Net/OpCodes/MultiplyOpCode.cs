using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class MultiplyOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var destination = context.PC.GetNextMemoryValue(context.Memory);
            var left = context.PC.GetNextMemoryValue(context.Memory);
            var right = context.PC.GetNextMemoryValue(context.Memory);
            var result = (left * right) & 0x7FFF; // optimization for mod 32768
            context.Registers.SetRegister(destination, (ushort)result);
        }
    }
}
