using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmPhotograph : Version_1_C.frmWork
    {

        public frmPhotograph()
        {
            InitializeComponent();
        }

        public virtual void SetDetails(string prName, DateTime prDate, decimal prValue,
                                       float prWidth, float prHeight, string prType)
        {
            base.SetDetails(prName, prDate, prValue);
            txtWidth.Text = Convert.ToString(prWidth);
            txtHeight.Text = Convert.ToString(prHeight);
            txtType.Text = prType;
        }

        /// <summary>
        /// Get the data
        /// </summary>
        /// <param name="prName">Name of painting</param>
        /// <param name="prDate">Date of Painting</param>
        /// <param name="prValue">Value of Painting</param>
        /// <param name="prWidth">Width of Painting</param>
        /// <param name="prHeight">Height of Painting</param>
        /// <param name="prType">Type of Painting</param>
        public virtual void GetDetails(ref string prName, ref DateTime prDate, ref decimal prValue,
                                       ref float prWidth, ref float prHeight, ref string prType)
        {
            base.GetDetails(ref prName, ref prDate, ref prValue);
            prWidth = Convert.ToSingle(txtWidth.Text);
            prHeight = Convert.ToSingle(txtHeight.Text);
            prType = txtType.Text;
        }
    }
}

