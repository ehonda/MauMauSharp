using MauMauSharp.Cards;
using MauMauSharp.Games;
using System.Collections.Immutable;

namespace MauMauSharp.Players
{
    // TODO: Better name!
    // ReSharper disable once InconsistentNaming
    public interface IPlayerIO
    {
        // TODO: Can probably pass hand as part of GameState?
        public Card? ChooseCardToPlayOrPass(GameState gameState, ImmutableArray<Card> hand);
    }
}
