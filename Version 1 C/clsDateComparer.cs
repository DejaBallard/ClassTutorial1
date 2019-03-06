using System;
using System.Collections.Generic;

namespace Version_1_C
{
    class clsDateComparer : IComparer<clsWork>
    {
        /// <summary>
        /// Comparing date's of the artist work
        /// </summary>
        /// <param name="x">Artist's work</param>
        /// <param name="y">Artist's work</param>
        /// <returns>The result of comparing X and Y</returns>
        public int Compare(clsWork x, clsWork y)
        {   
            DateTime lcDateX = x.Date;
            DateTime lcDateY = y.Date;

            return lcDateX.CompareTo(lcDateY);
        }
    }
}
