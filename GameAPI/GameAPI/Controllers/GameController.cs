using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]GameModel model)
        {
            _gameService.Add(model);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameModel>> Get()
        {
            return Ok(_gameService.Get());
        }
    }

    public interface IGameService
    {
        void Add(GameModel game);
        IEnumerable<GameModel> Get();
    }

    public class GameService : IGameService
    {
        private static int num = 0;
        private readonly List<GameModel> _games;

        public GameService()
        {
            num++;
            _games = new List<GameModel>()
            {
                new GameModel()
                {
                    Id = 1,
                    Name = num.ToString()
                }
            };
        }
        public void Add(GameModel game)
        {
            _games.Add(new GameModel()
            {
                Id = _games.Max(x => x.Id) + 1,
                Name = game.Name
            });
        }

        public IEnumerable<GameModel> Get()
        {
            return _games;
        }
    }

    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}