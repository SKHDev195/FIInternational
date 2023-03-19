using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    internal class TeamComparerByCurrentPoints : IComparer<Team>
    {
        /// <summary>
        /// Compares two teams based on their current points in a race.
        /// </summary>
        /// <param name="teamOne">The first race to compare.</param>
        /// <param name="teamTwo">The second race to compare.</param>
        /// <returns>The results of the comparison.</returns>
        public int Compare(Team teamOne, Team teamTwo)
        {
            if (teamOne.CurrentPoints == teamTwo.CurrentPoints) return 0;

            else if (teamOne.CurrentPoints < teamTwo.CurrentPoints) return 1;

            else return -1;
        }

    }
}
