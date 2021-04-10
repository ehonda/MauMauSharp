using MauMauSharp.Cards;
using MauMauSharp.Games;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MauMauSharp.Players
{
    public class Player : IPlayer
    {
        private readonly IPlayerIO _playerIo;
        private readonly List<Card> _hand;

        public Player(IPlayerIO playerIo, IEnumerable<Card> hand)
        {
            _playerIo = playerIo;
            _hand = hand.ToList();
        }

        /// <inheritdoc />
        public ImmutableArray<Card> Hand => _hand.ToImmutableArray();

        /// <inheritdoc />
        public Card? PassOrPlayCard(GameState gameState)
        {
            var card = _playerIo.ChooseCardToPlayOrPass(gameState, Hand);

            if (card is null)
                return null;

            if (_hand.Contains(card) is false)
                throw new InvalidOperationException("Can't pick card to play that is not in hand.");

            _hand.Remove(card);
            return card;
        }

        /// <inheritdoc />
        public void TakeCard(Card card)
        {
            _hand.Add(card);
        }
    }
}
