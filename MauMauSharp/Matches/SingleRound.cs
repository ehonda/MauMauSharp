using MauMauSharp.Boards;
using MauMauSharp.Games;
using MauMauSharp.Players;
using MauMauSharp.Players.Extensions;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MauMauSharp.Matches
{
    public class SingleRound : IMatch
    {
        private readonly Game _game;
        private readonly ImmutableArray<IPlayer> _players;

        public SingleRound(
            IBoard board,
            IEnumerable<(IPlayer Player, int CardsToDraw)> playersWithCardsToDraw)
        {
            var playersWithCardsToDrawArray = playersWithCardsToDraw.ToImmutableArray();

            foreach (var (player, cardsToDraw) in playersWithCardsToDrawArray)
                player.TakeNCardsFrom(board, cardsToDraw);

            _players = playersWithCardsToDrawArray
                .Select(tuple => tuple.Player)
                .ToImmutableArray();

            _game = new(board, _players);
        }

        /// <inheritdoc />
        public IEnumerable<IPlayer> Play()
        {
            var inGame = _players.ToList();
            var finished = new List<IPlayer>();
            
            while (inGame.Count > 1)
            {
                _game.NextTurn();

                // With normal rules this should only ever be one player
                var finishedThisRound = inGame
                    .Where(player => player.Hand.Any() is false)
                    .ToImmutableArray();

                foreach (var player in finishedThisRound)
                {
                    inGame.Remove(player);
                    finished.Add(player);
                }
            }

            return finished.Append(inGame.Single());
        }
    }
}
