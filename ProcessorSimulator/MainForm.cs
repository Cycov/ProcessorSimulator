using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessorSimulator
{
    public partial class MainForm : Form
    {
        Memory mainMemory;
        private string assemblyFileName;

        public MainForm()
        {
            InitializeComponent();
            InitializeRuntimeElements();
            InitializeSeqencer();
            mainMemory = new Memory(131071); // double 65535 because it's represented in bytes not words
            memorySegmentDisplay1.Init(mainMemory, new ProcessorSimulator.Controls.Register());

            DoubleBuffered = true;
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            Step();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawElements(e.Graphics);
            base.OnPaint(e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                assemblyFileName = openFileDialog1.FileName;
                string[] lines = File.ReadAllLines(assemblyFileName);
                var output = (new Assembler.Parser()).Parse(lines);
                mainMemory.SetBlock(0, output);
            }
        }

        private void RunTimer_Tick(object sender, EventArgs e)
        {
            Step();
        }

        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runTimer.Start();
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseSimulation();
            ClearSpecialRegisters();
        }

        private void ClearRegisters(object sender = null, EventArgs e = null)
        {
            for (int i = 0; i < 16; i++)
            {
                SetRegisterValue(i, 0);
            }
            ClearSpecialRegisters();

            DeactivateCommands();
        }

        private void ClearSpecialRegisters(object sender = null, EventArgs e = null)
        {
            registerIR.Value = 0;
            registerIVR.Value = 0;
            RegisterMAR.Value = 0;
            registerMDR.Value = 0;
            RegisterMIR.Value = 0;
            registerPC.Value = 0;
            registerSP.Value = 0;
            registerT.Value = 0;
            VirtualRegDBUS.Value = 0;
            VirtualRegRBUS.Value = 0;
            VirtualRegSBUS.Value = 0;
        }

        private void ClearData(object sender = null, EventArgs e = null)
        {
            mainMemory.Clear();
        }

        private void ClearFlags(object sender = null, EventArgs e = null)
        {
            FLAGSRegister.ClearArithmeticFlags();
        }

        private void ClearAll(object sender = null, EventArgs e = null)
        {
            ClearRegisters();
            ClearFlags();
            ClearData();
        }

        private void PauseSimulation(object sender = null, EventArgs e = null)
        {
            runTimer.Stop();
        }

        private void StepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Step();
        }

        private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(assemblyFileName))
            {
                string[] lines = File.ReadAllLines(assemblyFileName);
                var output = (new Assembler.Parser()).Parse(lines);
                if (MessageBox.Show("Reset all registers?", "Reset",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClearAll();
                }
                else
                {
                    mainMemory.Clear();
                }
                mainMemory.SetBlock(0, output);
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                assemblyFileName = openFileDialog1.FileName;
                string[] lines = File.ReadAllLines(assemblyFileName);
                var output = (new Assembler.Parser()).Parse(lines);
                Memory memory = new Memory(131071);
                memory.SetBlock(0, output);
                File.WriteAllBytes(assemblyFileName + ".bin", memory.GetAllBytes());
            }
        }
    }
}
