using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBoxGameRating.DBModels
{
    public class Games
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
