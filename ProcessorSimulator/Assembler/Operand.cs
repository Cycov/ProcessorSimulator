using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorSimulator.Assembler
{
    public class Operand
    {
        public AdressingTypes AdressingMode;
        public byte Register;
        public ushort Offset;
    }

    public enum AdressingTypes
    {
        AM = 0b00,
        AD = 0b01,
        AI = 0b10,
        AX = 0b11
    }
}
