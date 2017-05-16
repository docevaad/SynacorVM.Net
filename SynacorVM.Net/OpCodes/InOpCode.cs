using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class InOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var destination = context.PC.GetNextMemoryValue(context.Memory);
            // Hack to get around Windows having a carriage return. Might just import libc::getchar()
            var inputChar = Console.ReadKey().KeyChar;
            if ((ushort)inputChar == 13)
                inputChar = (char)10;
            context.Registers.SetRegister(destination, (ushort)inputChar);
        }
    }
}
