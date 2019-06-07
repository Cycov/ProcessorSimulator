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
    public partial class StackDisplay : MemoryDisplay
    {
        [Category("Definitions")]
        public int StackSize
        {
            get { return size;  }
        }

        private Register registerSS;

        public StackDisplay()
        {
            InitializeComponent();
            Size = new Size(125, 375);
            boldedFont = new Font(this.Font, FontStyle.Bold);
        }

        public void Init(Memory memory, Register registerSS, ushort size)
        {
            if ((registerSS.Value << 4) + size > memory.Size)
                throw new ArgumentOutOfRangeException("Size exceeded maximum adress. Pick a lower segment adress");
            if (size % 2 != 0)
                throw new ArgumentException("Please use a even size");

            base.size = size;
            if (this.size / 2 < maxLines)
            {
                vScrollBar.Visible = false;
                maxLines = base.size / 2;
            }
            this.registerSS = registerSS;
            this.registerSS.ValueChanged += RegisterSS_ValueChanged;

            base.Init(memory, registerSS);
        }

        private void RegisterSS_ValueChanged(object sender, RegisterModifiedEventArgs e)
        {
            segment = e.Value;
            Invalidate();
        }

        private void Memory_OnMemoryModified(object sender, MemoryModifiedEventArgs e)
        {
            Invalidate();
        }

        private void StackDisplay_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }
    }
}
