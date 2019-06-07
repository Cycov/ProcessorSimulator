using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorSimulator
{
    public partial class MainForm
    {
        int selectedRegister;

        private void InitializeSeqencer()
        {
            RegisterMIR.Init(RegisteredSBUSCommands,
                             RegisteredDBUSCommands,
                             RegisteredOPALUCommands,
                             RegisteredRBUSCommands,
                             RegisteredOTHERCommands,
                             RegisteredOPMEMCommands);
        }


        private void Step()
        {
            if (registerIR.Value == 0xE00D)
            {
                runTimer.Stop();
                System.Windows.Forms.MessageBox.Show("Program finished");
            }
            DeactivateCommands();
            RegisterMIR.LongValue = MPM[RegisterMAR.Value];
            ExecuteSBUSOperation(RegisterMIR.GetSBUS());
            ExecuteDBUSOperation(RegisterMIR.GetDBUS());
            ExecuteAluOperation(RegisterMIR.GetOPALU());
            ExecuteRBUSOperation(RegisterMIR.GetRBUS());
            ExecuteOTHEROperation(RegisterMIR.GetOTHER());
            ExecuteOPMEMOperation(RegisterMIR.GetOPMEM());
            ExecuteIndexOperation(RegisterMIR.GetCOND(), false, RegisterMIR.GetJUMPBASE(), RegisterMIR.GetINDEX());

            Invalidate();
        }

        private void DeactivateCommands()
        {
            foreach (var item in previousActivatedCommandsListBox.Items)
            {
                (item as Command).Deactivate();
            }
            previousActivatedCommandsListBox.Items.Clear();
        }

        private bool ExecuteSBUSOperation(Command operation)
        {
            operation.Activate(DataBuses.SBUS);
            previousActivatedCommandsListBox.Items.Add(operation);
            switch (operation.Code)
            {
                case 1: VirtualRegSBUS.Value = 0; return true;
                case 2: VirtualRegSBUS.Value = GetRegisterValue((registerIR.Value >> 6) & 0x000f); return true;
                case 3: VirtualRegSBUS.Value = registerIR.Value; return true;
                case 4: VirtualRegSBUS.Value = registerMDR.Value; return true;
                case 5: VirtualRegSBUS.Value = registerSP.Value; return true;
                case 6: VirtualRegSBUS.Value = registerADR.Value; return true;
                case 7: VirtualRegSBUS.Value = registerT.Value; return true;
                case 8: VirtualRegSBUS.Value = registerPC.Value; return true;
                case 9: VirtualRegSBUS.Value = registerIVR.Value; return true;
                case 10: VirtualRegSBUS.Value = FLAGSRegister.Value; return true;
                case 11: VirtualRegSBUS.Value = 1; return true;
                case 12: VirtualRegSBUS.Value = 0xffff; return true;
                case 13:
                    {
                        int offset = (ushort)(registerIR.Value & 0x00ff);
                        if ((offset & 0x00000080) == 0x00000080)
                            offset |= 0xff00;
                        VirtualRegSBUS.Value = (ushort)offset;
                    } return true;
                default: return false;
            }
        }

        private bool ExecuteDBUSOperation(Command operation)
        {
            operation.Activate(DataBuses.DBUS);
            previousActivatedCommandsListBox.Items.Add(operation);

            switch (operation.Code)
            {
                case 1: VirtualRegDBUS.Value = 0; return true;
                case 2: VirtualRegDBUS.Value = GetRegisterValue(registerIR.Value & 0x000f); return true;
                case 3: VirtualRegDBUS.Value = registerIR.Value; return true;
                case 4: VirtualRegDBUS.Value = registerMDR.Value; return true;
                case 5: VirtualRegDBUS.Value = registerSP.Value; return true;
                case 6: VirtualRegDBUS.Value = registerADR.Value; return true;
                case 7: VirtualRegDBUS.Value = registerT.Value; return true;
                case 8: VirtualRegDBUS.Value = registerPC.Value; return true;
                case 9: VirtualRegDBUS.Value = registerIVR.Value; return true;
                case 10: VirtualRegDBUS.Value = FLAGSRegister.Value; return true;
                case 11: VirtualRegDBUS.Value = 1; return true;
                case 12: VirtualRegDBUS.Value = 0xffff; return true;
                case 13: VirtualRegDBUS.Value = (ushort)(registerIR.Value & 0x00ff); return true;
                default: return false;
            }
        }

        private bool ExecuteAluOperation(Command operation)
        {
            operation.Activate(DataBuses.NONE);
            previousActivatedCommandsListBox.Items.Add(operation);

            int s, d;
            if (VirtualRegSBUS.Value > short.MaxValue)
                s = (int)((short)VirtualRegSBUS.Value);
            else
                s = (int)((short)VirtualRegSBUS.Value);
            
            if (VirtualRegDBUS.Value > short.MaxValue)
                d = (int)((short)VirtualRegDBUS.Value);
            else
                d = (int)((short)VirtualRegDBUS.Value);

            switch (operation.Code)
            {
                case 1:
                    {
                        int res = s + d;
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 2:
                    {
                        int res = s & d;
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 3:
                    {
                        int res = s | d;
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 4:
                    {
                        int res = s ^ d;
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 5:
                    {
                        int res = ~d;
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 6:
                    {
                        int res = d / 2;
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 7:
                    {
                        int res = d * 2;
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 8:
                    {
                        int res = d >> 1;
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 9:
                    {
                        int res = d << 1 | (d >> 15 & 0x0001);
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 10:
                    {
                        int res = d >> 1 | ((d & 0x0001) << 15);
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 11:
                    {
                        int res = d << 1 | (FLAGSRegister.GetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.CF) ? 0x0001 : 0x0000);
                        FLAGSRegister.SetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.CF, (d & 0x1000) == 1 ? true : false);
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 12:
                    {
                        int res = d >> 1 | (FLAGSRegister.GetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.CF) ? 0x1000 : 0x0000);
                        FLAGSRegister.SetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.CF, (d & 0x0001) == 1 ? true : false);
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                case 13:
                    {
                        int res = d - s;
                        VirtualRegRBUS.Value = ConvertToUnsignedShort(res);
                        return true;
                    }
                default: return false;
            }
        }

        private bool ExecuteRBUSOperation(Command operation)
        {
            operation.Activate(DataBuses.RBUS);
            previousActivatedCommandsListBox.Items.Add(operation);

            switch (operation.Code)
            {
                case 1: SetRegisterValue(registerIR.Value & 0x000f, VirtualRegRBUS.Value); return true;
                case 2: registerIR.Value = VirtualRegRBUS.Value; return true;
                case 3: registerMDR.Value = VirtualRegRBUS.Value; return true;
                case 4: registerSP.Value = VirtualRegRBUS.Value; return true;
                case 5: registerADR.Value = VirtualRegRBUS.Value; return true;
                case 6: registerT.Value = VirtualRegRBUS.Value; return true;
                case 7: registerPC.Value = VirtualRegRBUS.Value; return true;
                case 8: registerIVR.Value = VirtualRegRBUS.Value; return true;
                case 9: FLAGSRegister.Value = VirtualRegRBUS.Value; return true;
                default: return false;
            }
        }

        private bool ExecuteOTHEROperation(Command operation)
        {
            operation.Activate(DataBuses.NONE);
            previousActivatedCommandsListBox.Items.Add(operation);

            switch (operation.Code)
            {
                case 1: registerPC.Value++; return true;
                case 2: registerSP.Value++; return true;
                case 3: registerSP.Value--; return true;
                case 4: FLAGSRegister.SetFlags(VirtualRegRBUS.Value); return true;
                case 5: FLAGSRegister.SetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.CF, false); return true;
                case 6: FLAGSRegister.SetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.VF, false); return true;
                case 7: FLAGSRegister.SetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.ZF, false); return true;
                case 8: FLAGSRegister.SetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.SF, false); return true;
                case 9: return true;
                case 10: FLAGSRegister.SetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.CF, true); return true;
                case 11: FLAGSRegister.SetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.VF, true); return true;
                case 12: FLAGSRegister.SetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.ZF, true); return true;
                case 13: FLAGSRegister.SetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.SF, true); return true;
                case 14: return true;
                default: return false;
            }
        }

        private bool ExecuteOPMEMOperation(Command operation)
        {
            operation.Activate(DataBuses.NONE);
            previousActivatedCommandsListBox.Items.Add(operation);

            switch (operation.Code)
            {
                case 1: registerIR.Value = mainMemory.GetWord(registerADR.Value * 2); return true;
                case 2: registerMDR.Value = mainMemory.GetWord(registerADR.Value * 2); return true;
                case 3: mainMemory.SetWord(registerADR.Value * 2, registerMDR.Value); return true;
                default: return false;
            }
        }

        private void ExecuteIndexOperation(byte jumpCond, bool checkOnTrue, byte jumpBase, byte index)
        {
            switch (jumpCond)
            {
                case 1:
                    {
                        RegisterMAR.Value++;
                    } break;
                case 2:
                    {
                        int jumpDestination = jumpBase;
                        RegisterMAR.Value = (ushort)jumpDestination;
                    }
                    break;
                case 3:
                    {
                        int jumpDestination = jumpBase;
                        jumpDestination += CalculateOffset(index);

                        RegisterMAR.Value = (ushort)jumpDestination;
                    }
                    break;
                case 4:
                    {
                        int jumpDestination = jumpBase;
                        if (RegisteredINTRCommands["INTR"].Active ^ checkOnTrue)
                            RegisterMAR.Value = (ushort)jumpDestination;
                        else
                            RegisterMAR.Value++;
                    }
                    break;
                case 5:
                    {
                        if (GetInstructionClass() == 0)
                        {
                            int jumpDestination = jumpBase;
                            jumpDestination += CalculateOffset(index);
                            RegisterMAR.Value = (ushort)jumpDestination;
                        }
                        else
                            RegisterMAR.Value++;
                    }
                    break;
                case 6:
                    {
                        if ((((registerIR.Value >> 4) & 0x00000003) == 1) ^ checkOnTrue)
                        {
                            int jumpDestination = jumpBase;
                            jumpDestination += CalculateOffset(index);
                            RegisterMAR.Value = (ushort)jumpDestination;
                        }
                        else
                            RegisterMAR.Value++;
                    }
                    break;
                case 7:
                    {
                        if ((!FLAGSRegister.GetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.ZF)) ^ checkOnTrue)
                        {
                            int jumpDestination = jumpBase;
                            jumpDestination += CalculateOffset(index);
                            RegisterMAR.Value = (ushort)jumpDestination;
                        }
                        else
                            RegisterMAR.Value++;
                    }
                    break;
                case 8:
                    {
                        if ((!FLAGSRegister.GetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.CF)) ^ checkOnTrue)
                        {
                            int jumpDestination = jumpBase;
                            jumpDestination += CalculateOffset(index);
                            RegisterMAR.Value = (ushort)jumpDestination;
                        }
                        else
                            RegisterMAR.Value++;
                    }
                    break;
                case 9:
                    {
                        if ((!FLAGSRegister.GetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.VF)) ^ checkOnTrue)
                        {
                            int jumpDestination = jumpBase;
                            jumpDestination += CalculateOffset(index);
                            RegisterMAR.Value = (ushort)jumpDestination;
                        }
                        else
                            RegisterMAR.Value++;
                    }
                    break;
                case 10:
                    {
                        if ((!FLAGSRegister.GetFlag(ProcessorSimulator.Controls.Flags.FlagsRegister.Flags.SF)) ^ checkOnTrue)
                        {
                            int jumpDestination = jumpBase;
                            jumpDestination += CalculateOffset(index);
                            RegisterMAR.Value = (ushort)jumpDestination;
                        }
                        else
                            RegisterMAR.Value++;
                    }
                    break;
                case 11:
                    {
                        int jumpDestination = jumpBase;
                        if ((RegisteredINTRCommands["INTR"].Active) ^ checkOnTrue)
                            RegisterMAR.Value = (ushort)jumpDestination;
                        else
                            RegisterMAR.Value++;
                    }
                    break;
                default:
                    break;
            }
        }

        private int CalculateOffset(byte index)
        {
            switch (index)
            {
                case 1: return GetInstructionClass();
                case 2: return ((registerIR.Value >> 10) & 0x00000003) << 1;
                case 3: return ((registerIR.Value >> 4) & 0x00000003) << 1;
                case 4: return ((registerIR.Value >> 12) & 0x00000007) << 1;
                case 5: return ((registerIR.Value >> 6) & 0x0000007f) << 1;
                case 6: return ((registerIR.Value >> 8) & 0x0000001f) << 1;
                case 7: return (registerIR.Value & 0x00001ffff) << 1;
                default: return 0;
            }
        }

        private int GetInstructionClass()
        {
            var HIGH = (byte)(registerIR.Value >> 8);
            var IR15 = (byte)(HIGH >> 7);
            var IR14 = (byte)((HIGH >> 6) & 1);
            var IR13 = (byte)((HIGH >> 5) & 1);
            var CL1 = (byte)(IR15 & IR14);
            var CL0 = (byte)(IR15 & (~IR13));

            return (int)((CL1 << 1) | CL0);
        }

        private int GetInstructionOpCode(int instructionClass)
        {
            switch (instructionClass)
            {
                case 0:
                    return (registerIR.Value >> 12) & 0x0007;
                case 1:
                    return (registerIR.Value >> 6) & 0x007f;
                case 2:
                    return (registerIR.Value >> 8) & 0x001f;
                default:
                    return registerIR.Value & 0x1fff;
            }
        }

        private ushort ConvertToUnsignedShort(int value)
        {
            if (value < 0)
                return (ushort)(value);
            else
                return (ushort)value;
        }

        private ushort GetRegisterValue(int register)
        {
            switch (register)
            {
                case 0: return register0.Value;
                case 1: return register1.Value;
                case 2: return register2.Value;
                case 3: return register3.Value;
                case 4: return register4.Value;
                case 5: return register5.Value;
                case 6: return register6.Value;
                case 7: return register7.Value;
                case 8: return register8.Value;
                case 9: return register9.Value;
                case 10: return register10.Value;
                case 11: return register11.Value;
                case 12: return register12.Value;
                case 13: return register13.Value;
                case 14: return register14.Value;
                case 15: return register15.Value;
                default:
                    return 0;
                    break;
            }
        }
        private void SetRegisterValue(int register, ushort value)
        {
            switch (register)
            {
                case 0: register0.Value = value; return;
                case 1: register1.Value = value; return;
                case 2: register2.Value = value; return;
                case 3: register3.Value = value; return;
                case 4: register4.Value = value; return;
                case 5: register5.Value = value; return;
                case 6: register6.Value = value; return;
                case 7: register7.Value = value; return;
                case 8: register8.Value = value; return;
                case 9: register9.Value = value; return;
                case 10: register10.Value = value; return;
                case 11: register11.Value = value; return;
                case 12: register12.Value = value; return;
                case 13: register13.Value = value; return;
                case 14: register14.Value = value; return;
                case 15: register15.Value = value; return;
                default: return;
            }
        }
    }
}
