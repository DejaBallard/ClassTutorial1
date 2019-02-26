using System;
using System.Collections;

namespace Version_1_C
{
    class clsDateComparer : IComparer
    {
        /// <summary>
        /// Comparing date's of the artist work
        /// </summary>
        /// <param name="x">Artist's work</param>
        /// <param name="y">Artist's work</param>
        /// <returns>The result of comparing X and Y</returns>
        public int Compare(Object x, Object y)
        {
            clsWork lcWorkX = (clsWork)x;
            clsWork lcWorkY = (clsWork)y;
            DateTime lcDateX = lcWorkX.GetDate();
            DateTime lcDateY = lcWorkY.GetDate();

            return lcDateX.CompareTo(lcDateY);
        }
    }
}
