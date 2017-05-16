using SynacorVM.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVMDecompiler
{
    public class SynacorVMDecompilerMain
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
                Fatal("Incorrect number of arguments.");

            using (FileStream fs = File.Open(args[0], FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    using(StreamWriter writer = new StreamWriter(args[1]))
                    {
                        var position = 0;
                        while (!reader.EOF())
                        {
                            ushort opcode = reader.ReadUInt16();
                            var opcodeName = GetOpCodeName(opcode);
                            var opcodeArguments = GetOpCodeArguments(opcode, reader);
                            writer.WriteLine($"{position}: {opcodeName} {String.Join(" ", opcodeArguments)}");
                            position = position + opcodeArguments.Count + 1;
                        }
                    }
                }
            }
            Console.WriteLine("Done!");
        }

       static string GetOpCodeName(UInt16 opcode)
        {
            switch(opcode)
            {
                case 0: return "halt";
                case 1: return "set";
                case 2: return "push";
                case 3: return "pop";
                case 4: return "eq";
                case 5: return "gt";
                case 6: return "jmp";
                case 7: return "jt";
                case 8: return "jf";
                case 9: return "add";
                case 10: return "mult";
                case 11: return "mod";
                case 12: return "and";
                case 13: return "or";
                case 14: return "not";
                case 15: return "rmem";
                case 16: return "wmem";
                case 17: return "call";
                case 18: return "ret";
                case 19: return "out";
                case 20: return "in";
                case 21: return "nop";
                default: return $"unknown opcode {opcode}";
            }
        }

        static List<UInt16> GetOpCodeArguments(UInt16 opcode, BinaryReader reader)
        {
            List<UInt16> argumentList = new List<UInt16>();
            /*
set: 1 a b
push: 2 a
pop: 3 a
eq: 4 a b c
gt: 5 a b c
jmp: 6 a
jt: 7 a b
jf: 8 a b
add: 9 a b c
mult: 10 a b c
mod: 11 a b c
and: 12 a b c
or: 13 a b c
not: 14 a b
rmem: 15 a b
wmem: 16 a b
call: 17 a
out: 19 a
in: 20 a
             */
            if (opcode==2 ||
                opcode==3 ||
                opcode==6 ||
                opcode==17 ||
                opcode==19 ||
                opcode==20)
            {
                argumentList.Add(reader.ReadUInt16());
            }
            else if (opcode==1 ||
                    opcode==7 ||
                    opcode==8 ||
                    opcode==14 ||
                    opcode==15 ||
                    opcode==16)
            {
                argumentList.Add(reader.ReadUInt16());
                argumentList.Add(reader.ReadUInt16());
            }
            else if (opcode==4 || opcode==5 || opcode==9 || opcode==10 || opcode==11 || opcode==12 || opcode==13)
            {
                argumentList.Add(reader.ReadUInt16());
                argumentList.Add(reader.ReadUInt16());
                argumentList.Add(reader.ReadUInt16());
            }

            return argumentList;
        }

        static void Fatal(string msg)
        {
            Console.Error.WriteLine(msg);
            Environment.Exit(0);
        }
    }
}
