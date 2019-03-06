using System;
using System.Collections.Generic;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtistList : SortedList<string, clsArtist>
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
                //MessageBox.Show("Sorry no artist by this name");
                throw new Exception("Sorry no artist by this name");
        }
       
        /// <summary>
        /// Create a new artist
        /// </summary>
        public bool NewArtist()
        {
            clsArtist lcArtist = new clsArtist(this);
            try
            {
                if (lcArtist.Name != "")
                {
                    Add(lcArtist.Name, lcArtist);
                    return true;
                    //MessageBox.Show("Artist added!");
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
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
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcFormatter.Serialize(lcFileStream, this);
                lcFileStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
                lcFileStream.Close();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lcArtistList;
        }
    }
}
