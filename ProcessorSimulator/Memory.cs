using System;
using AssemblySimulator.EventArgs;

namespace ProcessorSimulator
{
    public class Memory
    {
        public byte this[int index]
        {
            get => locations[index];
            set => locations[index] = value;
        }
        protected byte[] locations { get; set; }
        public readonly int Size = 1048576;

        public event EventHandler<MemoryByteModifiedEventArgs> MemoryByteModified;
        public event EventHandler<MemoryWordModifiedEventArgs> MemoryWordModified;
        public event EventHandler<MemoryDWordModifiedEventArgs> MemoryDWordModified;
        public event EventHandler<MemoryQWordModifiedEventArgs> MemoryQWordModified;
        public event EventHandler<MemoryModifiedEventArgs> MemoryModified;

        public Memory()
        {
            locations = new byte[Size];
        }

        public Memory(int size)
        {
            Size = size;
            locations = new byte[Size];
        }

        public void SetByte(int adress, byte value)
        {
            if (adress > Size)
                throw new IndexOutOfRangeException("Adress out of addresable memory: " + adress.ToString());
            locations[adress] = value;
            MemoryByteModified?.Invoke(this, new MemoryByteModifiedEventArgs(adress, value));
            MemoryModified?.Invoke(this, new MemoryModifiedEventArgs(adress, 8));
        }
        public void SetWord(int adress, ushort value)
        {
            if (adress > Size)
                throw new IndexOutOfRangeException("Adress out of addresable memory: " + adress.ToString());
            locations[adress] = (byte)value;
            locations[adress + 1] = (byte)(value >> 8);
            MemoryWordModified?.Invoke(this, new MemoryWordModifiedEventArgs(adress, value));
            MemoryModified?.Invoke(this, new MemoryModifiedEventArgs(adress, 16));
        }
        public void SetDWord(int adress, UInt32 value)
        {
            if (adress > Size)
                throw new IndexOutOfRangeException("Adress out of addresable memory: " + adress.ToString());
            locations[adress] = (byte)value;
            locations[adress + 1] = (byte)(value >> 8);
            locations[adress + 2] = (byte)(value >> 16);
            locations[adress + 3] = (byte)(value >> 24);
            MemoryDWordModified?.Invoke(this, new MemoryDWordModifiedEventArgs(adress, value));
            MemoryModified?.Invoke(this, new MemoryModifiedEventArgs(adress, 32));
        }
        public void SetQWord(int adress, UInt64 value)
        {
            if (adress > Size)
                throw new IndexOutOfRangeException("Adress out of addresable memory: " + adress.ToString());
            locations[adress] = (byte)value;
            locations[adress + 1] = (byte)(value >> 8);
            locations[adress + 2] = (byte)(value >> 16);
            locations[adress + 3] = (byte)(value >> 24);
            locations[adress + 4] = (byte)(value >> 32);
            locations[adress + 5] = (byte)(value >> 40);
            locations[adress + 6] = (byte)(value >> 48);
            locations[adress + 7] = (byte)(value >> 56);
            MemoryQWordModified?.Invoke(this, new MemoryQWordModifiedEventArgs(adress, value));
            MemoryModified?.Invoke(this, new MemoryModifiedEventArgs(adress, 64));
        }

        public void SetBlock(int startAddress, UInt16[] words)
        {
            if (startAddress % 2 != 0)
                return;
            if (words.Length * 2 + startAddress > Size)
                throw new IndexOutOfRangeException("Adress out of addresable memory: " + (words.Length * 2 + startAddress).ToString());
            for (int i = 0; i < words.Length; i++)
            {
                SetWord(startAddress, words[i]);
                startAddress += 2;
            }
        }

        public byte GetByte(int adress)
        {
            if (adress > Size)
                throw new IndexOutOfRangeException("Adress out of addresable memory: " + adress.ToString());
            return locations[adress];
        }
        public ushort GetWord(int adress)
        {
            ushort word;
            if (adress > Size)
                throw new IndexOutOfRangeException("Adress out of addresable memory: " + adress.ToString());
            word = (ushort)(locations[adress] | 
                           (locations[adress + 1] << 8));
            return word;
        }
        public UInt32 GetDWord(int adress)
        {
            UInt32 dword;
            if (adress > Size)
                throw new IndexOutOfRangeException("Adress out of addresable memory: " + adress.ToString());
            dword = (UInt32)(locations[adress] |
                           (locations[adress + 1] << 8) |
                           (locations[adress + 2] << 16) |
                           (locations[adress + 3] << 24));
            return dword;
        }
        public UInt64 GetQWord(int adress)
        {
            UInt64 qword;
            if (adress > Size)
                throw new IndexOutOfRangeException("Adress out of addresable memory: " + adress.ToString());
            qword = (UInt64)(locations[adress] |
                           (locations[adress + 1] << 8) |
                           (locations[adress + 2] << 16) |
                           (locations[adress + 3] << 24) |
                           (locations[adress + 4] << 32) |
                           (locations[adress + 5] << 40) |
                           (locations[adress + 6] << 48) |
                           (locations[adress + 7] << 56));
            return qword;
        }

        public void SetByte(ushort segment, ushort offset, byte value)
        {
            SetByte((segment << 4) + offset, value);
        }
        public void SetWord(ushort segment, ushort offset, ushort value)
        {
            SetWord((segment << 4) + offset, value);
        }
        public void SetDWord(ushort segment, ushort offset, UInt32 value)
        {
            SetDWord((segment << 4) + offset, value);
        }
        public void SetQWord(ushort segment, ushort offset, UInt64 value)
        {
            SetQWord((segment << 4) + offset, value);
        }

        public byte GetByte(ushort segment, ushort adress)
        {
            return GetByte((segment << 4) + adress);
        }
        public ushort GetWord(ushort segment, ushort adress)
        {
            return GetWord((segment << 4) + adress);
        }
        public UInt32 GetDWord(ushort segment, ushort adress)
        {
            return GetDWord((segment << 4) + adress);
        }
        public UInt64 GetQWord(ushort segment, ushort adress)
        {
            return GetQWord((segment << 4) + adress);
        }

        public byte[] GetAllBytes()
        {
            return locations;
        }
        public void Clear()
        {
            locations = new byte[Size];
            MemoryModified?.Invoke(this, new MemoryModifiedEventArgs(0, 16));
        }
    }
}
