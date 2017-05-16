namespace SynacorVM.Net.OpCodes
{
    public class CallOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var addressToJumpTo = context.PC.GetNextMemoryValue(context.Memory)
                                    .UnwrapPotentialRegister(context.Registers);
            context.Stack.Push(context.PC.GetInstructionPointer());
            context.PC.SetInstructionPointer(addressToJumpTo);
        }
    }
}
