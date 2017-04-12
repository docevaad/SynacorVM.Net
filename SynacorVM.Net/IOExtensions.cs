using System.IO;

namespace SynacorVM.Net
{
    public static class IOExtensions
    {
        public static bool EOF(this BinaryReader reader)
        {
            var bs = reader.BaseStream;
            return bs.Position == bs.Length;
        }
    }
}
