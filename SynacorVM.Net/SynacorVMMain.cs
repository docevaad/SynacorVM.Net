using SynacorVM.Net.OpCodes;
using System;
using System.IO;

namespace SynacorVM.Net
{
    class SynacorVMMain
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
                Fatal("Incorrect number of arguments.");

            var engine = new SynacorVMEngine(new SynacorVMContext());
            using (FileStream fs = File.Open(args[0], FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    engine.LoadProgram(reader); 
                }
            }
            engine.Run();
            Console.ReadLine();
        }

        static void Fatal(string msg)
        {
            Console.Error.WriteLine(msg);
            Environment.Exit(0);
        }
    }
}
