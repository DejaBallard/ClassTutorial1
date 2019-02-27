using System;
using System.Collections;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsWorksList : ArrayList
    {
        private static clsNameComparer _NameComparer = new clsNameComparer();
        private static clsDateComparer _DateComparer = new clsDateComparer();

        /// <summary>
        /// Sorting
        /// </summary>
        private byte _SortOrder;
        public byte SortOrder { get => _SortOrder; set => _SortOrder = value; }

        /// <summary>
        /// Adding new work to the list
        /// </summary>
        public void AddWork()
        {
            clsWork lcWork = clsWork.NewWork();
            if (lcWork != null)
            {
                Add(lcWork);
            }
        }
       
        /// <summary>
        /// double check if the user want's to delete the work. if so, remove.
        /// </summary>
        /// <param name="prIndex">index number of the selected work</param>
        public void DeleteWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.RemoveAt(prIndex);
                }
            }
        }
        
        /// <summary>
        /// Selecting the artist's work to be edited
        /// </summary>
        /// <param name="prIndex">index number of the selected work</param>
        public void EditWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsWork lcWork = (clsWork)this[prIndex];
                lcWork.EditDetails();
            }
            else
            {
                MessageBox.Show("Sorry no work selected #" + Convert.ToString(prIndex));
            }
        }

        /// <summary>
        /// Get total value of all the artist's work
        /// </summary>
        /// <returns>total value</returns>
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsWork lcWork in this)
            {
                lcTotal += lcWork.Value;
            }
            return lcTotal;
        }

        /// <summary>
        /// Sort work by name
        /// </summary>
         public void SortByName()
         {
             Sort(_NameComparer);
         }
    
        /// <summary>
        /// Sort work by date
        /// </summary>
        public void SortByDate()
        {
            Sort(_DateComparer);
        }
    }
}
