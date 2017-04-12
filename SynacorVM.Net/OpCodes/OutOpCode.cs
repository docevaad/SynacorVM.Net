using System;
using System.IO;

namespace SynacorVM.Net.OpCodes
{
    public class OutOpCode : IOpCode
    {
        public void dispatchOpCode(SynacorVM vm)
        {
            UInt16 outputChar;
            var readValue = vm.getNextMemoryAddress();

            if (readValue > short.MaxValue)
                outputChar = vm.getRegisterValue(readValue - short.MaxValue);
            else
                outputChar = readValue;

            Console.Write($"{(char)outputChar}");
        }
    }
}
