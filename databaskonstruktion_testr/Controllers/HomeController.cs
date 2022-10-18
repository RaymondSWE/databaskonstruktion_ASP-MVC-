﻿using databaskonstruktion_testr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace databaskonstruktion_testr.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private KidModel _KidModel;
        private ToyModel _ToyModel;
        private WishlistModel _WishlistModel;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _KidModel = new KidModel(_configuration);
            _ToyModel = new ToyModel(_configuration);
            _WishlistModel = new WishlistModel(_configuration);
        }

        public IActionResult Index()
        {
            ViewBag.AllKidTable = _KidModel.GetAllKids();
            ViewBag.AllToyTable = _ToyModel.GetAllToys();
            ViewBag.AllWishlistTable = _WishlistModel.GetAllWishlist();
            return View();
        }

        public IActionResult Deletekid(string PNR)
        {
            _KidModel.DeleteKid(PNR);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteToy(int toyId)
        {
            _KidModel.DeleteToy(toyId);
            return RedirectToAction("Index");
        }
    }
}