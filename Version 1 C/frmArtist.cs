using System;
//using System.Collections;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        private clsWorksList _WorksList;
        private byte _SortOrder; // 0 = Name, 1 = Date
        private clsArtist _Artist;

        public frmArtist()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the forms display
        /// </summary>
        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_SortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }

      
        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            UpdateDisplay();
            ShowDialog();
        }

        /// <summary>
        /// Button to delete the artist's work from their profile, then updates display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstWorks.SelectedIndex >= 0 && lstWorks.SelectedIndex < _WorksList.Count)
            {
                if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _WorksList.DeleteWork(lstWorks.SelectedIndex);
                }
            }
            UpdateDisplay();
        }

        /// <summary>
        /// Button to add new work to the artist, then updates display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int lcAnswer;

            InputBox inputBox = new InputBox("Please select a work type from the drop box");
            if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lcAnswer = (int)Convert.ToSingle(inputBox.getAnswer());
                _WorksList.AddWork(lcAnswer);
            }
            UpdateDisplay();
        }


        /// <summary>
        /// button to close the form, checks to see if the form is valid before closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Check to see if the artist's name is valid and not already existing
        /// </summary>
        /// <returns>true or false, if the artist's name already exists</returns>
        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        /// <summary>
        /// Edit the work that the user double clicks on, then update display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                try
                {
                    _WorksList.EditWork(lcIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                UpdateDisplay();
            }
        }

        /// <summary>
        /// sort the artist's work when the form's radio button has changed. Update display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtPhone.Text = _Artist.Phone;
            txtSpeciality.Text = _Artist.Speciality;
            _WorksList = _Artist.WorksList;
            _SortOrder = _WorksList.SortOrder;
        }
        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Phone = txtPhone.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _WorksList = _Artist.WorksList;
            _WorksList.SortOrder = _SortOrder;
        }
    }
}