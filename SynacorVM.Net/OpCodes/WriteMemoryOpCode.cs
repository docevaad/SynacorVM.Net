using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class WriteMemoryOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var destinationAddress = context.PC.GetNextMemoryValue(context.Memory);
            var sourceRegister = context.PC.GetNextMemoryValue(context.Memory);
            var value = context.Registers.GetRegister(sourceRegister);
            context.Memory.StoreMemoryAddress(destinationAddress, value);
        }
    }
}
