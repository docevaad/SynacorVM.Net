namespace SynacorVM.Net
{
    public static class SynacorVMExtensions
    {
        public static bool ValidMemoryAddress(this ushort address)
        {
            return (address < short.MaxValue + 1);
        }

        public static bool ValidRegister(this ushort register)
        {
            var registerIndex = GetRegisterIndex(register);
            return (registerIndex >= 0) && (registerIndex <= 7);
        }

        public static ushort GetRegisterIndex(this ushort register)
        {
            return (ushort)(register - (short.MaxValue + 1));
        }

        public static ushort UnwrapPotentialRegister(this ushort potentialRegister, SynacorVMRegisters registers)
        {
            if (potentialRegister.ValidRegister())
                return registers.GetRegister(potentialRegister);
            return potentialRegister;
        }
    }
}
