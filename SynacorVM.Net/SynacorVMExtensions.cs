namespace SynacorVM.Net
{
    public static class SynacorVMExtensions
    {
        public static bool ValidMemoryAddress(this ushort address)
        {
            return (address < short.MaxValue);
        }

        public static bool ValidRegister(this ushort register)
        {
            var registerIndex = GetRegisterIndex(register);
            return (registerIndex >= 0) && (registerIndex <= 7);
        }

        public static ushort GetRegisterIndex(this ushort register)
        {
            return (ushort)(register - short.MaxValue);
        }
    }
}
