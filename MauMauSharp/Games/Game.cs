using CyclicEnumerators;
using MauMauSharp.Boards;
using MauMauSharp.Players;
using MauMauSharp.Players.Extensions;
using MauMauSharp.TurnContexts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MauMauSharp.Games
{
    public class Game
    {
        private readonly IBoard _board;
        private readonly ImmutableArray<IPlayer> _players;
        private readonly IEnumerator<IPlayer> _activePlayer;
        private ITurnContext _turnContext;

        // TODO: Need to decide how we handle hidden info for the different players here
        //          - GameStateRenderer that displays info from one player's perspective
        public GameState GameState => new(_board.BoardState, _turnContext.PlayableCards);

        // TODO: Creation from static function, where players are dealt hands etc.
        public Game(IBoard board, IEnumerable<IPlayer> players)
        {
            _board = board;
            _players = players.ToImmutableArray();
            _activePlayer = _players.Cycle().GetEnumerator();

            _turnContext = TurnContext.FromInitialTopPlayedCard(
                _board.TopPlayedCard(),
                _players.First());
        }

        // TODO: Use some kind of Log-Creation mechanism:
        //          Example from Player A's perspective:
        //          Player A draws Kc
        //          Player B draws a Card
        //       -> Maybe better: Log all revealed and retrieve view from player's perspective
        public void NextTurn()
        {
            _activePlayer.MoveNext();
            while (_activePlayer.Current.Hand.Any() is false)
            {
                _activePlayer.MoveNext();
            }

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
