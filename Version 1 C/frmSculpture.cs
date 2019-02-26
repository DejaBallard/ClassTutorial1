using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmSculpture : Version_1_C.frmWork
    {

        
        public frmSculpture()
        {
            InitializeComponent();
        }
        /// <summary>
        /// save the data
        /// </summary>
        /// <param name="prName">Name of painting</param>
        /// <param name="prDate">Date of Painting</param>
        /// <param name="prValue">Value of Painting</param>
        public virtual void SetDetails(string prName, DateTime prDate, decimal prValue,
                                       float prWeight, float prMaterial)
        {
            base.SetDetails(prName, prDate, prValue);
            txtWeight.Text = Convert.ToString(prWeight);
            txtMaterial.Text = Convert.ToString(prMaterial);
        }

        /// <summary>
        /// Get the data
        /// </summary>
        /// <param name="prName">Name of painting</param>
        /// <param name="prDate">Date of Painting</param>
        /// <param name="prValue">Value of Painting</param>
        public virtual void GetDetails(ref string prName, ref DateTime prDate, ref decimal prValue,
                                       ref float prWeight, ref float prMaterial)
        {
            base.GetDetails(ref prName, ref prDate, ref prValue);
            prWeight = Convert.ToSingle(txtWeight.Text);
            prMaterial = Convert.ToSingle(txtMaterial.Text);
        }
    }
}

