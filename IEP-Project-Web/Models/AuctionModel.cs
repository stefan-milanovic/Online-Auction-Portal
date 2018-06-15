using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IEP_Project_Web.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Auction")]
    public class Auction
    {
        [Key]
        public Guid AuctionId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Byte[] Image { get; set; }

        public long Duration { get; set; }

        [Required]
        [Display(Name = "Starting Price")]
        public decimal StartingPrice { get; set; }

        [Required]
        public decimal CurrentPrice { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? OpenedAt { get; set; }

        public DateTime? ClosedAt { get; set; }

        [Required]
        public string Status { get; set; }

        // public ApplicationUser Winner { get; set; }

        public IEnumerable<Bid> Bids { get; set; }

    }
}