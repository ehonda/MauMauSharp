using MauMauSharp.Cards;

namespace MauMauSharp.Games
{
    // TODO: Other values that should be included in GameState:
    //          - The player's hand (As Value object? / ValueSequence?)
    //          - The number of cards in the other player's hands
    public record GameState(Card TopPlayedCard, int NumberOfCardsInSupply);
}
