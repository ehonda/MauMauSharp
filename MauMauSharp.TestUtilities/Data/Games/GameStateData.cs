using JetBrains.Annotations;
using MauMauSharp.Games;
using MauMauSharp.TestUtilities.Data.Boards;
using System.Collections.Immutable;
using Card = MauMauSharp.Cards.Card;

namespace MauMauSharp.TestUtilities.Data.Games
{
    [PublicAPI]
    public static class GameStateData
    {
        public static GameState WithArbitraryValues()
            => new(BoardStateData.WithArbitraryValues(), ImmutableArray<Card>.Empty);
    }
}
