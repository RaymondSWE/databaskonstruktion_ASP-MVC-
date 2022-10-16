using databaskonstruktion_testr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace databaskonstruktion_testr.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private KidModel _KidModel;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _KidModel = new KidModel(_configuration);
        }

        public IActionResult Index()
        {
            ViewBag.AllKidTable = _KidModel.GetAllKids();
            ViewBag.AllToyTable = _KidModel.GetAllToys();
            return View();
        }
    }
}