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
        protected clsWork _Work;

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
        public void SetDetails(clsWork prWork)
        {
            _Work = prWork;
            updateForm();
            ShowDialog();
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
                pushData();
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
    
        protected virtual void updateForm()
        {
            txtName.Text = _Work.Name;
            txtCreation.Text = _Work.Date.ToLongDateString();
            txtValue.Text = _Work.Value.ToString();
        }

        protected virtual void pushData()
        {
            _Work.Name = txtName.Text;
            _Work.Date = DateTime.Parse(txtCreation.Text);
            _Work.Value = decimal.Parse(txtValue.Text);
        }
    }
}