using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IEP_Project_Web.Models;

namespace IEP_Project_Web.Controllers
{
    public class AuctionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Auctions
        public ActionResult Index()
        {
            return View(db.Auctions.ToList());
        }

        // GET: Auctions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }

            return View(auction);
        }

        // GET: Auctions/Create
        public ActionResult Create()
        {
            AuctionCreateViewModel auction = new AuctionCreateViewModel
            {
                Duration = 5 // default duration here
            };

            return View(auction);
        }

        // POST: Auctions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // CurrentPrice,CreatedAt,OpenedAt,ClosedAt,Status
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Image,Duration,StartingPrice")] AuctionCreateViewModel auctionViewModel)
        {
            if (ModelState.IsValid)
            {
                Auction auction = new Auction
                {
                    AuctionId = Guid.NewGuid(),
                    Name = auctionViewModel.Name,
                    Duration = auctionViewModel.Duration,
                    StartingPrice = auctionViewModel.StartingPrice,
                    CurrentPrice = auctionViewModel.StartingPrice,
                    CreatedAt = DateTime.UtcNow,
                    Status = "READY"
                };

                // Check if the file is an image -- if it is, persist it.

                var uploadedFile = auctionViewModel.Image;
                var uploadedFileBytes = new byte[uploadedFile.ContentLength];
                uploadedFile.InputStream.Read(uploadedFileBytes, 0, uploadedFileBytes.Length);

                bool isImageFile;   

                try
                {
                    Image.FromStream(new System.IO.MemoryStream(uploadedFileBytes)).Dispose();
                    isImageFile = true;
                }
                catch (OutOfMemoryException)
                {
                    isImageFile = false;
                }

                // If the file is not an image, return with an error.
                if (!isImageFile)
                {
                    ModelState.AddModelError("ImageToUpload", "The file has to be an image!");
                    return View(auctionViewModel);
                }

                // Otherwise remember the image.
                auction.Image = uploadedFileBytes;

                db.Auctions.Add(auction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auctionViewModel);
        }

        // GET: Auctions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // POST: Auctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuctionId,Name,Image,Duration,StartingPrice,CurrentPrice,CreatedAt,OpenedAt,ClosedAt,Status")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auction);
        }

        // GET: Auctions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // POST: Auctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Auction auction = db.Auctions.Find(id);
            db.Auctions.Remove(auction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
