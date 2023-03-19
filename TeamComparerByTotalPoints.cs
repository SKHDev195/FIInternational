using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    internal class TeamComparerByTotalPoints : IComparer<Team>
    {

        /// <summary>
        /// Compares two teams based on their total championship points.
        /// </summary>
        /// <param name="teamOne">The first race to compare.</param>
        /// <param name="teamTwo">The second race to compare.</param>
        /// <returns>The results of the comparison.</returns>
        public int Compare(Team teamOne, Team teamTwo)
        {
            if (teamOne.TotalPoints == teamTwo.TotalPoints) return 0;

            else if (teamOne.TotalPoints < teamTwo.TotalPoints) return 1;

            else return -1;
        }


    }
}
