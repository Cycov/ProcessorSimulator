namespace ProcessorSimulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.testBtn = new System.Windows.Forms.Button();
            this.aluDisplayPanel = new System.Windows.Forms.Panel();
            this.registersGroupBox = new System.Windows.Forms.GroupBox();
            this.register14 = new ProcessorSimulator.Controls.Register();
            this.register15 = new ProcessorSimulator.Controls.Register();
            this.register13 = new ProcessorSimulator.Controls.Register();
            this.register12 = new ProcessorSimulator.Controls.Register();
            this.register7 = new ProcessorSimulator.Controls.Register();
            this.register6 = new ProcessorSimulator.Controls.Register();
            this.register5 = new ProcessorSimulator.Controls.Register();
            this.register4 = new ProcessorSimulator.Controls.Register();
            this.register3 = new ProcessorSimulator.Controls.Register();
            this.register2 = new ProcessorSimulator.Controls.Register();
            this.register1 = new ProcessorSimulator.Controls.Register();
            this.register11 = new ProcessorSimulator.Controls.Register();
            this.register0 = new ProcessorSimulator.Controls.Register();
            this.register10 = new ProcessorSimulator.Controls.Register();
            this.register9 = new ProcessorSimulator.Controls.Register();
            this.register8 = new ProcessorSimulator.Controls.Register();
            this.memorySegmentDisplay1 = new ProcessorSimulator.Controls.MemorySegmentDisplay();
            this.PCRegisterPanel = new System.Windows.Forms.Panel();
            this.registerPC = new ProcessorSimulator.Controls.Register();
            this.TRegisterPanel = new System.Windows.Forms.Panel();
            this.registerT = new ProcessorSimulator.Controls.Register();
            this.SPRegisterPanel = new System.Windows.Forms.Panel();
            this.registerSP = new ProcessorSimulator.Controls.Register();
            this.IRRegisterPanel = new System.Windows.Forms.Panel();
            this.registerIR = new ProcessorSimulator.Controls.Register();
            this.IVRRegisterPanel = new System.Windows.Forms.Panel();
            this.registerIVR = new ProcessorSimulator.Controls.Register();
            this.FLAGSRegister = new ProcessorSimulator.Controls.Flags.FlagsRegister();
            this.FLAGSRegisterPanel = new System.Windows.Forms.Panel();
            this.ADRRegisterPanel = new System.Windows.Forms.Panel();
            this.registerADR = new ProcessorSimulator.Controls.Register();
            this.MDRRegisterPanel = new System.Windows.Forms.Panel();
            this.registerMDR = new ProcessorSimulator.Controls.Register();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assemblerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexadecimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.RegisterMAR = new ProcessorSimulator.Controls.Register();
            this.MIRRegisterPanel = new System.Windows.Forms.Panel();
            this.RegisterMIR = new ProcessorSimulator.Controls.MIRRegister();
            this.otherOperationsSourcePanel = new System.Windows.Forms.Panel();
            this.VirtualRegRBUS = new ProcessorSimulator.Controls.Register();
            this.VirtualRegDBUS = new ProcessorSimulator.Controls.Register();
            this.VirtualRegSBUS = new ProcessorSimulator.Controls.Register();
            this.previousActivatedCommandsListBox = new System.Windows.Forms.ListBox();
            this.runTimer = new System.Windows.Forms.Timer(this.components);
            this.registersGroupBox.SuspendLayout();
            this.PCRegisterPanel.SuspendLayout();
            this.TRegisterPanel.SuspendLayout();
            this.SPRegisterPanel.SuspendLayout();
            this.IRRegisterPanel.SuspendLayout();
            this.IVRRegisterPanel.SuspendLayout();
            this.FLAGSRegisterPanel.SuspendLayout();
            this.ADRRegisterPanel.SuspendLayout();
            this.MDRRegisterPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.MIRRegisterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(75, 41);
            this.testBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(163, 37);
            this.testBtn.TabIndex = 0;
            this.testBtn.Text = "Press me!";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Visible = false;
            this.testBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // aluDisplayPanel
            // 
            this.aluDisplayPanel.Location = new System.Drawing.Point(1332, 122);
            this.aluDisplayPanel.Margin = new System.Windows.Forms.Padding(4);
            this.aluDisplayPanel.Name = "aluDisplayPanel";
            this.aluDisplayPanel.Size = new System.Drawing.Size(252, 218);
            this.aluDisplayPanel.TabIndex = 17;
            this.aluDisplayPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AluDisplayPanel_Paint);
            // 
            // registersGroupBox
            // 
            this.registersGroupBox.Controls.Add(this.register14);
            this.registersGroupBox.Controls.Add(this.register15);
            this.registersGroupBox.Controls.Add(this.register13);
            this.registersGroupBox.Controls.Add(this.register12);
            this.registersGroupBox.Controls.Add(this.register7);
            this.registersGroupBox.Controls.Add(this.register6);
            this.registersGroupBox.Controls.Add(this.register5);
            this.registersGroupBox.Controls.Add(this.register4);
            this.registersGroupBox.Controls.Add(this.register3);
            this.registersGroupBox.Controls.Add(this.register2);
            this.registersGroupBox.Controls.Add(this.register1);
            this.registersGroupBox.Controls.Add(this.register11);
            this.registersGroupBox.Controls.Add(this.register0);
            this.registersGroupBox.Controls.Add(this.register10);
            this.registersGroupBox.Controls.Add(this.register9);
            this.registersGroupBox.Controls.Add(this.register8);
            this.registersGroupBox.Location = new System.Drawing.Point(1096, 146);
            this.registersGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.registersGroupBox.Name = "registersGroupBox";
            this.registersGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.registersGroupBox.Size = new System.Drawing.Size(217, 133);
            this.registersGroupBox.TabIndex = 18;
            this.registersGroupBox.TabStop = false;
            this.registersGroupBox.Text = "Registers";
            // 
            // register14
            // 
            this.register14.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register14.Extended = false;
            this.register14.High = ((byte)(0));
            this.register14.Location = new System.Drawing.Point(109, 111);
            this.register14.Low = ((byte)(0));
            this.register14.Margin = new System.Windows.Forms.Padding(5);
            this.register14.Name = "register14";
            this.register14.Readonly = false;
            this.register14.RegisterName = "R15";
            this.register14.Size = new System.Drawing.Size(100, 17);
            this.register14.TabIndex = 38;
            this.register14.Value = ((ushort)(0));
            // 
            // register15
            // 
            this.register15.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register15.Extended = false;
            this.register15.High = ((byte)(0));
            this.register15.Location = new System.Drawing.Point(109, 97);
            this.register15.Low = ((byte)(0));
            this.register15.Margin = new System.Windows.Forms.Padding(5);
            this.register15.Name = "register15";
            this.register15.Readonly = false;
            this.register15.RegisterName = "R14";
            this.register15.Size = new System.Drawing.Size(100, 17);
            this.register15.TabIndex = 38;
            this.register15.Value = ((ushort)(0));
            // 
            // register13
            // 
            this.register13.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register13.Extended = false;
            this.register13.High = ((byte)(0));
            this.register13.Location = new System.Drawing.Point(109, 84);
            this.register13.Low = ((byte)(0));
            this.register13.Margin = new System.Windows.Forms.Padding(5);
            this.register13.Name = "register13";
            this.register13.Readonly = false;
            this.register13.RegisterName = "R13";
            this.register13.Size = new System.Drawing.Size(100, 17);
            this.register13.TabIndex = 37;
            this.register13.Value = ((ushort)(0));
            // 
            // register12
            // 
            this.register12.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register12.Extended = false;
            this.register12.High = ((byte)(0));
            this.register12.Location = new System.Drawing.Point(109, 70);
            this.register12.Low = ((byte)(0));
            this.register12.Margin = new System.Windows.Forms.Padding(5);
            this.register12.Name = "register12";
            this.register12.Readonly = false;
            this.register12.RegisterName = "R12";
            this.register12.Size = new System.Drawing.Size(100, 17);
            this.register12.TabIndex = 36;
            this.register12.Value = ((ushort)(0));
            // 
            // register7
            // 
            this.register7.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register7.Extended = false;
            this.register7.High = ((byte)(0));
            this.register7.Location = new System.Drawing.Point(1, 111);
            this.register7.Low = ((byte)(0));
            this.register7.Margin = new System.Windows.Forms.Padding(5);
            this.register7.Name = "register7";
            this.register7.Readonly = false;
            this.register7.RegisterName = "R7";
            this.register7.Size = new System.Drawing.Size(100, 17);
            this.register7.TabIndex = 32;
            this.register7.Value = ((ushort)(0));
            // 
            // register6
            // 
            this.register6.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register6.Extended = false;
            this.register6.High = ((byte)(0));
            this.register6.Location = new System.Drawing.Point(1, 97);
            this.register6.Low = ((byte)(0));
            this.register6.Margin = new System.Windows.Forms.Padding(5);
            this.register6.Name = "register6";
            this.register6.Readonly = false;
            this.register6.RegisterName = "R6";
            this.register6.Size = new System.Drawing.Size(100, 17);
            this.register6.TabIndex = 31;
            this.register6.Value = ((ushort)(0));
            // 
            // register5
            // 
            this.register5.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register5.Extended = false;
            this.register5.High = ((byte)(0));
            this.register5.Location = new System.Drawing.Point(1, 84);
            this.register5.Low = ((byte)(0));
            this.register5.Margin = new System.Windows.Forms.Padding(5);
            this.register5.Name = "register5";
            this.register5.Readonly = false;
            this.register5.RegisterName = "R5";
            this.register5.Size = new System.Drawing.Size(100, 17);
            this.register5.TabIndex = 30;
            this.register5.Value = ((ushort)(0));
            // 
            // register4
            // 
            this.register4.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register4.Extended = false;
            this.register4.High = ((byte)(0));
            this.register4.Location = new System.Drawing.Point(1, 70);
            this.register4.Low = ((byte)(0));
            this.register4.Margin = new System.Windows.Forms.Padding(5);
            this.register4.Name = "register4";
            this.register4.Readonly = false;
            this.register4.RegisterName = "R4";
            this.register4.Size = new System.Drawing.Size(100, 17);
            this.register4.TabIndex = 29;
            this.register4.Value = ((ushort)(0));
            // 
            // register3
            // 
            this.register3.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register3.Extended = false;
            this.register3.High = ((byte)(250));
            this.register3.Location = new System.Drawing.Point(1, 57);
            this.register3.Low = ((byte)(199));
            this.register3.Margin = new System.Windows.Forms.Padding(5);
            this.register3.Name = "register3";
            this.register3.Readonly = false;
            this.register3.RegisterName = "R3";
            this.register3.Size = new System.Drawing.Size(100, 17);
            this.register3.TabIndex = 28;
            this.register3.Value = ((ushort)(64199));
            // 
            // register2
            // 
            this.register2.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register2.Extended = false;
            this.register2.High = ((byte)(5));
            this.register2.Location = new System.Drawing.Point(1, 43);
            this.register2.Low = ((byte)(148));
            this.register2.Margin = new System.Windows.Forms.Padding(5);
            this.register2.Name = "register2";
            this.register2.Readonly = false;
            this.register2.RegisterName = "R2";
            this.register2.Size = new System.Drawing.Size(100, 17);
            this.register2.TabIndex = 27;
            this.register2.Value = ((ushort)(1428));
            // 
            // register1
            // 
            this.register1.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register1.Extended = false;
            this.register1.High = ((byte)(0));
            this.register1.Location = new System.Drawing.Point(1, 30);
            this.register1.Low = ((byte)(0));
            this.register1.Margin = new System.Windows.Forms.Padding(5);
            this.register1.Name = "register1";
            this.register1.Readonly = false;
            this.register1.RegisterName = "R1";
            this.register1.Size = new System.Drawing.Size(100, 17);
            this.register1.TabIndex = 26;
            this.register1.Value = ((ushort)(0));
            // 
            // register11
            // 
            this.register11.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register11.Extended = false;
            this.register11.High = ((byte)(0));
            this.register11.Location = new System.Drawing.Point(109, 57);
            this.register11.Low = ((byte)(0));
            this.register11.Margin = new System.Windows.Forms.Padding(5);
            this.register11.Name = "register11";
            this.register11.Readonly = false;
            this.register11.RegisterName = "R11";
            this.register11.Size = new System.Drawing.Size(100, 17);
            this.register11.TabIndex = 35;
            this.register11.Value = ((ushort)(0));
            // 
            // register0
            // 
            this.register0.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register0.Extended = false;
            this.register0.High = ((byte)(0));
            this.register0.Location = new System.Drawing.Point(1, 16);
            this.register0.Low = ((byte)(83));
            this.register0.Margin = new System.Windows.Forms.Padding(5);
            this.register0.Name = "register0";
            this.register0.Readonly = false;
            this.register0.RegisterName = "R0";
            this.register0.Size = new System.Drawing.Size(100, 17);
            this.register0.TabIndex = 25;
            this.register0.Value = ((ushort)(83));
            // 
            // register10
            // 
            this.register10.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register10.Extended = false;
            this.register10.High = ((byte)(0));
            this.register10.Location = new System.Drawing.Point(109, 43);
            this.register10.Low = ((byte)(0));
            this.register10.Margin = new System.Windows.Forms.Padding(5);
            this.register10.Name = "register10";
            this.register10.Readonly = false;
            this.register10.RegisterName = "R10";
            this.register10.Size = new System.Drawing.Size(100, 17);
            this.register10.TabIndex = 34;
            this.register10.Value = ((ushort)(0));
            // 
            // register9
            // 
            this.register9.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register9.Extended = false;
            this.register9.High = ((byte)(0));
            this.register9.Location = new System.Drawing.Point(109, 30);
            this.register9.Low = ((byte)(0));
            this.register9.Margin = new System.Windows.Forms.Padding(5);
            this.register9.Name = "register9";
            this.register9.Readonly = false;
            this.register9.RegisterName = "R9";
            this.register9.Size = new System.Drawing.Size(100, 17);
            this.register9.TabIndex = 33;
            this.register9.Value = ((ushort)(0));
            // 
            // register8
            // 
            this.register8.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.register8.Extended = false;
            this.register8.High = ((byte)(0));
            this.register8.Location = new System.Drawing.Point(109, 16);
            this.register8.Low = ((byte)(0));
            this.register8.Margin = new System.Windows.Forms.Padding(5);
            this.register8.Name = "register8";
            this.register8.Readonly = false;
            this.register8.RegisterName = "R8";
            this.register8.Size = new System.Drawing.Size(100, 17);
            this.register8.TabIndex = 32;
            this.register8.Value = ((ushort)(0));
            // 
            // memorySegmentDisplay1
            // 
            this.memorySegmentDisplay1.AutoScroll = true;
            this.memorySegmentDisplay1.BackColor = System.Drawing.SystemColors.Control;
            this.memorySegmentDisplay1.BytesPerLine = 16;
            this.memorySegmentDisplay1.HeaderBackground = System.Drawing.Color.LightBlue;
            this.memorySegmentDisplay1.HeaderForeground = System.Drawing.Color.Black;
            this.memorySegmentDisplay1.Location = new System.Drawing.Point(188, 514);
            this.memorySegmentDisplay1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memorySegmentDisplay1.Name = "memorySegmentDisplay1";
            this.memorySegmentDisplay1.OffsetsBackground = System.Drawing.Color.LightGray;
            this.memorySegmentDisplay1.OffsetsForeground = System.Drawing.Color.Black;
            this.memorySegmentDisplay1.SelectedOffset = ((ushort)(0));
            this.memorySegmentDisplay1.Size = new System.Drawing.Size(639, 139);
            this.memorySegmentDisplay1.TabIndex = 19;
            this.memorySegmentDisplay1.ValuesBackground = System.Drawing.SystemColors.Control;
            this.memorySegmentDisplay1.ValueSelected = System.Drawing.Color.Red;
            this.memorySegmentDisplay1.ValuesForeground = System.Drawing.Color.BlueViolet;
            // 
            // PCRegisterPanel
            // 
            this.PCRegisterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PCRegisterPanel.Controls.Add(this.registerPC);
            this.PCRegisterPanel.Location = new System.Drawing.Point(660, 183);
            this.PCRegisterPanel.Margin = new System.Windows.Forms.Padding(4);
            this.PCRegisterPanel.Name = "PCRegisterPanel";
            this.PCRegisterPanel.Size = new System.Drawing.Size(131, 43);
            this.PCRegisterPanel.TabIndex = 21;
            // 
            // registerPC
            // 
            this.registerPC.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.registerPC.Extended = false;
            this.registerPC.High = ((byte)(0));
            this.registerPC.Location = new System.Drawing.Point(4, 11);
            this.registerPC.Low = ((byte)(0));
            this.registerPC.Margin = new System.Windows.Forms.Padding(5);
            this.registerPC.Name = "registerPC";
            this.registerPC.Readonly = false;
            this.registerPC.RegisterName = "PC";
            this.registerPC.Size = new System.Drawing.Size(100, 17);
            this.registerPC.TabIndex = 0;
            this.registerPC.Value = ((ushort)(0));
            // 
            // TRegisterPanel
            // 
            this.TRegisterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TRegisterPanel.Controls.Add(this.registerT);
            this.TRegisterPanel.Location = new System.Drawing.Point(511, 183);
            this.TRegisterPanel.Margin = new System.Windows.Forms.Padding(4);
            this.TRegisterPanel.Name = "TRegisterPanel";
            this.TRegisterPanel.Size = new System.Drawing.Size(135, 43);
            this.TRegisterPanel.TabIndex = 21;
            // 
            // registerT
            // 
            this.registerT.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.registerT.Extended = false;
            this.registerT.High = ((byte)(0));
            this.registerT.Location = new System.Drawing.Point(4, 11);
            this.registerT.Low = ((byte)(0));
            this.registerT.Margin = new System.Windows.Forms.Padding(5);
            this.registerT.Name = "registerT";
            this.registerT.Readonly = false;
            this.registerT.RegisterName = "T";
            this.registerT.Size = new System.Drawing.Size(100, 17);
            this.registerT.TabIndex = 0;
            this.registerT.Value = ((ushort)(0));
            // 
            // SPRegisterPanel
            // 
            this.SPRegisterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SPRegisterPanel.Controls.Add(this.registerSP);
            this.SPRegisterPanel.Location = new System.Drawing.Point(243, 183);
            this.SPRegisterPanel.Margin = new System.Windows.Forms.Padding(4);
            this.SPRegisterPanel.Name = "SPRegisterPanel";
            this.SPRegisterPanel.Size = new System.Drawing.Size(135, 43);
            this.SPRegisterPanel.TabIndex = 21;
            // 
            // registerSP
            // 
            this.registerSP.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.registerSP.Extended = false;
            this.registerSP.High = ((byte)(64));
            this.registerSP.Location = new System.Drawing.Point(4, 11);
            this.registerSP.Low = ((byte)(0));
            this.registerSP.Margin = new System.Windows.Forms.Padding(5);
            this.registerSP.Name = "registerSP";
            this.registerSP.Readonly = false;
            this.registerSP.RegisterName = "SP";
            this.registerSP.Size = new System.Drawing.Size(100, 17);
            this.registerSP.TabIndex = 0;
            this.registerSP.Value = ((ushort)(16384));
            // 
            // IRRegisterPanel
            // 
            this.IRRegisterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.IRRegisterPanel.Controls.Add(this.registerIR);
            this.IRRegisterPanel.Location = new System.Drawing.Point(75, 704);
            this.IRRegisterPanel.Margin = new System.Windows.Forms.Padding(4);
            this.IRRegisterPanel.Name = "IRRegisterPanel";
            this.IRRegisterPanel.Size = new System.Drawing.Size(208, 43);
            this.IRRegisterPanel.TabIndex = 21;
            // 
            // registerIR
            // 
            this.registerIR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.registerIR.Extended = false;
            this.registerIR.High = ((byte)(0));
            this.registerIR.Location = new System.Drawing.Point(4, 11);
            this.registerIR.Low = ((byte)(0));
            this.registerIR.Margin = new System.Windows.Forms.Padding(5);
            this.registerIR.Name = "registerIR";
            this.registerIR.Readonly = false;
            this.registerIR.RegisterName = "IR";
            this.registerIR.Size = new System.Drawing.Size(184, 17);
            this.registerIR.TabIndex = 0;
            this.registerIR.Value = ((ushort)(0));
            // 
            // IVRRegisterPanel
            // 
            this.IVRRegisterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.IVRRegisterPanel.Controls.Add(this.registerIVR);
            this.IVRRegisterPanel.Location = new System.Drawing.Point(800, 183);
            this.IVRRegisterPanel.Margin = new System.Windows.Forms.Padding(4);
            this.IVRRegisterPanel.Name = "IVRRegisterPanel";
            this.IVRRegisterPanel.Size = new System.Drawing.Size(135, 43);
            this.IVRRegisterPanel.TabIndex = 21;
            // 
            // registerIVR
            // 
            this.registerIVR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.registerIVR.Extended = false;
            this.registerIVR.High = ((byte)(0));
            this.registerIVR.Location = new System.Drawing.Point(4, 11);
            this.registerIVR.Low = ((byte)(0));
            this.registerIVR.Margin = new System.Windows.Forms.Padding(5);
            this.registerIVR.Name = "registerIVR";
            this.registerIVR.Readonly = false;
            this.registerIVR.RegisterName = "IVR";
            this.registerIVR.Size = new System.Drawing.Size(100, 17);
            this.registerIVR.TabIndex = 0;
            this.registerIVR.Value = ((ushort)(0));
            // 
            // FLAGSRegister
            // 
            this.FLAGSRegister.Location = new System.Drawing.Point(4, 4);
            this.FLAGSRegister.Margin = new System.Windows.Forms.Padding(5);
            this.FLAGSRegister.Name = "FLAGSRegister";
            this.FLAGSRegister.Size = new System.Drawing.Size(133, 123);
            this.FLAGSRegister.TabIndex = 22;
            this.FLAGSRegister.Value = ((ushort)(0));
            // 
            // FLAGSRegisterPanel
            // 
            this.FLAGSRegisterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FLAGSRegisterPanel.Controls.Add(this.FLAGSRegister);
            this.FLAGSRegisterPanel.Location = new System.Drawing.Point(944, 146);
            this.FLAGSRegisterPanel.Margin = new System.Windows.Forms.Padding(4);
            this.FLAGSRegisterPanel.Name = "FLAGSRegisterPanel";
            this.FLAGSRegisterPanel.Size = new System.Drawing.Size(143, 142);
            this.FLAGSRegisterPanel.TabIndex = 23;
            // 
            // ADRRegisterPanel
            // 
            this.ADRRegisterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ADRRegisterPanel.Controls.Add(this.registerADR);
            this.ADRRegisterPanel.Location = new System.Drawing.Point(387, 183);
            this.ADRRegisterPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ADRRegisterPanel.Name = "ADRRegisterPanel";
            this.ADRRegisterPanel.Size = new System.Drawing.Size(115, 43);
            this.ADRRegisterPanel.TabIndex = 24;
            // 
            // registerADR
            // 
            this.registerADR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.registerADR.Extended = false;
            this.registerADR.High = ((byte)(0));
            this.registerADR.Location = new System.Drawing.Point(7, 11);
            this.registerADR.Low = ((byte)(0));
            this.registerADR.Margin = new System.Windows.Forms.Padding(5);
            this.registerADR.Name = "registerADR";
            this.registerADR.Readonly = false;
            this.registerADR.RegisterName = "ADR";
            this.registerADR.Size = new System.Drawing.Size(100, 17);
            this.registerADR.TabIndex = 0;
            this.registerADR.Value = ((ushort)(0));
            // 
            // MDRRegisterPanel
            // 
            this.MDRRegisterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MDRRegisterPanel.Controls.Add(this.registerMDR);
            this.MDRRegisterPanel.Location = new System.Drawing.Point(95, 183);
            this.MDRRegisterPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MDRRegisterPanel.Name = "MDRRegisterPanel";
            this.MDRRegisterPanel.Size = new System.Drawing.Size(139, 43);
            this.MDRRegisterPanel.TabIndex = 24;
            // 
            // registerMDR
            // 
            this.registerMDR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.registerMDR.Extended = true;
            this.registerMDR.High = ((byte)(0));
            this.registerMDR.Location = new System.Drawing.Point(3, 11);
            this.registerMDR.Low = ((byte)(0));
            this.registerMDR.Margin = new System.Windows.Forms.Padding(5);
            this.registerMDR.Name = "registerMDR";
            this.registerMDR.Readonly = false;
            this.registerMDR.RegisterName = "MDR";
            this.registerMDR.Size = new System.Drawing.Size(128, 17);
            this.registerMDR.TabIndex = 0;
            this.registerMDR.Value = ((ushort)(0));
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.simulationToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.assemblerToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1747, 28);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.reloadToolStripMenuItem.Text = "&Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stepToolStripMenuItem});
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.simulationToolStripMenuItem.Text = "&Simulation";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.runToolStripMenuItem.Text = "&Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.stopToolStripMenuItem.Text = "&Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.pauseToolStripMenuItem.Text = "&Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.PauseSimulation);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.stepToolStripMenuItem.Text = "S&tep";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.StepToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flagsToolStripMenuItem,
            this.registersToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.allToolStripMenuItem});
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.resetToolStripMenuItem.Text = "&Reset";
            // 
            // flagsToolStripMenuItem
            // 
            this.flagsToolStripMenuItem.Name = "flagsToolStripMenuItem";
            this.flagsToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.flagsToolStripMenuItem.Text = "&Flags";
            this.flagsToolStripMenuItem.Click += new System.EventHandler(this.ClearFlags);
            // 
            // registersToolStripMenuItem
            // 
            this.registersToolStripMenuItem.Name = "registersToolStripMenuItem";
            this.registersToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.registersToolStripMenuItem.Text = "&Registers";
            this.registersToolStripMenuItem.Click += new System.EventHandler(this.ClearRegisters);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.dataToolStripMenuItem.Text = "&Data";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.ClearData);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.allToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.allToolStripMenuItem.Text = "&All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.ClearAll);
            // 
            // assemblerToolStripMenuItem
            // 
            this.assemblerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toFileToolStripMenuItem});
            this.assemblerToolStripMenuItem.Name = "assemblerToolStripMenuItem";
            this.assemblerToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.assemblerToolStripMenuItem.Text = "&Assembler";
            // 
            // toFileToolStripMenuItem
            // 
            this.toFileToolStripMenuItem.Name = "toFileToolStripMenuItem";
            this.toFileToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.toFileToolStripMenuItem.Text = "&To file";
            this.toFileToolStripMenuItem.Click += new System.EventHandler(this.ToFileToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registersToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // registersToolStripMenuItem1
            // 
            this.registersToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binaryToolStripMenuItem,
            this.decimalToolStripMenuItem,
            this.hexadecimalToolStripMenuItem});
            this.registersToolStripMenuItem1.Name = "registersToolStripMenuItem1";
            this.registersToolStripMenuItem1.Size = new System.Drawing.Size(152, 26);
            this.registersToolStripMenuItem1.Text = "&Registers";
            // 
            // binaryToolStripMenuItem
            // 
            this.binaryToolStripMenuItem.Name = "binaryToolStripMenuItem";
            this.binaryToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.binaryToolStripMenuItem.Text = "&Binary";
            this.binaryToolStripMenuItem.Click += new System.EventHandler(this.BinaryToolStripMenuItem_Click);
            // 
            // decimalToolStripMenuItem
            // 
            this.decimalToolStripMenuItem.Name = "decimalToolStripMenuItem";
            this.decimalToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.decimalToolStripMenuItem.Text = "&Decimal";
            this.decimalToolStripMenuItem.Click += new System.EventHandler(this.DecimalToolStripMenuItem_Click);
            // 
            // hexadecimalToolStripMenuItem
            // 
            this.hexadecimalToolStripMenuItem.Checked = true;
            this.hexadecimalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hexadecimalToolStripMenuItem.Name = "hexadecimalToolStripMenuItem";
            this.hexadecimalToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.hexadecimalToolStripMenuItem.Text = "&Hexadecimal";
            this.hexadecimalToolStripMenuItem.Click += new System.EventHandler(this.HexadecimalToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Assembly files|*.asm|All files|*.*";
            // 
            // RegisterMAR
            // 
            this.RegisterMAR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Decimal;
            this.RegisterMAR.Extended = false;
            this.RegisterMAR.High = ((byte)(0));
            this.RegisterMAR.Location = new System.Drawing.Point(8, 4);
            this.RegisterMAR.Low = ((byte)(0));
            this.RegisterMAR.Margin = new System.Windows.Forms.Padding(5);
            this.RegisterMAR.Name = "RegisterMAR";
            this.RegisterMAR.Readonly = false;
            this.RegisterMAR.RegisterName = "MAR";
            this.RegisterMAR.Size = new System.Drawing.Size(132, 17);
            this.RegisterMAR.TabIndex = 27;
            this.RegisterMAR.Value = ((ushort)(0));
            // 
            // MIRRegisterPanel
            // 
            this.MIRRegisterPanel.Controls.Add(this.RegisterMIR);
            this.MIRRegisterPanel.Controls.Add(this.RegisterMAR);
            this.MIRRegisterPanel.Location = new System.Drawing.Point(1111, 628);
            this.MIRRegisterPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MIRRegisterPanel.Name = "MIRRegisterPanel";
            this.MIRRegisterPanel.Size = new System.Drawing.Size(587, 26);
            this.MIRRegisterPanel.TabIndex = 28;
            // 
            // RegisterMIR
            // 
            this.RegisterMIR.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Binary;
            this.RegisterMIR.Extended = false;
            this.RegisterMIR.High = ((byte)(0));
            this.RegisterMIR.Location = new System.Drawing.Point(148, 5);
            this.RegisterMIR.LongValue = ((ulong)(0ul));
            this.RegisterMIR.Low = ((byte)(0));
            this.RegisterMIR.Margin = new System.Windows.Forms.Padding(5);
            this.RegisterMIR.Name = "RegisterMIR";
            this.RegisterMIR.Readonly = true;
            this.RegisterMIR.RegisterName = "MIR";
            this.RegisterMIR.Size = new System.Drawing.Size(435, 17);
            this.RegisterMIR.TabIndex = 28;
            this.RegisterMIR.Value = ((ushort)(0));
            // 
            // otherOperationsSourcePanel
            // 
            this.otherOperationsSourcePanel.Location = new System.Drawing.Point(1111, 514);
            this.otherOperationsSourcePanel.Margin = new System.Windows.Forms.Padding(4);
            this.otherOperationsSourcePanel.Name = "otherOperationsSourcePanel";
            this.otherOperationsSourcePanel.Size = new System.Drawing.Size(331, 43);
            this.otherOperationsSourcePanel.TabIndex = 29;
            // 
            // VirtualRegRBUS
            // 
            this.VirtualRegRBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.VirtualRegRBUS.Extended = true;
            this.VirtualRegRBUS.High = ((byte)(0));
            this.VirtualRegRBUS.Location = new System.Drawing.Point(1526, 41);
            this.VirtualRegRBUS.Low = ((byte)(0));
            this.VirtualRegRBUS.Margin = new System.Windows.Forms.Padding(5);
            this.VirtualRegRBUS.Name = "VirtualRegRBUS";
            this.VirtualRegRBUS.Readonly = false;
            this.VirtualRegRBUS.RegisterName = "RBUS";
            this.VirtualRegRBUS.Size = new System.Drawing.Size(245, 17);
            this.VirtualRegRBUS.TabIndex = 0;
            this.VirtualRegRBUS.Value = ((ushort)(0));
            // 
            // VirtualRegDBUS
            // 
            this.VirtualRegDBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.VirtualRegDBUS.Extended = true;
            this.VirtualRegDBUS.High = ((byte)(0));
            this.VirtualRegDBUS.Location = new System.Drawing.Point(1526, 349);
            this.VirtualRegDBUS.Low = ((byte)(0));
            this.VirtualRegDBUS.Margin = new System.Windows.Forms.Padding(5);
            this.VirtualRegDBUS.Name = "VirtualRegDBUS";
            this.VirtualRegDBUS.Readonly = false;
            this.VirtualRegDBUS.RegisterName = "DBUS";
            this.VirtualRegDBUS.Size = new System.Drawing.Size(245, 17);
            this.VirtualRegDBUS.TabIndex = 0;
            this.VirtualRegDBUS.Value = ((ushort)(0));
            // 
            // VirtualRegSBUS
            // 
            this.VirtualRegSBUS.DisplayMode = ProcessorSimulator.Controls.Register.RegisterDisplayMode.Hexadecimal;
            this.VirtualRegSBUS.Extended = true;
            this.VirtualRegSBUS.High = ((byte)(0));
            this.VirtualRegSBUS.Location = new System.Drawing.Point(1526, 410);
            this.VirtualRegSBUS.Low = ((byte)(0));
            this.VirtualRegSBUS.Margin = new System.Windows.Forms.Padding(5);
            this.VirtualRegSBUS.Name = "VirtualRegSBUS";
            this.VirtualRegSBUS.Readonly = false;
            this.VirtualRegSBUS.RegisterName = "SBUS";
            this.VirtualRegSBUS.Size = new System.Drawing.Size(245, 17);
            this.VirtualRegSBUS.TabIndex = 0;
            this.VirtualRegSBUS.Value = ((ushort)(0));
            // 
            // previousActivatedCommandsListBox
            // 
            this.previousActivatedCommandsListBox.FormattingEnabled = true;
            this.previousActivatedCommandsListBox.ItemHeight = 16;
            this.previousActivatedCommandsListBox.Location = new System.Drawing.Point(848, 514);
            this.previousActivatedCommandsListBox.Margin = new System.Windows.Forms.Padding(4);
            this.previousActivatedCommandsListBox.Name = "previousActivatedCommandsListBox";
            this.previousActivatedCommandsListBox.Size = new System.Drawing.Size(159, 148);
            this.previousActivatedCommandsListBox.TabIndex = 30;
            // 
            // runTimer
            // 
            this.runTimer.Interval = 200;
            this.runTimer.Tick += new System.EventHandler(this.RunTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1747, 848);
            this.Controls.Add(this.VirtualRegSBUS);
            this.Controls.Add(this.VirtualRegDBUS);
            this.Controls.Add(this.VirtualRegRBUS);
            this.Controls.Add(this.previousActivatedCommandsListBox);
            this.Controls.Add(this.otherOperationsSourcePanel);
            this.Controls.Add(this.MIRRegisterPanel);
            this.Controls.Add(this.MDRRegisterPanel);
            this.Controls.Add(this.ADRRegisterPanel);
            this.Controls.Add(this.FLAGSRegisterPanel);
            this.Controls.Add(this.IRRegisterPanel);
            this.Controls.Add(this.SPRegisterPanel);
            this.Controls.Add(this.TRegisterPanel);
            this.Controls.Add(this.IVRRegisterPanel);
            this.Controls.Add(this.PCRegisterPanel);
            this.Controls.Add(this.memorySegmentDisplay1);
            this.Controls.Add(this.registersGroupBox);
            this.Controls.Add(this.aluDisplayPanel);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.registersGroupBox.ResumeLayout(false);
            this.PCRegisterPanel.ResumeLayout(false);
            this.TRegisterPanel.ResumeLayout(false);
            this.SPRegisterPanel.ResumeLayout(false);
            this.IRRegisterPanel.ResumeLayout(false);
            this.IVRRegisterPanel.ResumeLayout(false);
            this.FLAGSRegisterPanel.ResumeLayout(false);
            this.ADRRegisterPanel.ResumeLayout(false);
            this.MDRRegisterPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MIRRegisterPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Panel aluDisplayPanel;
        private System.Windows.Forms.GroupBox registersGroupBox;
        private Controls.MemorySegmentDisplay memorySegmentDisplay1;
        private System.Windows.Forms.Panel PCRegisterPanel;
        private System.Windows.Forms.Panel TRegisterPanel;
        private System.Windows.Forms.Panel SPRegisterPanel;
        private System.Windows.Forms.Panel IRRegisterPanel;
        private System.Windows.Forms.Panel IVRRegisterPanel;
        private Controls.Flags.FlagsRegister FLAGSRegister;
        private System.Windows.Forms.Panel FLAGSRegisterPanel;
        private System.Windows.Forms.Panel ADRRegisterPanel;
        private Controls.Register registerADR;
        private System.Windows.Forms.Panel MDRRegisterPanel;
        private Controls.Register registerMDR;
        private Controls.Register register0;
        private Controls.Register register14;
        private Controls.Register register15;
        private Controls.Register register13;
        private Controls.Register register12;
        private Controls.Register register7;
        private Controls.Register register6;
        private Controls.Register register5;
        private Controls.Register register4;
        private Controls.Register register3;
        private Controls.Register register2;
        private Controls.Register register1;
        private Controls.Register register11;
        private Controls.Register register10;
        private Controls.Register register9;
        private Controls.Register register8;
        private Controls.Register registerPC;
        private Controls.Register registerT;
        private Controls.Register registerSP;
        private Controls.Register registerIR;
        private Controls.Register registerIVR;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Controls.Register RegisterMAR;
        private System.Windows.Forms.Panel MIRRegisterPanel;
        private Controls.MIRRegister RegisterMIR;
        private System.Windows.Forms.Panel otherOperationsSourcePanel;
        private Controls.Register VirtualRegRBUS;
        private Controls.Register VirtualRegDBUS;
        private Controls.Register VirtualRegSBUS;
        private System.Windows.Forms.ListBox previousActivatedCommandsListBox;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.Timer runTimer;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assemblerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem binaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexadecimalToolStripMenuItem;
    }
}

