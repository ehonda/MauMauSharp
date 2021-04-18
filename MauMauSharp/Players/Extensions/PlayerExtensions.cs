using MauMauSharp.Boards;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;

namespace MauMauSharp.Players.Extensions
{
    public static class PlayerExtensions
    {
        public static void TakeNCardsFrom(this IPlayer player, IBoard board, int count)
        {
            for (int i = 0; i < count; i++)
                player.TakeCard(board.DrawCardFromSupply());
        }
        
        public static Card ShapeShiftJack(this IPlayer player)
            => new(Rank.Jack, player.NameSuitToShapeShiftJackInto());
    }
}
