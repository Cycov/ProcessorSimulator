//-----------------------------------------------------------------------

// <copyright file="Parser.Instructions.cs" author="Circa Dragos">

//     Copyright (c) Circa Dragos. All rights reserved.

// </copyright>

//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorSimulator.Assembler
{
    public partial class Parser
    {
        public static readonly Dictionary<string, Instruction> Instructions = new Dictionary<string, Instruction>()
        {
            //Clasa 1 - b1) Instructiuni cu 2 operanzi
            { "mov", new Instruction { Class = 0, Opcode = 0b0_000 } },
            { "add", new Instruction { Class = 0, Opcode = 0b0_001 } },
            { "sub", new Instruction { Class = 0, Opcode = 0b0_010 } },
            { "cmp", new Instruction { Class = 0, Opcode = 0b0_011 } },
            { "and", new Instruction { Class = 0, Opcode = 0b0_100 } },
            { "or", new Instruction { Class = 0, Opcode = 0b0_101 } },
            { "xor", new Instruction { Class = 0, Opcode = 0b0_110 } },

            //Clasa 2 - b2) Instructiuni cu un operand
            
            { "clr", new Instruction { Class = 1, Opcode = 0b100_000_0000 } },
            { "neg", new Instruction { Class = 1, Opcode = 0b100_000_0001 } },
            { "inc", new Instruction { Class = 1, Opcode = 0b100_000_0010 } },
            { "dec", new Instruction { Class = 1, Opcode = 0b100_000_0011 } },
            { "asl", new Instruction { Class = 1, Opcode = 0b100_000_0100 } },
            { "asr", new Instruction { Class = 1, Opcode = 0b100_000_0101 } },
            { "lsr", new Instruction { Class = 1, Opcode = 0b100_000_0110 } },
            { "rol", new Instruction { Class = 1, Opcode = 0b100_000_0111 } },
            { "ror", new Instruction { Class = 1, Opcode = 0b100_000_1000 } },
            { "rlc", new Instruction { Class = 1, Opcode = 0b100_000_1001 } },
            { "rrc", new Instruction { Class = 1, Opcode = 0b100_000_1010 } },
            { "jmp", new Instruction { Class = 1, Opcode = 0b100_000_1011 } },
            { "call", new Instruction { Class = 1, Opcode = 0b100_000_1100 } },
            { "push", new Instruction { Class = 1, Opcode = 0b100_000_1101 } },
            { "pop", new Instruction { Class = 1, Opcode = 0b100_000_1110 } },

            //Clasa 3 - b3) Instructiuni de salt
                        
            { "br", new Instruction { Class = 2, Opcode = 0b110_0_0000 } },
            { "bne", new Instruction { Class = 2, Opcode = 0b110_0_0001 } },
            { "beq", new Instruction { Class = 2, Opcode = 0b110_0_0010 } },
            { "bpl", new Instruction { Class = 2, Opcode = 0b110_0_0011 } },
            { "bmi", new Instruction { Class = 2, Opcode = 0b110_0_0100 } },
            { "bcs", new Instruction { Class = 2, Opcode = 0b110_0_0101 } },
            { "bcc", new Instruction { Class = 2, Opcode = 0b110_0_0110 } },
            { "bvs", new Instruction { Class = 2, Opcode = 0b110_0_0111 } },
            { "bvc", new Instruction { Class = 2, Opcode = 0b110_0_1000 } },

            //Clasa 4 - b4) Instructiuni diverse
            
            { "clc", new Instruction { Class = 3, Opcode = 0b111_00000000_00000 } },
            { "clv", new Instruction { Class = 3, Opcode = 0b111_00000000_00001 } },
            { "clz", new Instruction { Class = 3, Opcode = 0b111_00000000_00010 } },
            { "cls", new Instruction { Class = 3, Opcode = 0b111_00000000_00011 } },
            { "ccc", new Instruction { Class = 3, Opcode = 0b111_00000000_00100 } },
            { "sec", new Instruction { Class = 3, Opcode = 0b111_00000000_00101 } },
            { "sev", new Instruction { Class = 3, Opcode = 0b111_00000000_00110 } },
            { "sez", new Instruction { Class = 3, Opcode = 0b111_00000000_00111 } },
            { "ses", new Instruction { Class = 3, Opcode = 0b111_00000000_01000 } },
            { "scc", new Instruction { Class = 3, Opcode = 0b111_00000000_01001 } },
            { "nop", new Instruction { Class = 3, Opcode = 0b111_00000000_01010 } },
            { "ret", new Instruction { Class = 3, Opcode = 0b111_00000000_01011 } },
            { "reti", new Instruction { Class = 3, Opcode = 0b111_00000000_01100 } },
            { "halt", new Instruction { Class = 3, Opcode = 0b111_00000000_01101 } },
            { "wait", new Instruction { Class = 3, Opcode = 0b111_00000000_01110 } },
            { "pushpc", new Instruction { Class = 3, Opcode = 0b111_00000000_01111 } },
            { "poppc", new Instruction { Class = 3, Opcode = 0b111_00000000_10000 } },
            { "pushf", new Instruction { Class = 3, Opcode = 0b111_00000000_10001 } },
            { "popf", new Instruction { Class = 3, Opcode = 0b111_00000000_10010} }
        };
    }
}
