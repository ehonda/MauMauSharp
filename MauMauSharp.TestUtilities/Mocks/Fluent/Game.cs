using MauMauSharp.Boards;
using MauMauSharp.Players;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace MauMauSharp.TestUtilities.Mocks.Fluent
{
    public static class Game
    {
        public static Games.Game FromMocks(Mock<IBoard> board, IEnumerable<Mock<IPlayer>> players)
            => new(board.Object, players.Select(player => player.Object));
    }
}
