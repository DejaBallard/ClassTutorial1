using System;
using System.Collections;

namespace Version_1_C
{
    class clsNameComparer : IComparer
    {
        /// <summary>
        /// Comparing the names of the artist's work
        /// </summary>
        /// <param name="x">Name of work</param>
        /// <param name="y">Name of Work</param>
        /// <returns>Result of the comparing X with Y</returns>
        public int Compare(Object x, Object y)
        {
            clsWork workClassX = (clsWork)x;
            clsWork workClassY = (clsWork)y;
            string lcNameX = workClassX.GetName();
            string lcNameY = workClassY.GetName();

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
