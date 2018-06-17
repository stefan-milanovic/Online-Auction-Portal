using IEP_Project_Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IEP_Project_Web.Controllers
{

    public class PartialWordComparator : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Contains(y);
        }

        public int GetHashCode(string obj)
        {
            return 0;
        }
    }
    public class HomeController : Controller
    {
        public ActionResult Index(string keywords, decimal? minimumPrice, decimal? maximumPrice, string statusChoice)
        {
            using (ApplicationDbContext dbContext = ApplicationDbContext.Create())
            {
                var searchQuery = from a in dbContext.Auctions
                                  where a.Status != "READY"
                                  select a;
                if (!String.IsNullOrEmpty(keywords))
                {
                    string[] wordsArray = keywords.Split(' ');

                    searchQuery = searchQuery.Where(a => wordsArray.Contains(a.Name, new PartialWordComparator()));
                    // check for user as well
                }

                if (minimumPrice != null)
                {
                    searchQuery = searchQuery.Where(a => a.CurrentPrice >= minimumPrice);
                }

                if (maximumPrice != null)
                {
                    searchQuery = searchQuery.Where(a => a.CurrentPrice <= maximumPrice);
                }

                if (!String.IsNullOrEmpty(statusChoice))
                {
                    switch (statusChoice)
                    {

                        case "Opened":
                            searchQuery = searchQuery.Where(a => a.Status == "OPENED");
                            break;
                        case "Completed":
                            searchQuery = searchQuery.Where(a => a.Status == "COMPLETED");
                            break;
                    }
                }

                IEnumerable<Auction> auctions = searchQuery.ToList();
                ViewBag.AuctionsList = auctions;
            }
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