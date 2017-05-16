using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class PopOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var destination = context.PC.GetNextMemoryValue(context.Memory);
            var value = context.Stack.Pop();

            if (destination.ValidRegister())
                context.Registers.SetRegister(destination, value);
            else
                context.Memory.StoreMemoryAddress(destination, value);
        }
    }
}
