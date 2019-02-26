using System;
namespace Version_1_C
{
    [Serializable()]
    public class clsArtist
    {
        /// <summary>
        /// The Artist's personal details
        /// </summary>
        private string _Name;
        private string _Speciality;
        private string _Phone;
        
        /// <summary>
        /// Total value of the artist's work
        /// </summary>
        private decimal _TotalValue;

        /// <summary>
        /// Work list of the artist
        /// List of artists
        /// </summary>
        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        /// <summary>
        /// UI of Artist
        /// </summary>
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
        
        public void EditDetails()
        {
            _FrmArtistDialog.SetDetails(_Name, _Speciality, _Phone, _WorksList, _ArtistList);
            if (_FrmArtistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _FrmArtistDialog.GetDetails(ref _Name, ref _Speciality, ref _Phone);
                _TotalValue = _WorksList.GetTotalValue();
            }
        }

        public string GetKey()
        {
            return _Name;
        }

        public decimal GetWorksValue()
        {
            return _TotalValue;
        }
    }
}
