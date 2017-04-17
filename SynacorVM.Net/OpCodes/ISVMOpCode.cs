using System.IO;

namespace SynacorVM.Net.OpCodes
{
    public interface ISVMOpCode
    {
        void DispatchOpCode(SynacorVMContext context);
    }
}
