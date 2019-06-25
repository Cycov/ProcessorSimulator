//-----------------------------------------------------------------------

// <copyright file="MicroprocessorDisplay.cs" author="Circa Dragos">

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

namespace Simulator.Microprocessor
{
    public partial class MicroprocessorDisplay : Form
    {
        public MicroprocessorDisplay()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawArrow(new Pen(Color.Black, 4), new Point(0, 0), new Point(20, 50));
            e.Graphics.DrawALU(new Pen(Color.Black, 3) { EndCap = System.Drawing.Drawing2D.LineCap.Flat }, new Rectangle(50, 100, 400, 120));
            base.OnPaint(e);
        }
    }
}
