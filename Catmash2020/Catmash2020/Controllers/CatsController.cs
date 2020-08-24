using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catmash2020.Models;
using Catmash2020.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catmash2020.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatsController : ControllerBase
    {
        private readonly ILogger<CatsController> _logger;
        private readonly CatService _catService;

        public CatsController(ILogger<CatsController> logger, CatService catService)
        {
            _logger = logger;
            _catService = catService;
        }

        [HttpGet]
        public IEnumerable<Cat> GetAll() => _catService.GetAll();

        [HttpGet("Ranking")]
        public IEnumerable<CatVotes> GetRanking() => _catService.GetByVotes();

        [HttpGet("{id}")]
        public Cat Get(string id) => _catService.GetCat(id);

        [HttpPost]
        public IActionResult AddVote([FromBody]Cat cat) 
        {
            _catService.AddVote(cat.Id);
            return Ok();
        }
    }
}
