using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorSimulator
{
    public partial class MainForm
    {
        public Dictionary<string, Command> RegisteredDBUSCommands, RegisteredSBUSCommands;
        public Dictionary<string, Command> RegisteredOPALUCommands;
        public Dictionary<string, Command> RegisteredOTHERCommands;
        public Dictionary<string, Command> RegisteredRBUSCommands;
        public Dictionary<string, Command> RegisteredOPMEMCommands;
        public Dictionary<string, Command> RegisteredINTRCommands;
        public readonly ulong[] MPM =
        {
            0x408A8A6011, 0x0000006052, 0x00000060E3, 0x0000006747, 0x0000006626, 0x408A8C30E0, 0x208B0060E3, 0x108B0060E3,
            0x0000000000, 0x108A843090, 0x0A0B0060E3, 0x408A8C30B0, 0x120A8430B0, 0x0A0B0070E3, 0x0C0A8CA184, 0x0000006265,
            0x090980A184, 0x0000006265, 0x090A84A184, 0x0000006265, 0x408A8C3140, 0x210A84A184, 0x0000006265, 0x2088804C60,
            0x388980C170, 0x0000066C60, 0x3A09A0C170, 0x0000066C60, 0x3A69A0C170, 0x0000066C60, 0x3A68206C61, 0x0000000000,
            0x3A11A0D170, 0x0000064C60, 0x3A19A0D170, 0x0000064C60, 0x3A21A0D170, 0x0000064C60, 0x088980D170, 0x0000064C60,
            0x0000000000, 0x0000000000, 0x0229A0D170, 0x0000064C60, 0x0000000000, 0x0000000000, 0x5A09A0D170, 0x0000064C60,
            0x0000000000, 0x0000000000, 0x6209A0D170, 0x0000064C60, 0x0000000000, 0x0000000000, 0x0239A0D170, 0x0000064C60,
            0x0000000000, 0x0000000000, 0x0231A0D170, 0x0000064C60, 0x0000000000, 0x0000000000, 0x0241A0D170, 0x0000064C60,
            0x0000000000, 0x0000000000, 0x0249A0D170, 0x0000064C60, 0x0000000000, 0x0000000000, 0x0251A0D170, 0x0000064C60,
            0x0000000000, 0x0000000000, 0x0259A0D170, 0x0000064C60, 0x0000000000, 0x0000000000, 0x0261A0D170, 0x0000064C60,
            0x0000000000, 0x0000000000, 0x0A0B804C60, 0x0000000000, 0x0000000000, 0x0000000000, 0x0909983560, 0x0A8A866C60,
            0x0000000000, 0x0000000000, 0x0A8A8435A0, 0x0A08906C60, 0x0000000000, 0x0000000000, 0x0A0B0025E0, 0x0C099835E0,
            0x288A8635E0, 0x388B806C60, 0x6C0B806C60, 0x0000000000, 0x000000F620, 0x0000006C60, 0x000000E620, 0x0000006C60,
            0x0000015620, 0x0000006C60, 0x0000014620, 0x0000006C60, 0x0000010620, 0x0000006C60, 0x0000011620, 0x0000006C60,
            0x0000012620, 0x0000006C60, 0x0000013620, 0x0000006C60, 0x0000286C60, 0x0000000000, 0x0000000000, 0x0000000000,
            0x0000306C60, 0x0000000000, 0x0000000000, 0x0000000000, 0x0000386C60, 0x0000000000, 0x0000000000, 0x0000000000,
            0x0000406C60, 0x0000000000, 0x0000000000, 0x0000000000, 0x0000486C60, 0x0000000000, 0x0000000000, 0x0000000000,
            0x0000506C60, 0x0000000000, 0x0000000000, 0x0000000000, 0x0000586C60, 0x0000000000, 0x0000000000, 0x0000000000,
            0x0000606C60, 0x0000000000, 0x0000000000, 0x0000000000, 0x0000686C60, 0x0000000000, 0x0000000000, 0x0000000000,
            0x0000706C60, 0x0000000000, 0x0000000000, 0x0000000000, 0x0000006C60, 0x0000000000, 0x0000000000, 0x0000000000,
            0x0A8A843A00, 0x0A0B906C60, 0x0000000000, 0x0000000000, 0x0A8A843A40, 0x0A0B903A40, 0x0A8A843A40, 0x0A0C906C60,
            0x0000786C60, 0x0000000000, 0x0000000000, 0x0000000000, 0x0000016C00, 0x0000006AC0, 0x0000000000, 0x0000000000,
            0x0C09983B00, 0x0A8A866C60, 0x0000000000, 0x0000000000, 0x0A8A843B40, 0x0A0B906C60, 0x0000000000, 0x0000000000,
            0x0D09983B00, 0x0A8A866C60, 0x0000000000, 0x0000000000, 0x0A8A843B40, 0x0A0C906C60, 0x0000000000, 0x0000000000,
            0x0D09983C00, 0x0A8A863C00, 0x0C09983C00, 0x0A8A863C00, 0x0C8A843C00, 0x0A0B806000, 0x0000016C00, 0x0000006000
        };

        void InitializeRuntimeElements()
        {
            RegisteredDBUSCommands = new Dictionary<string, Command>
            {
                { "NONE", new Command("NONE", 0) },
                { "Pd0", new Command("Pd0", 1) },
                { "PdRG", new Command("PdRG", 2) },
                { "PdIR", new Command("PdIR", 3) },
                { "PdMDR", new Command("PdMDR", 4) },
                { "PdSP", new Command("PdSP", 5) },
                { "PdADR", new Command("PdADR", 6) },
                { "PdT", new Command("PdT", 7) },
                { "PdPC", new Command("PdPC", 8) },
                { "PdIVR", new Command("PdIVR", 9) },
                { "PdFLAG", new Command("PdFLAG", 10) },
                { "Pd1", new Command("Pd1", 11) },
                { "Pd-1", new Command("Pd-1", 12) },
                { "PdIROFFSET", new Command("PdIROFFSET", 13) }
            };
            RegisteredSBUSCommands = RegisteredDBUSCommands;

            RegisteredOPALUCommands = new Dictionary<string, Command>
            {
                { "NONE", new Command("NONE", 0) },
                { "SUM", new Command("SUM", 1) },
                { "AND", new Command("AND", 2) },
                { "OR", new Command("OR", 3) },
                { "XOR", new Command("XOR", 4) },
                { "NEG", new Command("NEG", 5) },
                { "ASR", new Command("ASR", 6) },
                { "ASL", new Command("ASL", 7) },
                { "LSR", new Command("LSR", 8) },
                { "ROL", new Command("ROL", 9) },
                { "ROR", new Command("ROR", 10) },
                { "RLC", new Command("RLC", 11) },
                { "RRC", new Command("RRC", 12) },
                { "SUB", new Command("SUB", 13) }
            };

            RegisteredRBUSCommands = new Dictionary<string, Command>
            {
                { "NONE", new Command("NONE", 0) },
                { "PmRG", new Command("PmRG", 1) },
                { "PmIR", new Command("PmIR", 2) },
                { "PmMDR", new Command("PmMDR", 3) },
                { "PmSP", new Command("PmSP", 4) },
                { "PmADR", new Command("PmADR", 5) },
                { "PmT", new Command("PmT", 6) },
                { "PmPC", new Command("PmPC", 7) },
                { "PmIVR", new Command("PmIVR", 8) },
                { "PmFLAG", new Command("PmFLAG", 9) }
            };

            RegisteredOTHERCommands = new Dictionary<string, Command>
            {
                { "NONE", new Command("NONE", 0) },
                { "+1PC", new Command("+1PC", 1) },
                { "+1SP", new Command("+1SP", 2) },
                { "-1SP", new Command("-1SP", 3) },
                { "PdFLAGS", new Command("PdFLAGS", 4) },
                { "CLC", new Command("CLC", 5) },
                { "CLV", new Command("CLV", 6) },
                { "CLZ", new Command("CLZ", 7) },
                { "CLS", new Command("CLS", 8) },
                { "CCC", new Command("CCC", 9) },
                { "SEC", new Command("SEC", 10) },
                { "SEV", new Command("SEV", 11) },
                { "SEZ", new Command("SEZ", 12) },
                { "SES", new Command("SES", 13) },
                { "SCC", new Command("SCC", 14) }
            };

            RegisteredOPMEMCommands = new Dictionary<string, Command>
            {
                { "NONE", new Command("NONE", 0) },
                { "IFCH", new Command("IFCH", 1) },
                { "READ", new Command("READ", 2) },
                { "WRITE", new Command("WRITE", 3) }
            };


            RegisteredINTRCommands = new Dictionary<string, Command>
            {
                { "NONE", new Command("NONE", 0) },
                { "INTR", new Command("INTR", 1) },
                { "CIL", new Command("CIL", 2) },
                { "ACLOW", new Command("ACLOW", 3) }
            };
        }
    }
}
