﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class NoOpOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
        }
    }
}
