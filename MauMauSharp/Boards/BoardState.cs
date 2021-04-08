using MauMauSharp.Cards;

namespace MauMauSharp.Boards
{
    // TODO: Add NumberOfCardsPlayed?
    public record BoardState(Card TopPlayedCard, int NumberOfCardsInSupply);
}
