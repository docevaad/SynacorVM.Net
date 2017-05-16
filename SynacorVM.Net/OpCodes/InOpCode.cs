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
            var inputChar = Console.ReadKey().KeyChar;
            if ((ushort)inputChar == 13)
                inputChar = (char)10;
            System.Diagnostics.Debug.WriteLine($"char: {inputChar} {(ushort)inputChar}");
            context.Registers.SetRegister(destination, (ushort)inputChar);
        }
    }
}
