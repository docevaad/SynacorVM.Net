using System;

namespace SynacorVM.Net
{
    public class SynacorVMMemory
    {
        private UInt16 m_memorySize;
        private UInt16[] m_memory;

        public SynacorVMMemory(UInt16 memorySize)
        {
            m_memorySize = memorySize;
            m_memory = new UInt16[memorySize];
        }

        public void StoreMemoryAddress(UInt16 address, UInt16 value)
        {
            if (!address.ValidMemoryAddress())
                throw new SynacorVMException($"Invalid memory address: {address}");

            m_memory[address] = value;
        }

        public UInt16 LoadMemoryAddress(UInt16 address)
        {
            if (!address.ValidMemoryAddress())
                throw new SynacorVMException($"Invalid memory address: {address}");

            return m_memory[address];
        }
    }
}
