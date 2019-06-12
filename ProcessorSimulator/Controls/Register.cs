using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssemblySimulator.EventArgs;

namespace ProcessorSimulator.Controls
{
    public partial class Register : UserControl
    {
        public enum RegisterDisplayMode
        {
            Decimal,
            Hexadecimal,
            Binary
        }

        [Category("Definitions")]
        public string RegisterName
        {
            get; set;
        } = "IR";


        [Category("Definitions")]
        public ushort Value
        {
            get => m_value;
            set
            {
                m_value = value;
                Invalidate();
                OnValueChanged(new RegisterModifiedEventArgs(RegisterName, value));
            }
        }
        private ushort m_value = 0;

        [Category("Definitions")]
        public bool Extended
        {
            get; set;
        } = false;

        [Category("Definitions")]
        public bool Readonly
        {
            get; set;
        } = false;

        [Category("Definitions")]
        public RegisterDisplayMode DisplayMode
        {
            get => displayMode;
            set
            {
                displayMode = value;
                Invalidate();
            }
        } 
        private RegisterDisplayMode displayMode = RegisterDisplayMode.Hexadecimal;

        public byte Low
        {
            get => (byte)m_value;
            set
            {
                m_value = (ushort)((m_value & 0xFF00) | value);
                Invalidate();
            }
        }

        public byte High
        {
            get => (byte)(m_value >> 8);
            set
            {
                m_value = (ushort)((m_value & 0x00FF) | value);
                Invalidate();
            }
        }

        protected SolidBrush generalUseBrush;

        public event EventHandler<RegisterModifiedEventArgs> ValueChanged;

        public Register()
        {
            InitializeComponent();
            generalUseBrush = new SolidBrush(ForeColor);
            Size = new Size(75, 14);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawString(RegisterName + ":", new Font(Font.FontFamily, Font.Size, FontStyle.Bold, Font.Unit), generalUseBrush, 0F, 0F);
            PaintNumber(e.Graphics);
            base.OnPaint(e);
        }

        protected void OnValueChanged(RegisterModifiedEventArgs eventArgs)
        {
            ValueChanged?.Invoke(this, eventArgs);
        }

        protected virtual void PaintNumber(Graphics g)
        {
            switch (DisplayMode)
            {
                case RegisterDisplayMode.Decimal:
                    g.DrawString(m_value.ToString(), Font, generalUseBrush, Extended ? 45F : 30F, 0F);
                    break;
                case RegisterDisplayMode.Hexadecimal:
                    g.DrawString(" 0x" + m_value.ToString("X4"), Font, generalUseBrush, Extended ? 45F : 30F, 0F);
                    break;
                case RegisterDisplayMode.Binary:
                    {
                        string binaryFormatted = ToBinary(m_value & 0x000f, 4);
                        binaryFormatted = ToBinary((m_value >> 4) & 0x000f, 4) + " " + binaryFormatted;
                        binaryFormatted = ToBinary((m_value >> 8) & 0x000f, 4) + " " + binaryFormatted;
                        binaryFormatted = ToBinary((m_value >> 12) & 0x000f, 4) + " " + binaryFormatted;
                        g.DrawString(binaryFormatted, Font, generalUseBrush, Extended ? 45F : 30F, 0F);
                    }
                    break;
                default:
                    break;
            }
        }
        
        private void Register_Click(object sender, EventArgs e)
        {
            if (Readonly)
                return;
            NumericalValueEditor valueEditor = new NumericalValueEditor(Value);
            if (valueEditor.ShowDialog() == DialogResult.OK)
            {
                Value = valueEditor.Value;
            }
        }

        public static string ToBinary(int myValue, int totalLength)
        {
            string binVal = Convert.ToString(myValue, 2);
            return binVal.PadLeft(totalLength, '0');
        }

        public static string ToBinary(long myValue, int totalLength)
        {
            string binVal = Convert.ToString(myValue, 2);
            return binVal.PadLeft(totalLength, '0');
        }
    }
}
