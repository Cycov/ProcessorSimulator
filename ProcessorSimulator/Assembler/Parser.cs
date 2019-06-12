using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorSimulator.Assembler
{
    public partial class Parser
    {
        public ushort[] Parse(string[] lines)
        {
            ushort[] parsedCode = new ushort[ushort.MaxValue];
            ushort address = 0;
            List<JumpLabel> jumpLabels = new List<JumpLabel>();

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                string currentLine = lines[lineIndex];
                if (string.IsNullOrWhiteSpace(currentLine))
                    continue;

                string[] t1 = currentLine.Split(new char[] { ' ', ',' });

                string[] currentLineParts = new string[4];
                for (int i = 0, j = 0; i < t1.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(t1[i]))
                        currentLineParts[j++] = t1[i].Trim();
                }

                Instruction currentInstruction = null;
                if (Instructions.ContainsKey(currentLineParts[0]))
                    currentInstruction = Instructions[currentLineParts[0]];
                else if (IsLabel(currentLine = currentLine.Trim()))
                {
                    jumpLabels.Add(new JumpLabel(currentLine.Remove(currentLine.Length - 1)) { Target = address, Address = address, Updated = true });
                    continue;
                }
                else
                    Error(lineIndex);

                ushort instruction = 0;
                if (currentInstruction != null)
                    instruction = currentInstruction.Opcode;
                else
                    Error(lineIndex);

                switch (currentInstruction.Class)
                {
                    case 0:
                        {
                            Operand destinationOperand = ParseOperand(lineIndex, currentLineParts[1]);
                            Operand sourceOperand = ParseOperand(lineIndex, currentLineParts[2]);
                            if (destinationOperand.AdressingMode == AdressingTypes.AM)
                                throw new ParseException(lineIndex, "Illegal addresing mode");

                            instruction = (ushort)(instruction << 12 | (int)(sourceOperand.AdressingMode) << 10 | sourceOperand.Register << 6 |
                                                                       (int)(destinationOperand.AdressingMode) << 4 | destinationOperand.Register);
                            parsedCode[address++] = instruction;
                            if (destinationOperand.AdressingMode == AdressingTypes.AM || destinationOperand.AdressingMode == AdressingTypes.AX)
                                parsedCode[address++] = destinationOperand.Offset;
                            if (sourceOperand.AdressingMode == AdressingTypes.AM || sourceOperand.AdressingMode == AdressingTypes.AX)
                                parsedCode[address++] = sourceOperand.Offset;
                        }
                        break;
                    case 1:
                        {
                            Operand destinationOperand = ParseOperand(lineIndex, currentLineParts[1]);
                            if (destinationOperand.AdressingMode == AdressingTypes.AM)
                                throw new ParseException(lineIndex, "Illegal addresing mode");

                            instruction = (ushort)(instruction << 6 | (int)(destinationOperand.AdressingMode) << 4 | destinationOperand.Register);
                            parsedCode[address++] = instruction;
                            if (destinationOperand.AdressingMode == AdressingTypes.AM || destinationOperand.AdressingMode == AdressingTypes.AX)
                                parsedCode[address++] = destinationOperand.Offset;
                        }
                        break;
                    case 2:
                        {
                            instruction = (ushort)(instruction << 8 | 0x0);
                            jumpLabels.Add(new JumpLabel(currentLineParts[1].Trim()) { Address = address });
                            parsedCode[address++] = instruction;
                        }
                        break;
                    case 3:
                        {
                            parsedCode[address++] = instruction;
                        }
                        break;
                    default:
                        break;
                }

            }

            // Validate labels
            for (int i = 0; i < jumpLabels.Count; i++)
            {
                JumpLabel targetJumpLabel = null;
                if (jumpLabels[i].Updated == true)
                    targetJumpLabel = jumpLabels[i];
                else
                {
                    for (int j = 0; j < jumpLabels.Count; j++)
                    {
                        if (i == j)
                            continue;
                        if (jumpLabels[j].Name == jumpLabels[i].Name && jumpLabels[j].Updated == true)
                        {
                            if (targetJumpLabel == null)
                                targetJumpLabel = jumpLabels[j];
                            else
                                Error(0, $"Label defined more than once: {targetJumpLabel.Name}");
                        }
                    }
                }


                if (targetJumpLabel == null)
                    Error(0, $"Label definition not found: {jumpLabels[i].Name}");

                for (int j = 0; j < jumpLabels.Count; j++)
                {
                    if (i == j)
                        continue;
                    if (jumpLabels[j].Name == jumpLabels[i].Name && jumpLabels[j].Updated == false)
                    {
                        parsedCode[jumpLabels[j].Address] |= (byte)(targetJumpLabel.Target - jumpLabels[j].Address - 1);
                        jumpLabels[j].Updated = true;
                        jumpLabels[j].Target = targetJumpLabel.Target;
                    }
                }

                }

            return parsedCode;
        }

        private void Error(int lineNumber, string errorText = "An error occured")
        {
            throw new ParseException(lineNumber, $"{errorText} on line {lineNumber}");
        }

        private Operand ParseOperand(int i, string input)
        {
            Operand operand = new Operand();
            if (input[input.Length - 1] == ')')
            {
                int openBracketIndex = input.IndexOf('(');
                if (openBracketIndex > -1)
                {
                    if (input[0] == '(')
                    {
                        operand.AdressingMode = AdressingTypes.AI;
                        var value = input.Substring(2, length: input.Length - 3);
                        if (!byte.TryParse(value, out operand.Register))
                            throw new ParseException(i, $"Unknown register: {value}");
                    }
                    else
                    {
                        operand.AdressingMode = AdressingTypes.AX;
                        string value = input.Substring(0, openBracketIndex);
                        if (!ushort.TryParse(value, out operand.Offset))
                            throw new ParseException(i, $"Invalid value: {value}");
                    }
                }
                else
                {
                    throw new ParseException(i, "Found ')' but not opening '('. Did you add any spaces?");
                }
            }
            else if (input[0] == 'r')
            {
                var value = input.Substring(1);
                if (!byte.TryParse(value, out operand.Register))
                    throw new ParseException(i, $"Unknown register: {value}");
                else
                    operand.AdressingMode = AdressingTypes.AD;
            }
            else if (ushort.TryParse(input, out operand.Offset))
            {
                operand.AdressingMode = AdressingTypes.AM;
                operand.Register = 0;
            }
            else
            {
                throw new ParseException(i, $"Unknown operand: {input}");
            }

            return operand;
        }

        private bool IsLabel(string input)
        {
            if (input[0] >= '0' && input[0] <= '9')
                return false;
            if (input[input.Length - 1] != ':')
                return false;
            return true;
        }
    }
}
