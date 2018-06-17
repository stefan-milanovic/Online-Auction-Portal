using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IEP_Project_Web.Models
{
    [Table("AuctionWinners")]
    public class AuctionWinners
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Auction Auction { get; set; }

        [Required]
        public ApplicationUser Winner { get; set; }
    }
}