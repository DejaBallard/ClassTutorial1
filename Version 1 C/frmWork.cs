using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmWork : Form
    {

        public frmWork()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the data
        /// </summary>
        /// <param name="prName">Name of work</param>
        /// <param name="prDate">Date of Work</param>
        /// <param name="prValue">Value of Work</param>
        public void SetDetails(string prName, DateTime prDate, decimal prValue)
        {
            txtName.Text = prName;
            txtCreation.Text = prDate.ToShortDateString();
            txtValue.Text = Convert.ToString(prValue);
        }

        /// <summary>
        /// Get the data
        /// </summary>
        /// <param name="prName">Name of work</param>
        /// <param name="prDate">Date of Work</param>
        /// <param name="prValue">Value of Work</param>
        public void GetDetails(ref string prName, ref DateTime prDate, ref decimal prValue)
        {
            prName = txtName.Text;
            prDate = Convert.ToDateTime(txtCreation.Text);
            prValue = Convert.ToDecimal(txtValue.Text);
        }

        /// <summary>
        /// Button to confirm the data then close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Button to close the form without confirming
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        /// <summary>
        /// Checks to see if the data is valid
        /// </summary>
        /// <returns>True</returns>
        public virtual bool isValid()
        {
            return true;
        }
    
    }
}