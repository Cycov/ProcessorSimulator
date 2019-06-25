//-----------------------------------------------------------------------

// <copyright file="MemorySegmentDisplay.cs" author="Circa Dragos">

//     Copyright (c) Circa Dragos. All rights reserved.

// </copyright>

//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessorSimulator.Controls
{
    class MemorySegmentDisplay : MemoryDisplay
    {

        protected readonly int bytePadding = 0;

        public MemorySegmentDisplay()
        {
            this.Paint += MemorySegmentDisplay_Paint;
            this.DoubleClick += MemorySegmentDisplay_DoubleClick;
            this.Click += MemorySegmentDisplay_Click;
        }

        private void MemorySegmentDisplay_Click(object sender, EventArgs e)
        {
            
        }

        private void MemorySegmentDisplay_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void MemorySegmentDisplay_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            
        }
    }
}
