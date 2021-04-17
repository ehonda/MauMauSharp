using CyclicEnumerators;
using MauMauSharp.Boards;
using MauMauSharp.Cards;
using MauMauSharp.Players;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MauMauSharp.Games
{
    public class Game
    {
        private readonly IBoard _board;
        // TODO: This should be immutable, we don't want to remove players since we iterate over them
        // TODO: Do we really need this, or is the enumerator enough?
        private readonly List<IPlayer> _players;
        private readonly IEnumerator<IPlayer> _activePlayer;

        // TODO: Need to decide how we handle hidden info for the different players here
        public GameState GameState => new(_board.BoardState, ImmutableArray<Card>.Empty);

        public Game(IBoard board, IEnumerable<IPlayer> players)
        {
            _board = board;
            _players = players.ToList();
            _activePlayer = _players.Cycle().GetEnumerator();
        }

        public void NextTurn()
        {
            _activePlayer.MoveNext();

            // TODO: Need to check if the move is legal
            var card = _activePlayer.Current.PassOrPlayCard(GameState);

            if (card is not null)
                _board.PlayCard(card);
            else
                _activePlayer.Current.TakeCard(_board.DrawCardFromSupply());
        }
    }
}
