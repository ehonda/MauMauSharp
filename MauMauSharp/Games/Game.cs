using System.Collections.Generic;
using System.Linq;
using MauMauSharp.Boards;
using MauMauSharp.Players;

namespace MauMauSharp.Games
{
    public class Game
    {
        private readonly IBoard _board;
        private readonly List<IPlayer> _players;

        public Game(IBoard board, IEnumerable<IPlayer> players)
        {
            _board = board;
            _players = players.ToList();
        }

        public void NextTurn()
        {
            // TODO: Players need to be able to pass (and draw a card) willingly!
            // TODO: Need to check if the move is legal
            // TODO: Use player whose turn it is
            var card = _players.First().PassOrPlayCard(
                // TODO: Use actual number of cards in supply
                new(_board.TopPlayedCard(), 0));
            _board.PlayCard(card);
        }
    }
}
