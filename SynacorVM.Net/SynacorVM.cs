using SynacorVM.Net.OpCodes;
using System;
using System.Collections.Generic;
using System.IO;

namespace SynacorVM.Net
{
    public class SynacorVM
    {
        private UInt16 m_ip;
        private UInt16[] m_registers;
        private UInt16[] m_memory;
        private readonly Stack<UInt16> m_stack;
        private byte m_text;

        public SynacorVM()
        {
            m_ip = 0;
            m_registers = new UInt16[8];
            m_memory = new UInt16[short.MaxValue];
            m_stack = new Stack<UInt16>(50);
        }

        /// <summary>
        /// Loads the program.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <exception cref="SynacorVM.Net.SynacorVMException">Program size exceeded main memory.</exception>
        public void loadProgram(BinaryReader reader)
        {
            var memoryAddress = 0;
            while(!reader.EOF())
            {
                m_memory[memoryAddress] = reader.ReadUInt16();
                memoryAddress++;
                if (memoryAddress == short.MaxValue)
                    throw new SynacorVMException("Program size exceeded main memory.");
            }
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void run()
        {
            for (;;)
            {
                var opcodeDispatch = new OpCodeDispatch();
                UInt16 opcode = getNextMemoryAddress();
                opcodeDispatch.dispatchOpCode((SVMOpCode) opcode, this);
            }
        }

        /// <summary>
        /// Gets the register value.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public UInt16 getRegisterValue(int register)
        {
            if (register < 0 | register > 7)
                throw new ArgumentException($"Invalid register value: {register}");
            return m_registers[register];
        }

        /// <summary>
        /// Sets the register value.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException"></exception>
        public void setRegisterValue(int register, UInt16 value)
        {
            if (register < 0 | register > 7)
                throw new ArgumentException($"Invalid register value: {register}");
            m_registers[register] = value;
        }

        /// <summary>
        /// Gets the memory address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public UInt16 getMemoryAddress(UInt16 address)
        {
            if (address >= short.MaxValue)
                throw new ArgumentException($"Tried to dereference memory address greater than {short.MaxValue}: {address}");

            return m_memory[address];
        }

        /// <summary>
        /// Sets the memory address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException"></exception>
        public void setMemoryAddress(UInt16 address, UInt16 value)
        {
            if (address >= short.MaxValue)
                throw new ArgumentException($"Tried to dereference memory address greater than {short.MaxValue}: {address}");

            m_memory[address] = value;
        }

        /// <summary>
        /// Pushes the value on to stack.
        /// </summary>
        /// <param name="value">The value.</param>
        public void pushOnToStack(UInt16 value)
        {
            m_stack.Push(value);
        }

        /// <summary>
        /// Pops the value off of stack.
        /// </summary>
        /// <returns></returns>
        public UInt16 popOffOfStack()
        {
            return m_stack.Pop();
        }

        /// <summary>
        /// Sets the instruction pointer.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <exception cref="ArgumentException"></exception>
        public void setIP(UInt16 address)
        {
            if (address >= short.MaxValue)
                throw new ArgumentException($"Tried to set IP to memory address greater than {short.MaxValue}: {address}");
 
            m_ip = address;
        }

        public void incrementIP()
        {
            m_ip++;
        }

        public UInt16 getNextMemoryAddress()
        {
           return m_memory[m_ip++];
        }
    }
}
