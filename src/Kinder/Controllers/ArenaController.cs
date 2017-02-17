using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kinder.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Kinder.Controllers
{
    public class ArenaController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public static Player currentPlayer { get; set; }
        public static FoeLocation currentFoe { get; set; }
        public static string nextLocation { get; set; }
        public static int counter { get; set; }

        public ArenaController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            currentPlayer = _db.Players.Where(p => p.PlayerId == id).FirstOrDefault();
            return View(currentPlayer);
        }

        public IActionResult SchoolBus()
        {
            ViewBag.nextLocation = "BattleFirstGraders";
            return View(currentPlayer);
        }

        public IActionResult BattleFirstGraders()
        {
            if(counter <= 0)
            {
                currentFoe = new FoeLocation(0, "SchoolBus", "BattleFirstGraders", 2, 5);
                counter++;
            }

            currentPlayer.PlayerHP -= currentFoe.FoeAttack;
            currentFoe.FoeHP -= currentPlayer.PlayerAttack;

            if(currentFoe.FoeHP <= 0)
            {
                currentPlayer.Potion += 1;
                nextLocation = "ClassRoom";
            }
            else
            {
                nextLocation = "BattleFirstGraders";
            }

            ViewBag.foe = currentFoe;
            ViewBag.nextLocation = nextLocation;
            return View("SchoolBus", currentPlayer);
        }

        public IActionResult ClassRoom()
        {
            currentFoe = new Models.FoeLocation(1, "ClassRoom", "Bully", 3, 6);
            currentPlayer.PlayerHP -= 1;
            currentPlayer.PlayerDefense = 1;

            return View();
        }
    }
}
