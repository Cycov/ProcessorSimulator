//-----------------------------------------------------------------------

// <copyright file="JumpLabel.cs" author="Circa Dragos">

//     Copyright (c) Circa Dragos. All rights reserved.

// </copyright>

//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorSimulator.Assembler
{
    class JumpLabel
    {
        public string Name;
        public ushort Target;
        public bool Updated;
        public ushort Address; // Adresa de salt (pana nu o gaseste este 0)

        public JumpLabel(string name)
        {
            Name = name;
            Target = 0;
            Updated = false;
            Address = 0;
        }
    }
}
