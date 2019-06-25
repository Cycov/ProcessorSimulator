//-----------------------------------------------------------------------

// <copyright file="MainForm.cs" author="Circa Dragos">

//     Copyright (c) Circa Dragos. All rights reserved.

// </copyright>

//-----------------------------------------------------------------------

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
        private static readonly int defaultSPValue = 0x4000;

        public MainForm()
        {
            InitializeComponent();
            InitializeRuntimeElements();
            InitializeSeqencer();
            mainMemory = new Memory(131070); // double 65535 because it's represented in bytes not words
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
                try
                {
                    var output = (new Assembler.Parser()).Parse(lines);
                    mainMemory.SetBlock(0, output);
                }
                catch (Assembler.ParseException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            registerSP.Value = (ushort)defaultSPValue;
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

        private void HexadecimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            binaryToolStripMenuItem.Checked = false;
            decimalToolStripMenuItem.Checked = false;
            hexadecimalToolStripMenuItem.Checked = true;

            registerMDR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            registerSP.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            registerADR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            registerT.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            registerPC.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            registerIVR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            registerIR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;

            VirtualRegDBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            VirtualRegSBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            VirtualRegRBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;

            RegisterMAR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
        }

        private void DecimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            binaryToolStripMenuItem.Checked = false;
            decimalToolStripMenuItem.Checked = true;
            hexadecimalToolStripMenuItem.Checked = false;

            registerMDR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;
            registerSP.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;
            registerADR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;
            registerT.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;
            registerPC.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;
            registerIVR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;
            registerIR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;

            VirtualRegDBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;
            VirtualRegSBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;
            VirtualRegRBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;

            RegisterMAR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;
        }

        private void BinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            binaryToolStripMenuItem.Checked = true;
            decimalToolStripMenuItem.Checked = false;
            hexadecimalToolStripMenuItem.Checked = false;

            registerMDR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;
            registerSP.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;
            registerADR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;
            registerT.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;
            registerPC.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;
            registerIVR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;
            registerIR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;

            VirtualRegDBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;
            VirtualRegSBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;
            VirtualRegRBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;

            RegisterMAR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;
        }
    }
}
