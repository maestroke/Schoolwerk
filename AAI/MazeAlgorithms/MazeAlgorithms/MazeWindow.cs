﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeAlgorithms {
    public partial class maze : Form {
        #region Constructors
        public maze() {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void mazePictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {

            }
        }
        #endregion
    }
}
