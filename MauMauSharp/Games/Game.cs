using CyclicEnumerators;
using MauMauSharp.Boards;
using MauMauSharp.Players;
using MauMauSharp.Players.Extensions;
using MauMauSharp.TurnContexts;
using System;
using System.Collections.Generic;
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
        private ITurnContext _turnContext;

        // TODO: Need to decide how we handle hidden info for the different players here
        public GameState GameState => new(_board.BoardState, _turnContext.PlayableCards);

        public Game(IBoard board, IEnumerable<IPlayer> players)
        {
            _board = board;
            _players = players.ToList();
            _activePlayer = _players.Cycle().GetEnumerator();

            // TODO: If TopPlayedCard is a Jack, the starting player gets to decide the suit
            // TODO: Handle Seven / Ace starts!
            _turnContext = new Regular(_board.TopPlayedCard());
        }

        public void NextTurn()
        {
            // TODO: Skip players with hand size == 0
            _activePlayer.MoveNext();

            var card = _activePlayer.Current.PassOrPlayCard(GameState);

            if (card is not null && GameState.PlayableCards.Contains(card) is false)
                throw new InvalidOperationException($"Illegal move. Card {card} was not playable.");

            if (card is not null)
                _board.PlayCard(card);
            else
                _activePlayer.Current.TakeNCardsFrom(_board, _turnContext.CardsToDrawOnPass);

            _turnContext = _turnContext.NextTurnContext(card, _activePlayer.Current);

            // TODO: Check if only one player with hand size > 0 is left
        }
    }
}
