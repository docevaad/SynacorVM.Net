using System;

namespace SynacorVM.Net.OpCodes
{
    public class OutOpCode : IOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            ushort outputChar;
            var memoryValue = context.PC.GetNextMemoryValue(context.Memory);

            if (memoryValue.ValidRegister())
                outputChar = context.Registers.GetRegister(memoryValue);
            else
                outputChar = memoryValue;

            Console.Write($"{(char)outputChar}");
        }
    }
}
