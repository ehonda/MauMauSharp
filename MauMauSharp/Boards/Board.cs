using System.Collections.Generic;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Shufflers;

namespace MauMauSharp.Boards
{
    public class Board
    {
        private readonly IShuffler _shuffler;

        // TODO: Better names!
        private readonly Stack<Card> _discard;
        private readonly Stack<Card> _deck;

        public Board(IEnumerable<Card> cards, IShuffler shuffler)
        {
            _shuffler = shuffler;

            _deck = new(_shuffler.Shuffle(cards));
            _discard = new();
            _discard.Push(_deck.Pop());
        }

        // TODO: Better name?
        public Card TopCard() => _discard.Peek();
    }
}
