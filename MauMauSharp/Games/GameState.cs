using System.Collections.Generic;
using MauMauSharp.Boards;
using MauMauSharp.Cards;

namespace MauMauSharp.Games
{
    // TODO: Other values that should be included in GameState:
    //          - The player's hand (As Value object? / ValueSequence?)
    //          - The number of cards in the other player's hands
    //          - A list of all playable cards / current valid move validator
    public record GameState(BoardState BoardState, IEnumerable<Card> PlayableCards);
}
