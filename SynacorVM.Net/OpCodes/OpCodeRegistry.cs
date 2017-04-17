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
            { SVMOpCode.Jt, new JtOpCode() },
            { SVMOpCode.Jf, new JfOpCode() },
            { SVMOpCode.Add, new AddOpCode() },
            { SVMOpCode.Mult, new MultiplyOpCode() },
            { SVMOpCode.Mod, new ModulusOpCode() },
            { SVMOpCode.And, new AndOpCode() },
            { SVMOpCode.Or, new OrOpCode() },
            { SVMOpCode.Not, new NotOpCode() },
            { SVMOpCode.Rmem, new ReadMemoryOpCode() },
            { SVMOpCode.Wmem, new WriteMemoryOpCode() },
            { SVMOpCode.Call, new CallOpCode() },
            { SVMOpCode.Ret, new ReturnOpCode() },
            { SVMOpCode.Out, new OutOpCode() },
            { SVMOpCode.In, new InOpCode() },
            { SVMOpCode.Noop, new NoOpOpCode() }
        };

        public void DispatchOpCode(SVMOpCode opcode, SynacorVMContext context)
        {
            opCodeDispatch[opcode].DispatchOpCode(context);
        }
    }
}
