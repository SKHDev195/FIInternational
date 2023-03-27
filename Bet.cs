using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    public class Bet
    {

        public int TicketAmount { get; set; }

        public Race BetRace { get; set; }

        public Driver BetDriver { get; set; }

        public Team BetTeam { get; set; }

        /// <summary>
        /// The constructor for bets made on drivers.
        /// </summary>
        /// <param name="ticketAmount">The tickets spent on the bet.</param>
        /// <param name="race">The race that the bet is made for.</param>
        /// <param name="driver">The driver that the bet is made for.</param>
        public Bet(int ticketAmount, Race race, Driver driver)
        {
            TicketAmount = ticketAmount;
            BetRace = race;
            BetDriver = driver;
        }

        /// <summary>
        /// The constructor for bets made on teams.
        /// </summary>
        /// <param name="ticketAmount">The tickets spent on the bet.</param>
        /// <param name="race">The race that the bet is made for.</param>
        /// <param name="team">The driver that the bet is made for.</param>
        public Bet(int ticketAmount, Race race, Team team)
        {
            TicketAmount = ticketAmount;
            BetRace = race;
            BetTeam = team;
        }


    }
}
