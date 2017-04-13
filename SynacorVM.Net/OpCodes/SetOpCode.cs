﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class SetOpCode : IOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var register = context.PC.GetNextMemoryValue(context.Memory);
            var value = context.PC.GetNextMemoryValue(context.Memory);
            context.Registers.SetRegister(register, value);
        }
    }
}
