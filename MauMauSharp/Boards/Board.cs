using MauMauSharp.Cards;
using MauMauSharp.Cards.Shufflers;
using System.Collections.Generic;

namespace MauMauSharp.Boards
{
    public class Board : IBoard
    {
        private readonly IShuffler _shuffler;

        private Stack<Card> _played;
        private Stack<Card> _supply = new();

        public Board(IEnumerable<Card> cards, IShuffler shuffler)
        {
            _shuffler = shuffler;

            _played = new(shuffler.Shuffle(cards));
            ReplenishSupply();
        }

        /// <inheritdoc />
        public BoardState BoardState => new(TopPlayedCard(), _supply.Count);

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
            _played = new(new[] { topPlayed });
        }
    }
}
