using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IEP_Project_Web.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Bid")]
    public class Bid
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid BidId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public Auction Auction { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public long Tokens { get; set; }

    }

}