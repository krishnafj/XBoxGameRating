using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XBoxGameRating.Models;
using XBoxGameRating.DBModels;

namespace XBoxGameRating.Controllers
{
    public class HomeController : Controller
    {
        private readonly GameDBContext _context;

        public HomeController(GameDBContext context)
        {
            _context = context;
        }

        public List<Games> GetAllGames()
        {
            return _context.Games.ToList();
        }

        public Games GetGame(Guid id)
        {
            return _context.Games.First(x => x.Id == id);
        }

        public IActionResult Index()
        {
            var model = new GameModel();
            model.GameList = GetAllGames();

            return View(model);
        }

        public IActionResult VoteGame()
        {
            var model = new VoteGameModel();
            model.GameList = GetAllGames();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> VoteGame(VoteGameModel viewModel)
        {
            try
            {
                var gameVote = new GameVotes
                {
                    Id = Guid.NewGuid(),
                    GameId = viewModel.GameId,
                    Rating = viewModel.Rating
                };

                _context.GameVotes.Add(gameVote);
                await _context.SaveChangesAsync();

                //Update avarge rating for selected game
                var avgRating =  _context.GameVotes.Where(x => x.GameId == viewModel.GameId).Average(y => y.Rating);
                var game = GetGame(viewModel.GameId);
                game.Rating = Convert.ToInt32(avgRating);

                _context.Games.Update(game);
                await _context.SaveChangesAsync();

                return Redirect($"~/Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(viewModel);
        }


        public IActionResult Edit(Guid id)
        {
            var game = GetGame(id);
            var gameDetail = new GameDetailModel
            {
                id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Rating = game.Rating
            };

            return View(gameDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameDetailModel viewModel)
        {
            
            try
            {
                var gamedetail = GetGame(viewModel.id);
                gamedetail.Description = viewModel.Description;

                _context.Games.Update(gamedetail);
                await _context.SaveChangesAsync();
                return Redirect($"~/Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
