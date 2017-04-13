using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net
{
    public class SynacorVMContext
    {
        public SynacorVMProgramCounter PC { get; }
        public SynacorVMRegisters Registers { get; }
        public SynacorVMMemory Memory { get; }
        public Stack<ushort> Stack { get; }

        public SynacorVMContext()
        {
            PC = new SynacorVMProgramCounter((ushort) short.MaxValue);
            Registers = new SynacorVMRegisters();
            Memory = new SynacorVMMemory((ushort) short.MaxValue);
            Stack = new Stack<ushort>(50);
        }
    }
}
