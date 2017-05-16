namespace SynacorVM.Net.OpCodes
{
    public class ReadMemoryOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var destinationRegister = context.PC.GetNextMemoryValue(context.Memory);
            var sourceAddress = context.PC.GetNextMemoryValue(context.Memory)
                                    .UnwrapPotentialRegister(context.Registers);
            var  value = context.Memory.LoadMemoryAddress(sourceAddress);
            context.Registers.SetRegister(destinationRegister, value);
        }
    }
}
