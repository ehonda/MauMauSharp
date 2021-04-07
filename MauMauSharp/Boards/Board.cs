using MauMauSharp.Cards;
using MauMauSharp.Cards.Shufflers;
using System.Collections.Generic;

namespace MauMauSharp.Boards
{
    public class Board
    {
        private readonly IShuffler _shuffler;

        private Stack<Card> _played;
        private Stack<Card> _supply;

        public Board(IEnumerable<Card> cards, IShuffler shuffler)
        {
            _shuffler = shuffler;

            // TODO: Refactor so we can use ReplenishSupply here
            _supply = new(_shuffler.Shuffle(cards));
            _played = new();
            _played.Push(_supply.Pop());
        }

        public Card TopPlayedCard() => _played.Peek();

        public void PlayCard(Card card) => _played.Push(card);

        public Card DrawCardFromSupply()
        {
            if (_supply.Count == 0)
                ReplenishSupply();

            return _supply.Pop();
        }

        private void ReplenishSupply()
        {
            var topPlayed = _played.Pop();
            _supply = new(_shuffler.Shuffle(_played));
            _played = new();
            _played.Push(topPlayed);
        }
    }
}
