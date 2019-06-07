using System.Drawing;
using System.Windows.Forms;
using AssemblySimulator.EventArgs;

namespace ProcessorSimulator.Controls
{
    class CodeDisplay : MemoryDisplay
    {
        public int CurrentOffset { get; protected set; }

        public CodeDisplay() { }

        public void Init(Memory memory, Register segmentRegister, Register registerIP)
        {
            registerIP.ValueChanged += RegisterIP_ValueChanged;
            base.Init(memory, segmentRegister);
        }

        private void RegisterIP_ValueChanged(object sender, RegisterModifiedEventArgs e)
        {
            CurrentOffset = e.Value;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.LightGray, 0, 0, Width - 1, Height - 1);
            e.Graphics.FillRectangle(offsetsBackgroundBrush, 0, 0, leftRectangleWidth, Height);
            e.Graphics.FillRectangle(headerBackgroundBrush, 0, 0, Width, topBarHeight);

            e.Graphics.DrawString("Offset", boldedFont, headerForegroundBrush, 5, 1);
            e.Graphics.DrawString("Instruction", boldedFont, headerForegroundBrush, (Width - 50f) / 2 + 30f, 1);
        }
    }
}
