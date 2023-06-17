using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeamPlayers.DataAbstractionLayer;
using TeamPlayers.Models;

namespace TeamPlayers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpGet("login")]
        public IActionResult Login(string name)
        {
            DAL dal = new DAL();
            List<string> names = new List<string>();
            names.Add("john");
            names.Add("jack");
            names.Add("jill");
            if (names.Contains(name))
                return Ok(1);
            return Ok(0); // Allow them anyway
        }

        [HttpGet("playersWithName")]
        public IActionResult GetPlayersByName(string enteredName )
        {
            DAL dal = new DAL();
            List<Player> players = DAL.getPlayerFromStatement("select * from Player where name like '%enteredName%';"); //TODO: Write select
            return Ok(players);
        }

        [HttpGet("players")]
        public IActionResult GetPlayers(string enteredName)
        {
            DAL dal = new DAL();
            List<Player> players = DAL.getPlayerFromStatement("select * from Player;"); //TODO: Write select
            return Ok(players);
        }
    }
}