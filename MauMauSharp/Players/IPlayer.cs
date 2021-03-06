using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Games;
using System.Collections.Immutable;

namespace MauMauSharp.Players
{
    public interface IPlayer
    {
        // TODO: Do we really need this property? Evaluate!
        public ImmutableArray<Card> Hand { get; }

        // TODO: Use Maybe<Card> here
        public Card? PassOrPlayCard(GameState gameState);

        public void TakeCard(Card card);

        // TODO: Better name?
        public Suit NameSuitToShapeShiftJackInto();
    }
}
