using AssemblySimulator.EventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessorSimulator.Controls
{
    class MIRRegister : Register
    {
        public Dictionary<string, Command> SBUSCommands;
        public Dictionary<string, Command> DBUSCommands;
        public Dictionary<string, Command> OPALUCommands;
        public Dictionary<string, Command> RBUSCommands;
        public Dictionary<string, Command> OTHERCommands;
        public Dictionary<string, Command> OPMEMCommands;

        [Category("Extended Definitions")]
        public ulong LongValue
        {
            get => m_longValue;
            set
            {
                m_longValue = value;
                Invalidate();
                OnValueChanged(new RegisterModifiedEventArgs(RegisterName, value));
            }
        }
        private ulong m_longValue = 0;

        protected bool initialised = false;

        public void Init(Dictionary<string, Command> SBUSCommands,
                            Dictionary<string, Command> DBUSCommands,
                            Dictionary<string, Command> OPALUCommands,
                            Dictionary<string, Command> RBUSCommands,
                            Dictionary<string, Command> OTHERCommands,
                            Dictionary<string, Command> OPMEMCommands)
        {
            this.SBUSCommands = SBUSCommands;
            this.DBUSCommands = DBUSCommands;
            this.OPALUCommands = OPALUCommands;
            this.RBUSCommands = RBUSCommands;
            this.OTHERCommands = OTHERCommands;
            this.OPMEMCommands = OPMEMCommands;
            initialised = true;
        }

        protected override void PaintNumber(Graphics g)
        {
            switch (DisplayMode)
            {
                case RegisterDisplayMode.Decimal:
                    g.DrawString(m_longValue.ToString(), Font, generalUseBrush, Extended ? 45F : 30F, 0F);
                    break;
                case RegisterDisplayMode.Hexadecimal:
                    g.DrawString(" 0x" + m_longValue.ToString("X8"), Font, generalUseBrush, Extended ? 45F : 30F, 0F);
                    break;
                case RegisterDisplayMode.Binary:
                    {
                        string binaryFormatted = ToBinary((long)(m_longValue & 0x0000000f), 4);
                        binaryFormatted = ToBinary((long)((m_longValue >> 4) & 0x0000000f), 4) + " " + binaryFormatted;
                        binaryFormatted = ToBinary((long)((m_longValue >> 8) & 0x0000000f), 4) + " " + binaryFormatted;
                        binaryFormatted = ToBinary((long)((m_longValue >> 12) & 0x0000000f), 4) + " " + binaryFormatted;
                        binaryFormatted = ToBinary((long)((m_longValue >> 16) & 0x0000000f), 4) + " " + binaryFormatted;
                        binaryFormatted = ToBinary((long)((m_longValue >> 20) & 0x0000000f), 4) + " " + binaryFormatted;
                        binaryFormatted = ToBinary((long)((m_longValue >> 24) & 0x0000000f), 4) + " " + binaryFormatted;
                        binaryFormatted = ToBinary((long)((m_longValue >> 28) & 0x0000000f), 4) + " " + binaryFormatted;
                        g.DrawString(binaryFormatted, Font, generalUseBrush, Extended ? 45F : 30F, 0F);
                    }
                    break;
                default:
                    break;
            }
        }

        public Command GetSBUS()
        {
            if (!initialised)
                return null;
            byte code = (byte)((LongValue >> 35) & 0x0000000f);
            return SBUSCommands.Where(t => t.Value.Code == code).FirstOrDefault().Value;
        }

        public Command GetDBUS()
        {
            if (!initialised)
                return null;
            byte code = (byte)((LongValue >> 31) & 0x0000000f);
            return DBUSCommands.Where(t => t.Value.Code == code).FirstOrDefault().Value;
        }

        public Command GetOPALU()
        {
            if (!initialised)
                return null;
            byte code = (byte)((LongValue >> 27) & 0x0000000f);
            return OPALUCommands.Where(t => t.Value.Code == code).FirstOrDefault().Value;
        }

        public Command GetRBUS()
        {
            if (!initialised)
                return null;
            byte code = (byte)((LongValue >> 23) & 0x0000000f);
            return RBUSCommands.Where(t => t.Value.Code == code).FirstOrDefault().Value;
        }
        public Command GetOTHER()
        {
            if (!initialised)
                return null;
            byte code = (byte)((LongValue >> 19) & 0x0000000f);
            return OTHERCommands.Where(t => t.Value.Code == code).FirstOrDefault().Value;
        }

        public Command GetOPMEM()
        {
            if (!initialised)
                return null;
            byte code = (byte)((LongValue >> 17) & 0x00000003);
            return OPMEMCommands.Where(t => t.Value.Code == code).FirstOrDefault().Value;
        }

        public byte GetCOND()
        {
            if (!initialised)
                return 0;
            return (byte)((LongValue >> 13) & 0x0000000f);
        }

        public byte GetT()
        {
            if (!initialised)
                return 0;
            return (byte)((~LongValue >> 12) & 0x00000001);
        }

        public byte GetJUMPBASE()
        {
            if (!initialised)
                return 0;
            return (byte)((LongValue >> 4) & 0x000000ff);
        }

        public byte GetINDEX()
        {
            if (!initialised)
                return 0;
            return (byte)((LongValue >> 0) & 0x0000000f);
        }
    }
}
