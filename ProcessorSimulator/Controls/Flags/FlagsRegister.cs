using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Simulator.Controls.Flags
{
    public partial class FlagsRegister : UserControl
    {
        protected Dictionary<Flags, Flag> flagsCheckboxes;

        public enum Flags
        {
            CF = 0,
            PF = 2,
            AF = 4,
            ZF = 6,
            SF = 7,
            TF = 8,
            IF = 9,
            DF = 10,
            OF = 11
        }

        [Category("Definitions")]
        public ushort Value
        {
            get => m_value;
            set
            {
                m_value = value;
                register.Value = m_value;
            }
        }
        private ushort m_value = 0;

        public FlagsRegister()
        {
            InitializeComponent();
            Size = new System.Drawing.Size(100, 100);
            flagsCheckboxes = new Dictionary<Flags, Flag>
            {
                { Flags.CF, flagC },
                { Flags.PF, flagP },
                { Flags.AF, flagA },
                { Flags.ZF, flagZ },
                { Flags.SF, flagS },
                { Flags.TF, flagT },
                { Flags.IF, flagI },
                { Flags.DF, flagD },
                { Flags.OF, flagO }
            };
        }

        public void SetFlag(Flags flag, bool value)
        {
            if (!flagsCheckboxes.ContainsKey(flag))
                throw new InvalidEnumArgumentException("Flag invalid or collection not properly initialised");
            byte bit = value ? (byte)1 : (byte)0;

            m_value = (ushort)((m_value & ~(1 << (int)flag)) | (bit << (int)flag));
            Invalidate();

            flagsCheckboxes[flag].Checked = value;
        }

        private void Flag_CheckedChanged(object sender, EventArgs e)
        {
            Flag flag = (Flag)sender;
            byte value = flag.Checked ? (byte)1 : (byte)0;

            if (Enum.TryParse<Flags>(flag.Text, out Flags activeFlag))
            {
                Value = (ushort)((m_value & ~(1 << (int)activeFlag)) | (value << (int)activeFlag));
            }
            else
            {
                throw new InvalidEnumArgumentException("Invalid flag: " + flag.Text);
            }
        }
    }
}
