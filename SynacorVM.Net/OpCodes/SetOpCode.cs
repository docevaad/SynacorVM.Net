using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class SetOpCode : IOpCode
    {
        public void dispatchOpCode(SynacorVM vm)
        {
            var register = vm.getNextMemoryAddress();
            if (register > short.MaxValue + 8)
                throw new SynacorVMException($"Register value outside of range: {register}");

            register -= (ushort) short.MaxValue;

            var value = vm.getNextMemoryAddress();
            vm.setRegisterValue(register, value);
        }
    }
}
