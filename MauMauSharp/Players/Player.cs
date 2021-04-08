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
            => ChooseCardToPlay(gameState);

        protected abstract Card ChooseCardToPlay(GameState gameState);
    }
}