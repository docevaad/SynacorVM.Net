using SynacorVM.Net.OpCodes;
using System.IO;

namespace SynacorVM.Net
{
    public class SynacorVMEngine
    {
        private readonly SynacorVMContext m_vmContext;

        public SynacorVMEngine(SynacorVMContext context)
        {
            m_vmContext = context;
        }

        /// <summary>
        /// Loads the program.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <exception cref="SynacorVMEngine.Net.SynacorVMException">Program size exceeded main memory.</exception>
        public void loadProgram(BinaryReader reader)
        {
            var memoryAddress = 0;
            while(!reader.EOF())
            {
                m_vmContext.Memory.StoreMemoryAddress((ushort)memoryAddress, reader.ReadUInt16());
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
            m_vmContext.PC.SetInstructionPointer(0);
            for (;;)
            {
                var opcodeDispatch = new OpCodeDispatch();
                ushort opcode = m_vmContext.PC.GetNextMemoryValue(m_vmContext.Memory);
                opcodeDispatch.DispatchOpCode((SVMOpCode)opcode, m_vmContext);
            }
        }
    }
}
