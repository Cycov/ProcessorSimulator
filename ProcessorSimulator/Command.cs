//-----------------------------------------------------------------------

// <copyright file="Command.cs" author="Circa Dragos">

//     Copyright (c) Circa Dragos. All rights reserved.

// </copyright>

//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorSimulator
{
    public enum DataBuses
    {
        NONE,
        RBUS,
        DBUS,
        SBUS
    }

    public class CommandStatusChangedEventArgs : EventArgs
    {
        public DataBuses TargetBus;
        public string Name;

        public CommandStatusChangedEventArgs(DataBuses targetBus, string name)
        {
            TargetBus = targetBus;
            Name = name;
        }
    }

    public class Command
    {
        public string Name;
        public bool Active = false;
        public byte Code;
        public DataBuses TargetBus = DataBuses.NONE;

        public event EventHandler<CommandStatusChangedEventArgs> StatusChanged;

        public Command(string name, byte code)
        {
            Name = name;
            Code = code;
        }

        public void Activate(DataBuses targetBus)
        {
            Active = true;
            TargetBus = targetBus;
            StatusChanged?.Invoke(this, new CommandStatusChangedEventArgs(targetBus, Name));
        }

        public void Deactivate()
        {
            Active = false;
            StatusChanged?.Invoke(this, new CommandStatusChangedEventArgs(TargetBus, Name));
        }

        public override string ToString()
        {
            return $"{Name}[{Code}] A:{Active}";
        }
    }
}
