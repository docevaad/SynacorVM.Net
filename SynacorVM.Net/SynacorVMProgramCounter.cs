namespace SynacorVM.Net
{
    public class SynacorVMProgramCounter
    {
        private ushort m_memorySize;
        private ushort m_pc;

        public SynacorVMProgramCounter(ushort memorySize)
        {
            m_memorySize = memorySize;
        }

        public void SetInstructionPointer(ushort address)
        {
            if (!address.ValidMemoryAddress())
                throw new SynacorVMException($"Invalid memory address: {address}");

            m_pc = address;
        }
        
        public ushort GetInstructionPointer()
        {
            return m_pc;
        }

        public ushort GetNextMemoryValue(SynacorVMMemory memory)
        {
            return memory.LoadMemoryAddress(m_pc++);
        }
    }
}
