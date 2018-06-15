using IEP_Project_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IEP_Project_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string keywords, decimal? minimumPrice, decimal? maximumPrice, int? statusChoice)
        {
            ApplicationDbContext dbContext = ApplicationDbContext.Create();
            var searchQuery = from a in dbContext.Auctions
                              where a.Status != "READY"
                              select a;
            if (!String.IsNullOrEmpty(keywords))
            {
                string[] wordsArray = keywords.Split(' ');

                searchQuery.Where(a => wordsArray.Contains(a.Name));
                // check for user as well
            }

            if (minimumPrice != null)
            {
                searchQuery.Where(a => a.CurrentPrice >= minimumPrice);
            }

            if (maximumPrice != null)
            {
                searchQuery.Where(a => a.CurrentPrice >= minimumPrice);
            }

            if (statusChoice != null)
            {
                switch (statusChoice)
                {

                    case 1:
                        searchQuery.Where(a => a.Status == "OPENED");
                        break;
                    case 2:
                        searchQuery.Where(a => a.Status == "COMPLETED");
                        break;
                }
            }

            IEnumerable<Auction> auctions = searchQuery.ToList();
            ViewBag.AuctionsList = auctions;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This project was created for the course Infrastructure of E-Business in 2018.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Test.";

            return View();
        }

    }
}