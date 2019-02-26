using System;
using System.Collections;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtistList : SortedList
    {
        private const string _FileName = "gallery.xml";

        /// <summary>
        /// Checks to see if the artist exists
        /// </summary>
        /// <param name="prKey">The artist's name</param>
        public void EditArtist(string prKey)
        {
            clsArtist lcArtist;
            lcArtist = (clsArtist)this[prKey];
            if (lcArtist != null)
                lcArtist.EditDetails();
            else
                MessageBox.Show("Sorry no artist by this name");
        }
       
        /// <summary>
        /// Create a new artist
        /// </summary>
        public void NewArtist()
        {
            clsArtist lcArtist = new clsArtist(this);
            try
            {
                if (lcArtist.Name != "")
                {
                    Add(lcArtist.Name, lcArtist);
                    MessageBox.Show("Artist added!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Duplicate Key!");
            }
        }
        
        /// <summary>
        /// Get the total value of the artists work
        /// </summary>
        /// <returns>total sum of each piece of work</returns>
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.TotalValue;
            }
            return lcTotal;
        }

        /// <summary>
        /// Saving the data to a local file
        /// </summary>
        public void Save()
        {
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

                lcFormatter.Serialize(lcFileStream, this);
                lcFileStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Save Error");
            }
        }

        /// <summary>
        /// Retrieving the local data file and updating display
        /// </summary>
        /// <returns></returns>
        public static clsArtistList Retrieve()
        {
            clsArtistList lcArtistList;

            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

                lcArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
                lcFileStream.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Retrieve Error");
                lcArtistList = new clsArtistList();
            }
            return lcArtistList;
        }
    }
}
