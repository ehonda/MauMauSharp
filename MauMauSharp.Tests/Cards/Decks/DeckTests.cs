using MauMauSharp.Cards;
using MauMauSharp.Cards.Decks;
using MauMauSharp.Cards.Enums;
using NUnit.Framework;

namespace MauMauSharp.Tests.Cards.Decks
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void PiquetPackSpecification()
            => Assert.That(
                Deck.PiquetPack,
                Is.EquivalentTo(
                    new Card[]
                    {
                        new(Rank.Seven, Suit.Spades),
                        new(Rank.Eight, Suit.Spades),
                        new(Rank.Nine, Suit.Spades),
                        new(Rank.Ten, Suit.Spades),
                        new(Rank.Jack, Suit.Spades),
                        new(Rank.Queen, Suit.Spades),
                        new(Rank.King, Suit.Spades),
                        new(Rank.Ace, Suit.Spades),

                        new(Rank.Seven, Suit.Hearts),
                        new(Rank.Eight, Suit.Hearts),
                        new(Rank.Nine, Suit.Hearts),
                        new(Rank.Ten, Suit.Hearts),
                        new(Rank.Jack, Suit.Hearts),
                        new(Rank.Queen, Suit.Hearts),
                        new(Rank.King, Suit.Hearts),
                        new(Rank.Ace, Suit.Hearts),

                        new(Rank.Seven, Suit.Diamonds),
                        new(Rank.Eight, Suit.Diamonds),
                        new(Rank.Nine, Suit.Diamonds),
                        new(Rank.Ten, Suit.Diamonds),
                        new(Rank.Jack, Suit.Diamonds),
                        new(Rank.Queen, Suit.Diamonds),
                        new(Rank.King, Suit.Diamonds),
                        new(Rank.Ace, Suit.Diamonds),

                        new(Rank.Seven, Suit.Clubs),
                        new(Rank.Eight, Suit.Clubs),
                        new(Rank.Nine, Suit.Clubs),
                        new(Rank.Ten, Suit.Clubs),
                        new(Rank.Jack, Suit.Clubs),
                        new(Rank.Queen, Suit.Clubs),
                        new(Rank.King, Suit.Clubs),
                        new(Rank.Ace, Suit.Clubs),
                    }));
    }
}
