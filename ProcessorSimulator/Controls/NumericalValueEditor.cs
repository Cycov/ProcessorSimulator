using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessorSimulator.Controls
{
    public partial class NumericalValueEditor : Form
    {
        public ushort Value
        {
            get; protected set;
        }

        public NumericalValueEditor(ushort value)
        {
            InitializeComponent();
            Value = value;
            valueTb.Text = value.ToString("X");
        }

        private void valueTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !((e.KeyChar >= 'A' && e.KeyChar <= 'F') || (e.KeyChar >= 'a' && e.KeyChar <= 'f')))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 0x0A)
                Close();
        }

        private void NumericalValueEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Value = ushort.Parse(valueTb.Text, System.Globalization.NumberStyles.HexNumber);
        }

        private void increaseBtn_Click(object sender, EventArgs e)
        {
            if (Value < ushort.MaxValue)
                Value++;
            valueTb.Text = Value.ToString("X");
        }

        private void decreaseBtn_Click(object sender, EventArgs e)
        {
            if (Value > 0)
                Value--;
            valueTb.Text = Value.ToString("X");
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NumericalValueEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
