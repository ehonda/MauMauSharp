using JetBrains.Annotations;
using MauMauSharp.Games;
using MauMauSharp.TestUtilities.Data.Boards;
using MauMauSharp.TestUtilities.Parsers.Fluent;

namespace MauMauSharp.TestUtilities.Data.Games
{
    [PublicAPI]
    public static class GameStateData
    {
        public static GameState WithArbitraryValues()
            => new(BoardStateData.WithArbitraryValues(), Deck.Empty());
    }
}
