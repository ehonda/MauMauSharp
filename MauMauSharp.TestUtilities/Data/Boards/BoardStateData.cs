using JetBrains.Annotations;
using MauMauSharp.Boards;
using MauMauSharp.TestUtilities.Parsers.Fluent;

namespace MauMauSharp.TestUtilities.Data.Boards
{
    [PublicAPI]
    public static class BoardStateData
    {
        public static BoardState WithArbitraryValues()
            => new(Card.From("As"), 0);
    }
}
