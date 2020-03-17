using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBoxGameRating.DBModels
{
    public class GameVotes
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Games Game { get; set; }
        public int Rating { get; set; }
    }
}
