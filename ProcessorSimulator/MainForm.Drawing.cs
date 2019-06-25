//-----------------------------------------------------------------------

// <copyright file="MainForm.Drawing.cs" author="Circa Dragos">

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

namespace ProcessorSimulator
{
    public partial class MainForm
    {
        Pen activePenThin = Pens.Red;
        Pen inactivePenThin = Pens.Black;

        Pen activePen = new Pen(Color.Red, 3);
        Pen inactivePen = new Pen(Color.Black, 3);

        int RBusY = 50, DBusY = 300, SBusY = 350;

        private void AluDisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawALU(new Pen(Color.Black, 3) { EndCap = System.Drawing.Drawing2D.LineCap.Flat }, new Rectangle(0, 0, (sender as Panel).Width, (sender as Panel).Height));
        }

        void DrawElements(Graphics g)
        {
            // Create pen.
            Pen pen = new Pen(Color.Black, 3);
            Brush brush = Brushes.Black;
            int busesPadding = 50;
            int x;

            //RBUS
            g.DrawLine(pen, busesPadding, RBusY, Width - busesPadding, RBusY);

            // SBUS
            g.DrawLine(pen, busesPadding, SBusY, Width - busesPadding, SBusY);

            // DBUS
            g.DrawLine(pen, busesPadding, DBusY, Width - busesPadding, DBusY);

            //MDR
            DrawVerticalCommandArrow(g, DataBuses.RBUS, MDRRegisterPanel.Bounds, "PmMDR");
            DrawVerticalCommandArrow(g, MDRRegisterPanel.Bounds, IRRegisterPanel.Bounds, "IFCH", 0.2);
            DrawVerticalCommandArrow(g, MDRRegisterPanel.Bounds, DataBuses.DBUS, "PdMDR", 0.4);
            DrawVerticalCommandArrow(g, MDRRegisterPanel.Bounds, DataBuses.SBUS, "PdMDR", 0.6);
            DrawVerticalCommandArrow(g, MDRRegisterPanel.Bounds, memorySegmentDisplay1.Bounds, "READ", 0.8);

            Pen arrowPen = new Pen(Brushes.Black);
            arrowPen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            arrowPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            g.DrawLines(arrowPen, new Point[]
            {
                new Point(memorySegmentDisplay1.Location.X, memorySegmentDisplay1.Location.Y + memorySegmentDisplay1.Height / 2),
                new Point(busesPadding - 10, memorySegmentDisplay1.Location.Y + memorySegmentDisplay1.Height / 2),
                new Point(busesPadding - 10, MDRRegisterPanel.Location.Y + MDRRegisterPanel.Height / 2),
                new Point(MDRRegisterPanel.Location.X, MDRRegisterPanel.Location.Y + MDRRegisterPanel.Height / 2),
            });
            g.DrawLines(arrowPen, new Point[]
            {
                new Point(memorySegmentDisplay1.Location.X, memorySegmentDisplay1.Location.Y + memorySegmentDisplay1.Height / 2),
                new Point(busesPadding - 10, memorySegmentDisplay1.Location.Y + memorySegmentDisplay1.Height / 2),
                new Point(busesPadding - 10, IRRegisterPanel.Location.Y + IRRegisterPanel.Height / 2),
                new Point(IRRegisterPanel.Location.X, IRRegisterPanel.Location.Y + IRRegisterPanel.Height / 2),
            });

            //SP
            DrawVerticalCommandArrow(g, DataBuses.RBUS, SPRegisterPanel.Bounds, "PmSP");
            DrawVerticalCommandArrow(g, SPRegisterPanel.Bounds, DataBuses.DBUS, "PdSP", 0.3);
            DrawVerticalCommandArrow(g, SPRegisterPanel.Bounds, DataBuses.SBUS, "PdSP", 0.6);

            //ADR
            DrawVerticalCommandArrow(g, DataBuses.RBUS, ADRRegisterPanel.Bounds, "PmADR");
            DrawVerticalCommandArrow(g, ADRRegisterPanel.Bounds, DataBuses.DBUS, "PdADR", 0.25);
            DrawVerticalCommandArrow(g, ADRRegisterPanel.Bounds, DataBuses.SBUS, "PdADR", 0.5);
            DrawVerticalCommandArrow(g, ADRRegisterPanel.Bounds, memorySegmentDisplay1.Bounds, "READ", 0.75);

            //T
            DrawVerticalCommandArrow(g, DataBuses.RBUS, TRegisterPanel.Bounds, "PmT");
            DrawVerticalCommandArrow(g, TRegisterPanel.Bounds, DataBuses.DBUS, "PdT", 0.3);
            DrawVerticalCommandArrow(g, TRegisterPanel.Bounds, DataBuses.SBUS, "PdT", 0.6);

            //PC
            DrawVerticalCommandArrow(g, DataBuses.RBUS, PCRegisterPanel.Bounds, "PmPC");
            DrawVerticalCommandArrow(g, PCRegisterPanel.Bounds, DataBuses.DBUS, "PdPC", 0.3);
            DrawVerticalCommandArrow(g, PCRegisterPanel.Bounds, DataBuses.SBUS, "PdPC", 0.6);

            //IVR
            DrawVerticalCommandArrow(g, DataBuses.RBUS, IVRRegisterPanel.Bounds, "PmIVR");
            DrawVerticalCommandArrow(g, IVRRegisterPanel.Bounds, DataBuses.DBUS, "PdIVR", 0.3);
            DrawVerticalCommandArrow(g, IVRRegisterPanel.Bounds, DataBuses.SBUS, "PdIVR", 0.6);

            //FLAGS
            DrawVerticalCommandArrow(g, DataBuses.RBUS, FLAGSRegisterPanel.Bounds, "PmFLAG");
            DrawVerticalCommandArrow(g, FLAGSRegisterPanel.Bounds, DataBuses.DBUS, "PdFLAG", 0.3);
            DrawVerticalCommandArrow(g, FLAGSRegisterPanel.Bounds, DataBuses.SBUS, "PdFLAG", 0.6);

            //REGISTERS
            DrawVerticalCommandArrow(g, DataBuses.RBUS, registersGroupBox.Bounds, "PmRG");
            DrawVerticalCommandArrow(g, registersGroupBox.Bounds, DataBuses.DBUS, "PdRG", 0.3);
            DrawVerticalCommandArrow(g, registersGroupBox.Bounds, DataBuses.SBUS, "PdRG", 0.6);

            //ALU
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "SUM", 0.16);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "AND", 0.22);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "OR", 0.28);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "XOR", 0.34);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "NEG", 0.40);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "ASR", 0.46);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "ASL", 0.52);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "LSR", 0.58);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "ROL", 0.64);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "ROR", 0.7);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "RLC", 0.76);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "RRC", 0.82);
            DrawHorizontalCommandArrow(g, aluDisplayPanel, "SUB", 0.9);

            DrawVerticalCommandArrow(g, DataBuses.DBUS, aluDisplayPanel.Bounds, "NONE", 0.25, 0, "NONE", true);
            DrawVerticalCommandArrow(g, DataBuses.SBUS, aluDisplayPanel.Bounds, "NONE", 0.75, 0, "NONE", true);
            DrawVerticalCommandArrow(g, aluDisplayPanel.Bounds, DataBuses.RBUS, "NONE", 0.5, 0, "NONE");

            //Special buses
            DrawVerticalCommandArrow(g, otherOperationsSourcePanel.Bounds, DataBuses.DBUS, "Pd0", 0.142);
            DrawVerticalCommandArrow(g, otherOperationsSourcePanel.Bounds, DataBuses.DBUS, "Pd1", 0.285);
            DrawVerticalCommandArrow(g, otherOperationsSourcePanel.Bounds, DataBuses.DBUS, "Pd-1", 0.428);
            DrawVerticalCommandArrow(g, otherOperationsSourcePanel.Bounds, DataBuses.SBUS, "Pd0", 0.571);
            DrawVerticalCommandArrow(g, otherOperationsSourcePanel.Bounds, DataBuses.SBUS, "Pd1", 0.714);
            DrawVerticalCommandArrow(g, otherOperationsSourcePanel.Bounds, DataBuses.SBUS, "Pd-1", 0.857);

            //g.DrawString("RBUS", Font, Brushes.Black, Width - busesPadding - 10, GetBusY(DataBuses.RBUS) - 15);
            //g.DrawString("DBUS", Font, Brushes.Black, Width - busesPadding - 10, GetBusY(DataBuses.DBUS) - 15);
            //g.DrawString("SBUS", Font, Brushes.Black, Width - busesPadding - 10, GetBusY(DataBuses.SBUS) - 15);
        }

        private Pen GetPenThin(string command)
        {
            if (!RegisteredOPALUCommands.ContainsKey(command))
                return inactivePenThin;
            if (RegisteredOPALUCommands[command].Active)
                return activePenThin;
            else
                return inactivePenThin;
        }
        private Pen GetPenThin(string command, DataBuses targetBus)
        {
            var commands = RegisteredOTHERCommands;
            switch (targetBus)
            {
                case DataBuses.NONE: return inactivePenThin;
                case DataBuses.RBUS:
                    commands = RegisteredRBUSCommands;
                    break;
                case DataBuses.DBUS:
                    commands = RegisteredDBUSCommands;
                    break;
                case DataBuses.SBUS:
                    commands = RegisteredSBUSCommands;
                    break;
                default:
                    break;
            }
            if (commands[command].Active && commands[command].TargetBus == targetBus)
                return activePenThin;
            else
                return inactivePenThin;
        }

        private Pen GetPen(string command)
        {
            if (RegisteredOPALUCommands[command].Active)
                return activePen;
            else
                return inactivePen;
        }
        private Pen GetPen(string command, DataBuses targetBus)
        {
            var commands = RegisteredOTHERCommands;
            switch (targetBus)
            {
                case DataBuses.NONE: return inactivePenThin;
                case DataBuses.RBUS:
                    commands = RegisteredRBUSCommands;
                    break;
                case DataBuses.DBUS:
                    commands = RegisteredDBUSCommands;
                    break;
                case DataBuses.SBUS:
                    commands = RegisteredSBUSCommands;
                    break;
                default:
                    break;
            }
            if (commands[command].Active && commands[command].TargetBus == targetBus)
                return activePen;
            else
                return inactivePen;
        }

        private int GetBusY(DataBuses bus)
        {
            switch (bus)
            {
                case DataBuses.NONE: return 0;
                case DataBuses.RBUS: return RBusY;
                case DataBuses.DBUS: return DBusY;
                case DataBuses.SBUS: return SBusY;
                default: return 0;
            }
        }
    }
}
