//-----------------------------------------------------------------------

// <copyright file="JumpToAdress.cs" author="Circa Dragos">

//     Copyright (c) Circa Dragos. All rights reserved.

// </copyright>

//-----------------------------------------------------------------------

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
    public partial class JumpToAdress : Form
    {
        public ushort Segment
        {
            get; protected set;
        }

        public ushort Offset
        {
            get; protected set;
        }

        public JumpToAdress(ushort segment, ushort offset)
        {
            InitializeComponent();
            segmentTb.Text = segment.ToString("X4");
            offsetTb.Text = offset.ToString("X4");

            Segment = segment;
            Offset = offset;
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !((e.KeyChar >= 'A' && e.KeyChar <= 'F') || (e.KeyChar >= 'a' && e.KeyChar <= 'f')))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 0x0A)
                Close();
        }

        private void JumpToAdress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void JumpToAdress_FormClosing(object sender, FormClosingEventArgs e)
        {
            Segment = ushort.Parse(segmentTb.Text, System.Globalization.NumberStyles.HexNumber);
            Offset = ushort.Parse(offsetTb.Text, System.Globalization.NumberStyles.HexNumber);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
