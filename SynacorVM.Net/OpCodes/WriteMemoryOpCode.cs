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
            if (destinationAddress.ValidRegister())
                destinationAddress = context.Registers.GetRegister(destinationAddress);

            var value = context.PC.GetNextMemoryValue(context.Memory);
            if(value.ValidRegister())
                value = context.Registers.GetRegister(value);

            context.Memory.StoreMemoryAddress(destinationAddress, value);
        }
    }
}
