//-----------------------------------------------------------------------

// <copyright file="ParseException.cs" author="Circa Dragos">

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
    class ParseException : Exception
    {
        public int SourceLine;

        public ParseException(int sourceLine) : base()
        {
            SourceLine = sourceLine;
        }
        public ParseException(int sourceLine, string message) : base(message)
        {
            SourceLine = sourceLine;
        }
    }
}
