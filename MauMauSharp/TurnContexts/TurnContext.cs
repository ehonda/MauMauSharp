using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Players;
using MauMauSharp.Players.Extensions;

namespace MauMauSharp.TurnContexts
{
    public static class TurnContext
    {
        public static ITurnContext FromInitialTopPlayedCard(Card card, IPlayer activePlayer)
            => card switch
            {
                { Rank: Rank.Jack } => new Regular(activePlayer.ShapeShiftJack()),

                { Rank: Rank.Ace } => new Ace(card),

                { Rank: Rank.Seven } => new Seven(card),

                _ => new Regular(card)
            };
    }
}
