using MauMauSharp.Cards;
using MauMauSharp.Cards.Shufflers;
using System.Collections.Generic;

namespace MauMauSharp.Boards
{
    public class Board
    {
        private readonly IShuffler _shuffler;

        private readonly Stack<Card> _played;
        private readonly Stack<Card> _supply;

        public Board(IEnumerable<Card> cards, IShuffler shuffler)
        {
            _shuffler = shuffler;

            _supply = new(_shuffler.Shuffle(cards));
            _played = new();
            _played.Push(_supply.Pop());
        }

        public Card TopPlayedCard() => _played.Peek();

        public void PlayCard(Card card) => _played.Push(card);
    }
}
