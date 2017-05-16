namespace SynacorVM.Net.OpCodes
{
    public class AddOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var destination = context.PC.GetNextMemoryValue(context.Memory);
            var left = context.PC.GetNextMemoryValue(context.Memory).UnwrapPotentialRegister(context.Registers);
            var right = context.PC.GetNextMemoryValue(context.Memory).UnwrapPotentialRegister(context.Registers);
            var result = (left + right) % 32768;
            context.Registers.SetRegister(destination, (ushort) result);
        }
    }
}
