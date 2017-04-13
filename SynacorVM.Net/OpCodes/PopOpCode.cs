using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class PopOpCode : IOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var address = context.PC.GetNextMemoryValue(context.Memory);
            var value = context.Stack.Pop();
            context.Memory.StoreMemoryAddress(address, value);
        }
    }
}
