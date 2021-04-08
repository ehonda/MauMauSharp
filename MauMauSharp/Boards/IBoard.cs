using MauMauSharp.Cards;

namespace MauMauSharp.Boards
{
    public interface IBoard
    {
        public Card TopPlayedCard();

        public void PlayCard(Card card);

        public Card DrawCardFromSupply();

        public BoardState GetState();
    }
}
