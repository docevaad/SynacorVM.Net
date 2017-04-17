using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class OpCodeRegistry
    {
        private static readonly Dictionary<SVMOpCode, ISVMOpCode> opCodeDispatch = new Dictionary<SVMOpCode, ISVMOpCode>
        {
            { SVMOpCode.Halt, new HaltOpcode() },
            { SVMOpCode.Set, new SetOpCode() },
            { SVMOpCode.Push, new PushOpCode() },
            { SVMOpCode.Pop, new PopOpCode() },
            { SVMOpCode.Eq, new EqualOpCode() },
            { SVMOpCode.Gt, new GreaterThanOpCode() },
            { SVMOpCode.Jmp, new JumpOpCode() },
            { SVMOpCode.Out, new OutOpCode() },
            { SVMOpCode.Noop, new NoOpOpCode() }
        };

        public void DispatchOpCode(SVMOpCode opcode, SynacorVMContext context)
        {
            opCodeDispatch[opcode].DispatchOpCode(context);
        }
    }
}
