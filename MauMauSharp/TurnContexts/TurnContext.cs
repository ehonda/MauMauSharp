using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Players;

namespace MauMauSharp.TurnContexts
{
    public static class TurnContext
    {
        public static ITurnContext FromInitialTopPlayedCard(Card card, IPlayer activePlayer)
            => card switch
            {
                { Rank: Rank.Jack } => new Regular(new(
                    Rank.Jack,
                    activePlayer.NameSuitToShapeShiftJackInto())),

                _ => new Regular(card)
            };
    }
}
