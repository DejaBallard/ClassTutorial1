using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        private clsArtistList _ArtistList;
        private clsWorksList _WorksList;
        private byte _SortOrder; // 0 = Name, 1 = Date

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

        /// <summary>
        /// Sets all the details of the artist then updates display
        /// </summary>
        /// <param name="prName">Name of the artist</param>
        /// <param name="prSpeciality">What they specialise in</param>
        /// <param name="prPhone">Contact details</param>
        /// <param name="prWorksList">List of the artists work</param>
        /// <param name="prArtistList">list of the artists</param>
        public void SetDetails(string prName, string prSpeciality, string prPhone,
                               clsWorksList prWorksList, clsArtistList prArtistList)
        {
            txtName.Text = prName;
            txtSpeciality.Text = prSpeciality;
            txtPhone.Text = prPhone;
            _ArtistList = prArtistList;
            _WorksList = prWorksList;
            _SortOrder = _WorksList.SortOrder;
            UpdateDisplay();
        }

        /// <summary>
        /// Gets the current artists details and displays on form
        /// </summary>
        /// <param name="prName">Name of artist</param>
        /// <param name="prSpeciality">What they specialise in</param>
        /// <param name="prPhone">Contact Details</param>
        public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone)
        {
            prName = txtName.Text;
            prSpeciality = txtSpeciality.Text;
            prPhone = txtPhone.Text;
            _WorksList.SortOrder = _SortOrder;
        }

        /// <summary>
        /// Button to delete the artist's work from their profile, then updates display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            _WorksList.DeleteWork(lstWorks.SelectedIndex);
            UpdateDisplay();
        }

        /// <summary>
        /// Button to add new work to the artist, then updates display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _WorksList.AddWork();
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
                if (_ArtistList.Contains(txtName.Text))
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
                _WorksList.EditWork(lcIndex);
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

    }
}