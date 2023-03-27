using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    public class Player
    {

        public int Tickets { get; private set; } = 1000;

        /// <summary>
        /// Makes a bet for at least one of the drivers of a team to finish in a certain position.
        /// </summary>
        /// <param name="team">The team that the bet is placed for.</param>
        /// <param name="race">The race that the bet is placed for.</param>
        /// <param name="position">The position that the bet is placed for.</param>
        /// <param name="spentTickets">The number of tickets spent on the bet.</param>
        public Bet MakeABet(Team team, Race race, int position, int spentTickets)
        {
            this.Tickets -= spentTickets;

            Bet teamBet = new Bet(spentTickets, race, team);

            return teamBet;
        }

        /// <summary>
        /// Makes a bet for a driver to finish in a certain position.
        /// </summary>
        /// <param name="driver">The driver that the bet is placed for.</param>
        /// <param name="race">The race that the bet is placed for.</param>
        /// <param name="position">The position that the bet is placed for.</param>
        /// <param name="spentTickets">The number of tickets spent on the bet.</param>
        public Bet MakeABet(Driver driver, Race race, int position, int spentTickets)
        {
            this.Tickets -= spentTickets;

            Bet driverBet = new Bet(spentTickets, race, driver);

            return driverBet;
        }

        public void ReceivePayout(Bet bet, bool hasWon)
        {
            if (hasWon) Tickets -= bet.TicketAmount;

            else Tickets += bet.TicketAmount;
        }

        /// <summary>
        /// The basic constructor for the <c>Player</c> class.
        /// </summary>
        public Player() { }

    }
}
