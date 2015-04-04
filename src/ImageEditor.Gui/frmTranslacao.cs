﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor.Gui
{
    public partial class frmTranslacao : Form
    {
        public int Horizontal
        {
            get 
            {
                return (int)nudHorizontal.Value;
            }
        }

        public int Vertical
        {
            get
            {
                return (int)nudVertical.Value;
            }
        }

        public frmTranslacao()
        {
            InitializeComponent();
        }
    }
}
