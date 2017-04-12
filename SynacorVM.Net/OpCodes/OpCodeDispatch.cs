using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVM.Net.OpCodes
{
    public class OpCodeDispatch
    {
        private static readonly Dictionary<SVMOpCode, IOpCode> opCodeDispatch = new Dictionary<SVMOpCode, IOpCode>
        {
            { SVMOpCode.Halt, new HaltOpcode() },
            { SVMOpCode.Out, new OutOpCode() },
            { SVMOpCode.Noop, new NoOpOpCode() }
        };

        public void dispatchOpCode(SVMOpCode opcode, SynacorVM vm)
        {
            opCodeDispatch[opcode].dispatchOpCode(vm);
        }
    }
}
