using System;
using XBoxGameRating.DBModels;

namespace XBoxGameRating
{
    public static class SeedData
    {
        public static void AddTestData(GameDBContext context)
        {
            var game1 = new Games
            {
                Id = Guid.NewGuid(),
                Title = "Gears of War 3",
                Description = "Lorem ipsum dolot sit amet. consectetur asipiscing elit",
                Rating = 5
            };

            context.Games.Add(game1);

            var gameVote1 = new GameVotes
            {
                Id = Guid.NewGuid(),
                Game = game1,
                Rating = 5
            };
            context.GameVotes.Add(gameVote1);

            var game2 = new Games
            {
                Id = Guid.NewGuid(),
                Title = "Step Up for Kinnect",
                Description = "Brand new amazing Kinnect game",
                Rating = 1
            };

            context.Games.Add(game2);

            var gameVote2 = new GameVotes
            {
                Id = Guid.NewGuid(),
                Game = game2,
                Rating = 1
            };
            context.GameVotes.Add(gameVote2);

            var game3 = new Games
            {
                Id = Guid.NewGuid(),
                Title = "Dead Island",
                Description = "Latest action game. Amazing reviews.",
                Rating = 3
            };

            context.Games.Add(game3);

            var gameVote3 = new GameVotes
            {
                Id = Guid.NewGuid(),
                Game = game2,
                Rating = 3
            };
            context.GameVotes.Add(gameVote3);
            context.SaveChanges();
        }
    }
}
