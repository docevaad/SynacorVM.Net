using System;

namespace SynacorVM.Net.OpCodes
{
    public class OutOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var outputChar = context.PC.GetNextMemoryValue(context.Memory)
                                .UnwrapPotentialRegister(context.Registers);
            Console.Write($"{(char)outputChar}");
        }
    }
}
