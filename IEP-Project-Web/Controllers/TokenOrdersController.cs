using IEP_Project_Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IEP_Project_Web.Controllers
{
    public class TokenOrdersController : Controller
    {
        // GET: TokenOrders
        //[Authorize(Roles = "User")]
        public ActionResult PurchaseTokens()
        {
            // get portal parameters for package value
            using (var dbContext = ApplicationDbContext.Create())
            {
                var parameters = dbContext.PortalParameters.FirstOrDefault();
                ViewBag.SilverTokens = parameters.SilverPackageTokenAmount;
                ViewBag.GoldTokens = parameters.GoldPackageTokenAmount;
                ViewBag.PlatinumTokens = parameters.PlatinumPackageTokenAmount;

                ViewBag.SilverValue = parameters.SilverPackageTokenAmount * parameters.TokenValue;
                ViewBag.GoldValue = parameters.GoldPackageTokenAmount * parameters.TokenValue;
                ViewBag.PlatinumValue = parameters.PlatinumPackageTokenAmount * parameters.TokenValue;

                ViewBag.BaseUrl = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            }

            return View();
        }

        
        
        public ActionResult AttemptPurchase(long? tokens, decimal? price)
        {
            if (tokens == null || price == null)
            {
                return RedirectToAction("MyTokenOrders"); // push error notif
            }

            var userId = User.Identity.GetUserId();

            if (userId == null)
            {
                return RedirectToAction("MyTokenOrders"); // error
            }

            // TokenOrder order = Data.createNewOrder();

            ApplicationUser currentUser;
            TokenOrder order;

            using (ApplicationDbContext dbContext = ApplicationDbContext.Create())
            {
                currentUser = dbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
                if (currentUser == null)
                {
                    return RedirectToAction("MyTokenOrders"); // should never occur
                }

                order = new TokenOrder
                {
                    TokenOrderId = Guid.NewGuid(),
                    Price = (decimal)price,
                    Tokens = (long)tokens,
                    User = currentUser,
                    Status = "SUBMITTED"
                };

                dbContext.TokenOrders.Add(order);
                dbContext.SaveChanges();
            }

            return Redirect(String.Format("https://stage.centili.com/widget/WidgetModule?api=13f23a286790a7b255c574124f1d25cf&country=rs&countrylock=true&clientid={0}", order.TokenOrderId));
        }

        public ActionResult MyTokenOrders()
        {
            var currentUser = User.Identity.GetUserId();

            IEnumerable<TokenOrder> orders;
            using (ApplicationDbContext dbContext = ApplicationDbContext.Create())
            {
                orders = dbContext.TokenOrders.Where(to => to.User.Id == currentUser).ToList();
            }
            return View(orders);
        }

        public ActionResult PaymentCallback(string orderId, string status)
        {
            if (String.IsNullOrEmpty(orderId) || String.IsNullOrEmpty(status))
            {
                return View("MyTokenOrders");
            }
            
            using (ApplicationDbContext dbContext = ApplicationDbContext.Create())
            {
                var order = dbContext.TokenOrders.Where(to => to.TokenOrderId.ToString() == orderId).FirstOrDefault();
                if (order == null)
                {
                    // this should never happen
                }

                if (status == "success")
                {
                    order.Status = "COMPLETED";
                }
                else
                {
                    order.Status = "CANCELLED";
                }

                dbContext.Entry(order).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            

            return View("MyTokenOrders");
        }
    }
}