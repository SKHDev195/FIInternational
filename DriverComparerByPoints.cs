using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    internal class DriverComparerByPoints
    {
        /// <summary>
        /// Compares two drivers based on their current championship points.
        /// </summary>
        /// <param name="driverOne">The first driver to compare.</param>
        /// <param name="driverTwo">The second driver to compare.</param>
        /// <returns>The result of the comparison of the two drivers.</returns>
        public int Compare(Driver driverOne, Driver driverTwo)
        {
            if (driverOne.CurrentPoints == driverTwo.CurrentPoints) return 0;

            else if (driverOne.CurrentPoints < driverTwo.CurrentPoints) return -1;

            else return 1;
        }

    }
}
