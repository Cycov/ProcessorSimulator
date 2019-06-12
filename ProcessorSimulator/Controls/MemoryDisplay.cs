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
    public abstract partial class MemoryDisplay : UserControl
    {
        [Category("Colors")]
        public Color HeaderBackground { get; set; } = Color.LightBlue;
        [Category("Colors")]
        public Color HeaderForeground { get; set; } = Color.Black;
        [Category("Colors")]
        public Color OffsetsBackground { get; set; } = Color.LightGray;
        [Category("Colors")]
        public Color OffsetsForeground { get; set; } = Color.Black;
        [Category("Colors")]
        public Color ValueSelected
        {
            get => valueSelected;
            set
            {
                valueSelectedBrush.Dispose();
                valueSelectedBrush = new SolidBrush(value);
                valueSelected = value;
                Invalidate();
            }
        }
        [Category("Colors")]
        public Color ValuesBackground { get; set; } = DefaultBackColor;
        [Category("Colors")]
        public Color ValuesForeground
        {
            get => valuesForeground;
            set
            {
                valuesForegroundBrush.Dispose();
                valuesForegroundBrush = new SolidBrush(value);
                valuesForeground = value;
                Invalidate();
            }
        }
        private Color valuesForeground = Color.BlueViolet;

        public int BytesPerLine
        {
            get => _bytesPerLine;
            set
            {
                _bytesPerLine = (value % 2 == 0) ? value : throw new ArgumentException("Please use a even size");
            }
        }
        private int _bytesPerLine = 2;

        public ushort SelectedOffset { get; set; }


        //Drawing stuff
        protected readonly int leftRectangleWidth = 50, topBarHeight = 14, lineHeight = 14, valueXMin = 60, drawnByteLength = 50;
        protected Font boldedFont;
        protected int maxLines;
        protected SolidBrush headerBackgroundBrush, headerForegroundBrush, offsetsBackgroundBrush, offsetsForegroundBrush, valueSelectedBrush, valuesForegroundBrush;

        //Memory stuff
        protected Memory memory;
        protected int offset;
        protected ushort segment, size = ushort.MaxValue;
        protected int baseOffset;   //Left top most offset
        private Color valueSelected = Color.Red;

        public MemoryDisplay()
        {
            InitializeComponent();
            Size = new Size(125, 375);
            boldedFont = new Font(this.Font, FontStyle.Bold);
            maxLines = Height / lineHeight;

            headerBackgroundBrush = new SolidBrush(HeaderBackground);
            headerForegroundBrush = new SolidBrush(HeaderForeground);
            offsetsBackgroundBrush = new SolidBrush(OffsetsBackground);
            offsetsForegroundBrush = new SolidBrush(OffsetsForeground);
            valuesForegroundBrush = new SolidBrush(ValuesForeground);
            valueSelectedBrush = new SolidBrush(valueSelected);
            BackColor = ValuesBackground;

            DoubleBuffered = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">Max size of 1048576</param>
        public virtual void Init(Memory memory, Register segmentRegister)
        {
            this.segment = segmentRegister.Value;
            this.memory = memory;
            this.memory.MemoryModified += Memory_OnMemoryModified;
            this.vScrollBar.Maximum = size / _bytesPerLine + 2;
            maxLines = Height / lineHeight;
            if ((segment << 4) + size > memory.Size)
                size = (ushort)((memory.Size - (segment << 4)) % ushort.MaxValue);

            headerBackgroundBrush.Dispose();
            headerForegroundBrush.Dispose();
            offsetsBackgroundBrush.Dispose();
            offsetsForegroundBrush.Dispose();
            valuesForegroundBrush.Dispose();
            valueSelectedBrush.Dispose();

            headerBackgroundBrush = new SolidBrush(HeaderBackground);
            headerForegroundBrush = new SolidBrush(HeaderForeground);
            offsetsBackgroundBrush = new SolidBrush(OffsetsBackground);
            offsetsForegroundBrush = new SolidBrush(OffsetsForeground);
            valuesForegroundBrush = new SolidBrush(ValuesForeground);
            valueSelectedBrush = new SolidBrush(ValueSelected);
            BackColor = ValuesBackground;
        }

        private void Memory_OnMemoryModified(object sender, MemoryModifiedEventArgs e)
        {
            Invalidate();
        }

        private void MemoryDisplay_Click(object sender, EventArgs e)
        {
            MouseEventArgs arg = e as MouseEventArgs;

            if (arg.Y < topBarHeight)
                return;
            if (arg.X < valueXMin)
            {
                JumpToAdress jumpBox = new JumpToAdress(segment, 0);
                if (jumpBox.ShowDialog() == DialogResult.OK)
                {
                    segment = jumpBox.Segment;
                    vScrollBar.Value = jumpBox.Offset / BytesPerLine;
                    SelectedOffset = jumpBox.Offset;
                }
            }
            else
            {
                int x = arg.X - valueXMin;
                x /= drawnByteLength;

                int y = arg.Y - topBarHeight;
                y /= lineHeight;

                int offset = baseOffset + y * _bytesPerLine + (x * 2);
                if (offset % 2 == 1)
                    offset++;
                if (offset < size)
                    SelectedOffset = (ushort)offset;
            }
            Invalidate();
        }

        private void MemoryDisplay_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs arg = e as MouseEventArgs;
            if (arg.X < valueXMin || arg.Y < topBarHeight)
                return;
            NumericalValueEditor valueEditor = new NumericalValueEditor(memory.GetWord(segment, SelectedOffset));
            valueEditor.Text = "0x" + segment.ToString("X4") + " : 0x" + SelectedOffset.ToString("X4");
            if (valueEditor.ShowDialog() == DialogResult.OK)
                memory.SetWord(segment, SelectedOffset, valueEditor.Value);
        }


        private void MemoryDisplay_Scroll(object sender, ScrollEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.LightGray, 0, 0, Width - 1, Height - 1);
            e.Graphics.FillRectangle(offsetsBackgroundBrush, 0, 0, leftRectangleWidth, Height);
            e.Graphics.FillRectangle(headerBackgroundBrush, 0, 0, Width, topBarHeight);

            e.Graphics.DrawString("Offset", boldedFont, headerForegroundBrush, 5, 1);
            e.Graphics.DrawString("Value", boldedFont, headerForegroundBrush, (Width - 50f) / 2 + 30f, 1);

            if (memory == null) //just for the designer
            {
                int offset = 0;
                for (int i = 1; i <= maxLines; i++, offset += _bytesPerLine)
                {
                    //Draw line number
                    e.Graphics.DrawString("0x" + offset.ToString("X4"), Font, offsetsForegroundBrush, 2, i * lineHeight);
                    e.Graphics.DrawString("0xFFFF", boldedFont, offsetsForegroundBrush, valueXMin, i * lineHeight);
                    //Draw values
                    for (int j = 0; j < _bytesPerLine / 2; j++)
                    {
                        e.Graphics.DrawString("0xFFFF", boldedFont, valuesForegroundBrush, valueXMin + drawnByteLength * j, i * lineHeight);
                    }
                }

            }
            else
            {
                baseOffset = vScrollBar.Value * BytesPerLine;
                int lines = size - baseOffset;
                if (lines > maxLines)
                    lines = maxLines;
                for (int i = 1; i <= lines; i++)
                {
                    offset = baseOffset + BytesPerLine * (i - 1);
                    if (offset >= size)
                        break;
                    //Draw line number
                    e.Graphics.DrawString("0x" + offset.ToString("X4"), Font, offsetsForegroundBrush, 2, i * lineHeight);

                    //Draw values
                    for (int j = 0, k = 0; j < BytesPerLine; j += 2, k++)
                    {
                        if (offset >= size)
                            break;
                        if (offset == SelectedOffset)
                            e.Graphics.FillRectangle(valueSelectedBrush, valueXMin + drawnByteLength * k, i * lineHeight, drawnByteLength, lineHeight);
                        e.Graphics.DrawString("0x" + memory.GetWord((segment << 4) + offset).ToString("X4"), boldedFont, valuesForegroundBrush, valueXMin + drawnByteLength * k, i * lineHeight);
                        offset += 2;
                    }
                }
            }
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        protected virtual new void Dispose()
        {
            headerBackgroundBrush.Dispose();
            headerForegroundBrush.Dispose();
            offsetsBackgroundBrush.Dispose();
            offsetsForegroundBrush.Dispose();
            valuesForegroundBrush.Dispose();
            valueSelectedBrush.Dispose();
            base.Dispose();
        }
    }
}
