using MauMauSharp.Players;
using System.Collections.Generic;

namespace MauMauSharp.Matches
{
    public interface IMatch
    {
        // TODO: Unsure if this is the right signature:
        //          - We might want to pass a ranking of players to get 3rd, 2nd, 1st finisher
        //          - We might want to pass players on construction
        //          - ...
        public IEnumerable<IPlayer> Play();
    }
}
