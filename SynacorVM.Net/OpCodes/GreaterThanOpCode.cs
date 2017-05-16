namespace SynacorVM.Net.OpCodes
{
    public class GreaterThanOpCode : ISVMOpCode
    {
        public void DispatchOpCode(SynacorVMContext context)
        {
            var dest = context.PC.GetNextMemoryValue(context.Memory);
            var left = context.PC.GetNextMemoryValue(context.Memory).UnwrapPotentialRegister(context.Registers);
            var right = context.PC.GetNextMemoryValue(context.Memory).UnwrapPotentialRegister(context.Registers);
            ushort result = 0;
            if (left > right)
                result = 1;

            if (dest.ValidRegister())
                context.Registers.SetRegister(dest, result);
            else
                context.Memory.StoreMemoryAddress(dest, result);
        }
    }
}
