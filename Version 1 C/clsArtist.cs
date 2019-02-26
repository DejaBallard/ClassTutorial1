using System;
namespace Version_1_C
{
    [Serializable()]
    public class clsArtist
    {

        private string _Name;
        private string _Speciality;
        private string _Phone;
        
        private decimal _TotalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        private static frmArtist _FrmArtistDialog = new frmArtist();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="prArtistList"></param>
        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }
        
        /// <summary>
        /// Open up the edit Dialog, if completed correctly, update artist's details
        /// </summary>
        public void EditDetails()
        {
            _FrmArtistDialog.SetDetails(_Name, _Speciality, _Phone, _WorksList, _ArtistList);
            if (_FrmArtistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _FrmArtistDialog.GetDetails(ref _Name, ref _Speciality, ref _Phone);
                _TotalValue = _WorksList.GetTotalValue();
            }
        }

        /// <summary>
        /// Get the artists name
        /// </summary>
        /// <returns>Artists name</returns>
        public string GetKey()
        {
            return _Name;
        }

        /// <summary>
        /// Get the price value of the artist's work
        /// </summary>
        /// <returns>Total value of the artist's work</returns>
        public decimal GetWorksValue()
        {
            return _TotalValue;
        }
    }
}
