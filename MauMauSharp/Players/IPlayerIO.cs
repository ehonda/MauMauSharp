using MauMauSharp.Cards;
using MauMauSharp.Games;
using System.Collections.Immutable;

namespace MauMauSharp.Players
{
    // TODO: Better name!
    public interface IPlayerIO
    {
        // TODO: Can probably pass hand as part of GameState?
        // NOTE: This must return a card that is a) in hand b) valid to play,
        //       otherwise upstream (Player / Board) will throw
        public Card? ChooseCardToPlayOrPass(GameState gameState, ImmutableArray<Card> hand);
    }
}
