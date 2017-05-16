using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class EqualOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var dest = context.PC.GetNextMemoryValue(context.Memory);

            var left = context.PC.GetNextMemoryValue(context.Memory);
            if (left.ValidRegister())
                left = context.Registers.GetRegister(left);

            var right = context.PC.GetNextMemoryValue(context.Memory);
            if (right.ValidRegister())
                right = context.Registers.GetRegister(right);

            ushort result = 0;
            if (left == right)
                result = 1;

            if (dest.ValidRegister())
                context.Registers.SetRegister(dest, result);
            else
                context.Memory.StoreMemoryAddress(dest, result);
        }
    }
}
