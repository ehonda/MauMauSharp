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

        public SingleRound(
            IBoard board,
            IEnumerable<(IPlayer Player, int CardsToDraw)> playersWithCardsToDraw)
        {
            var playersWithCardsToDrawArray = playersWithCardsToDraw.ToImmutableArray();

            foreach (var (player, cardsToDraw) in playersWithCardsToDrawArray)
                player.TakeNCardsFrom(board, cardsToDraw);

            _game = new(board, playersWithCardsToDrawArray.Select(tuple => tuple.Player));
        }

        /// <inheritdoc />
        public IEnumerable<IPlayer> Play()
        {
            yield break;
        }
    }
}
