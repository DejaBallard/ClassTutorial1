using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class InputBox : Form
    {
        private int _Answer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prQuestion"></param>
        public InputBox(string prQuestion)
        {
            InitializeComponent();
            lblQuestion.Text = prQuestion;
            lblError.Text = "";
            cbxAnswer.Items.Add("Painting");
            cbxAnswer.Items.Add("Sculpture");
            cbxAnswer.Items.Add("Photograph");
            cbxAnswer.SelectedIndex = 0;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
                _Answer = cbxAnswer.SelectedIndex;
                DialogResult = DialogResult.OK;
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public int getAnswer()
        {
            return _Answer;
        }
    }
}