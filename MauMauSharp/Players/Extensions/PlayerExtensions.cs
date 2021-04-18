using MauMauSharp.Boards;

namespace MauMauSharp.Players.Extensions
{
    public static class PlayerExtensions
    {
        public static void TakeNCardsFrom(this IPlayer player, IBoard board, int count)
        {
            for (int i = 0; i < count; i++)
                player.TakeCard(board.DrawCardFromSupply());
        }
    }
}
