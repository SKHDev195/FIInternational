using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    internal class DriverComparerByTotalPoints : IComparer<Driver>
    {

        /// <summary>
        /// Compares two drivers based on their total championship points.
        /// </summary>
        /// <param name="driverOne">The first driver to compare.</param>
        /// <param name="driverTwo">The second driver to compare.</param>
        /// <returns>The result of the comparison of the two drivers.</returns>
        public int Compare(Driver driverOne, Driver driverTwo)
        {
            if (driverOne.TotalPoints == driverTwo.TotalPoints) return 0;

            else if (driverOne.TotalPoints < driverTwo.TotalPoints) return 1;

            else return -1;
        }

    }

}

