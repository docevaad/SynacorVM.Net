namespace SynacorVM.Net
{
    public class SynacorVMRegisters
    {
        private ushort[] m_registers;

        public SynacorVMRegisters()
        {
            m_registers = new ushort[8];
        }

        public void SetRegister(ushort register, ushort value)
        {
            if (!register.ValidRegister())
                throw new SynacorVMException($"Invalid register: {register}");

            var registerIndex = register.GetRegisterIndex(); ;
            m_registers[registerIndex] = value;
        }

        public ushort GetRegister(ushort register)
        {
            if (!register.ValidRegister())
                throw new SynacorVMException($"Invalid register: {register}");

            var registerIndex = register.GetRegisterIndex();
            return m_registers[registerIndex];
        }
    }
}
