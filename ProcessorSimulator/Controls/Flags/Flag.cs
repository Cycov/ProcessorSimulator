﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator.Controls.Flags
{
    public partial class Flag : CheckBox
    {
        public Flag()
        {
            InitializeComponent();
            RightToLeft = RightToLeft.Yes;
            Font = new Font(Font, FontStyle.Bold);
        }
    }
}
