using System.IO;

namespace SynacorVM.Net.OpCodes
{
    public interface IOpCode
    {
        void dispatchOpCode(SynacorVM vm);
    }
}
