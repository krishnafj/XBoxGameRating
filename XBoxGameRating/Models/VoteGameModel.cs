using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBoxGameRating.DBModels;

namespace XBoxGameRating.Models
{
    public class VoteGameModel
    {
        public List<Games> GameList { get; set; }
        public Guid GameId { get; set; }
        public int Rating { get; set; }
    }
}
