using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class NotOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var destination = context.PC.GetNextMemoryValue(context.Memory);
            var value = context.PC.GetNextMemoryValue(context.Memory);
            if (value.ValidRegister())
                value = context.Registers.GetRegister(value);
            var result = ~value & 0x7FFF;
            context.Registers.SetRegister(destination, (ushort)result);
        }
    }
}
