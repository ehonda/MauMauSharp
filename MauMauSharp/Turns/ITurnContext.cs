using MauMauSharp.Cards;
using MauMauSharp.Players;
using System.Collections.Immutable;

namespace MauMauSharp.Turns
{
    public interface ITurnContext
    {
        public ImmutableArray<Card> PlayableCards { get; }

        public int CardsToDrawOnPass { get; }

        public ITurnContext NextTurnContext(Card? playedCard, IPlayer activePlayer);
    }
}
