using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    public class DriverComparerByPlace : IComparer<Driver>
    {
        /// <summary>
        /// Compares two drivers based on their finishing position.
        /// </summary>
        /// <param name="driverOne">The first driver to compare.</param>
        /// <param name="driverTwo">The second driver to compare.</param>
        /// <returns></returns>
        public int Compare(Driver driverOne, Driver driverTwo)
        {
            if (driverOne.ResultInCurrentRace == driverTwo.ResultInCurrentRace) return 0;

            else if (driverOne.ResultInCurrentRace < driverTwo.ResultInCurrentRace) return -1;

            else return 1;
        }
    }
}
