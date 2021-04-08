using MauMauSharp.Cards;
using MauMauSharp.Games;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MauMauSharp.Players
{
    public abstract class Player : IPlayer
    {
        private readonly List<Card> _hand;

        protected Player(IEnumerable<Card> hand)
        {
            _hand = hand.ToList();
        }

        /// <inheritdoc />
        public ImmutableArray<Card> Hand => _hand.ToImmutableArray();

        /// <inheritdoc />
        public Card? PassOrPlayCard(GameState gameState)
        {
            var card = ChooseCardToPlayOrPass(gameState);
            if (card is null)
                return null;

            // TODO: Catch and rethrow? For better error message
            _hand.Remove(card);
            return card;
        }

        protected abstract Card? ChooseCardToPlayOrPass(GameState gameState);
    }
}
