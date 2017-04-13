using System.IO;

namespace SynacorVM.Net.OpCodes
{
    public interface IOpCode
    {
        void DispatchOpCode(SynacorVMContext context);
    }
}
