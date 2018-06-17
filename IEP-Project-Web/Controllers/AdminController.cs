using IEP_Project_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IEP_Project_Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            PortalParameters parameters;
            using (ApplicationDbContext db = ApplicationDbContext.Create())
            {
                parameters = db.PortalParameters.FirstOrDefault();
            }
            return View(parameters);
        }
        
        
        public ActionResult ReviewAuctions()
        {
            using (ApplicationDbContext dbContext = ApplicationDbContext.Create())
            {
                var searchQuery = from a in dbContext.Auctions
                                  where a.Status == "READY"
                                  select a;
                ViewBag.AuctionsToReview = searchQuery.ToList();
            }
                
            return View();
        }

        public void AcceptAuction(Guid id)
        {
            using (ApplicationDbContext dbContext = ApplicationDbContext.Create())
            {
                var auction = dbContext.Auctions.Where(a => a.AuctionId == id).FirstOrDefault<Auction>();

                if (auction != null)
                {
                    auction.Status = "OPENED";
                }

                dbContext.Entry(auction).State = System.Data.Entity.EntityState.Modified;

                dbContext.SaveChanges();
            }

            RedirectToAction("ReviewAuctions");
        }
        
    }
}
