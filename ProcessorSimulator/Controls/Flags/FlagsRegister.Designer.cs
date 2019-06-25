//-----------------------------------------------------------------------

// <copyright file="FlagsRegister.Designer.cs" author="Circa Dragos">

//     Copyright (c) Circa Dragos. All rights reserved.

// </copyright>

//-----------------------------------------------------------------------

namespace Simulator.Controls.Flags
{
    partial class FlagsRegister
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.register = new Simulator.Controls.Register();
            this.flagD = new Simulator.Controls.Flags.Flag();
            this.flagO = new Simulator.Controls.Flags.Flag();
            this.flagA = new Simulator.Controls.Flags.Flag();
            this.flagI = new Simulator.Controls.Flags.Flag();
            this.flagT = new Simulator.Controls.Flags.Flag();
            this.flagS = new Simulator.Controls.Flags.Flag();
            this.flagZ = new Simulator.Controls.Flags.Flag();
            this.flagP = new Simulator.Controls.Flags.Flag();
            this.flagC = new Simulator.Controls.Flags.Flag();
            this.SuspendLayout();
            // 
            // register
            // 
            this.register.Extended = true;
            this.register.High = ((byte)(0));
            this.register.Location = new System.Drawing.Point(5, 6);
            this.register.Low = ((byte)(0));
            this.register.Name = "register";
            this.register.Readonly = true;
            this.register.RegisterName = "FLAGS";
            this.register.Size = new System.Drawing.Size(100, 14);
            this.register.TabIndex = 1;
            this.register.Value = ((ushort)(0));
            // 
            // flagD
            // 
            this.flagD.AutoSize = true;
            this.flagD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.flagD.Location = new System.Drawing.Point(51, 52);
            this.flagD.Name = "flagD";
            this.flagD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flagD.Size = new System.Drawing.Size(42, 17);
            this.flagD.TabIndex = 0;
            this.flagD.Text = "DF";
            this.flagD.UseVisualStyleBackColor = true;
            this.flagD.CheckedChanged += new System.EventHandler(this.Flag_CheckedChanged);
            // 
            // flagO
            // 
            this.flagO.AutoSize = true;
            this.flagO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.flagO.Location = new System.Drawing.Point(51, 68);
            this.flagO.Name = "flagO";
            this.flagO.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flagO.Size = new System.Drawing.Size(42, 17);
            this.flagO.TabIndex = 0;
            this.flagO.Text = "OF";
            this.flagO.UseVisualStyleBackColor = true;
            this.flagO.CheckedChanged += new System.EventHandler(this.Flag_CheckedChanged);
            // 
            // flagA
            // 
            this.flagA.AutoSize = true;
            this.flagA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.flagA.Location = new System.Drawing.Point(4, 52);
            this.flagA.Name = "flagA";
            this.flagA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flagA.Size = new System.Drawing.Size(41, 17);
            this.flagA.TabIndex = 0;
            this.flagA.Text = "AF";
            this.flagA.UseVisualStyleBackColor = true;
            this.flagA.CheckedChanged += new System.EventHandler(this.Flag_CheckedChanged);
            // 
            // flagI
            // 
            this.flagI.AutoSize = true;
            this.flagI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.flagI.Location = new System.Drawing.Point(56, 36);
            this.flagI.Name = "flagI";
            this.flagI.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flagI.Size = new System.Drawing.Size(37, 17);
            this.flagI.TabIndex = 0;
            this.flagI.Text = "IF";
            this.flagI.UseVisualStyleBackColor = true;
            this.flagI.CheckedChanged += new System.EventHandler(this.Flag_CheckedChanged);
            // 
            // flagT
            // 
            this.flagT.AutoSize = true;
            this.flagT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.flagT.Location = new System.Drawing.Point(52, 20);
            this.flagT.Name = "flagT";
            this.flagT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flagT.Size = new System.Drawing.Size(41, 17);
            this.flagT.TabIndex = 0;
            this.flagT.Text = "TF";
            this.flagT.UseVisualStyleBackColor = true;
            this.flagT.CheckedChanged += new System.EventHandler(this.Flag_CheckedChanged);
            // 
            // flagS
            // 
            this.flagS.AutoSize = true;
            this.flagS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.flagS.Location = new System.Drawing.Point(4, 84);
            this.flagS.Name = "flagS";
            this.flagS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flagS.Size = new System.Drawing.Size(41, 17);
            this.flagS.TabIndex = 0;
            this.flagS.Text = "SF";
            this.flagS.UseVisualStyleBackColor = true;
            this.flagS.CheckedChanged += new System.EventHandler(this.Flag_CheckedChanged);
            // 
            // flagZ
            // 
            this.flagZ.AutoSize = true;
            this.flagZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.flagZ.Location = new System.Drawing.Point(4, 68);
            this.flagZ.Name = "flagZ";
            this.flagZ.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flagZ.Size = new System.Drawing.Size(41, 17);
            this.flagZ.TabIndex = 0;
            this.flagZ.Text = "ZF";
            this.flagZ.UseVisualStyleBackColor = true;
            this.flagZ.CheckedChanged += new System.EventHandler(this.Flag_CheckedChanged);
            // 
            // flagP
            // 
            this.flagP.AutoSize = true;
            this.flagP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.flagP.Location = new System.Drawing.Point(4, 36);
            this.flagP.Name = "flagP";
            this.flagP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flagP.Size = new System.Drawing.Size(41, 17);
            this.flagP.TabIndex = 0;
            this.flagP.Text = "PF";
            this.flagP.UseVisualStyleBackColor = true;
            this.flagP.CheckedChanged += new System.EventHandler(this.Flag_CheckedChanged);
            // 
            // flagC
            // 
            this.flagC.AutoSize = true;
            this.flagC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.flagC.Location = new System.Drawing.Point(4, 20);
            this.flagC.Name = "flagC";
            this.flagC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flagC.Size = new System.Drawing.Size(41, 17);
            this.flagC.TabIndex = 0;
            this.flagC.Text = "CF";
            this.flagC.UseVisualStyleBackColor = true;
            this.flagC.CheckedChanged += new System.EventHandler(this.Flag_CheckedChanged);
            // 
            // FlagsRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.register);
            this.Controls.Add(this.flagD);
            this.Controls.Add(this.flagO);
            this.Controls.Add(this.flagA);
            this.Controls.Add(this.flagI);
            this.Controls.Add(this.flagT);
            this.Controls.Add(this.flagS);
            this.Controls.Add(this.flagZ);
            this.Controls.Add(this.flagP);
            this.Controls.Add(this.flagC);
            this.Name = "FlagsRegister";
            this.Size = new System.Drawing.Size(100, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Flag flagC;
        private Flag flagP;
        private Flag flagA;
        private Flag flagZ;
        private Flag flagS;
        private Flag flagO;
        private Flag flagT;
        private Flag flagI;
        private Flag flagD;
        private Register register;
    }
}
