using MauMauSharp.Cards;

namespace MauMauSharp.Boards
{
    public interface IBoard
    {
        public BoardState BoardState { get; }

        public Card TopPlayedCard();

        public void PlayCard(Card card);

        public Card DrawCardFromSupply();
    }
}
