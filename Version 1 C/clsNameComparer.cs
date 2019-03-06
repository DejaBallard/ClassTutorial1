using System;
using System.Collections.Generic;

namespace Version_1_C
{
    class clsNameComparer : IComparer<clsWork>
    {
        /// <summary>
        /// Comparing the names of the artist's work
        /// </summary>
        /// <param name="x">Name of work</param>
        /// <param name="y">Name of Work</param>
        /// <returns>Result of the comparing X with Y</returns>
        public int Compare(clsWork x, clsWork y)
        {
            string lcNameX = x.Name;
            string lcNameY = y.Name;

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
