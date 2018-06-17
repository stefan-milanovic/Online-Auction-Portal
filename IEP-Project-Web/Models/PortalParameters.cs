using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace IEP_Project_Web.Models
{
    [Table("PortalParameters")]
    public class PortalParameters
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Default number of auctions to display")]
        public long DefaultAuctionsToDisplay { get; set; }

        [Required]
        [Display(Name = "Default duration of an auction")]
        public long DefaultAuctionDuration { get; set; }

        [Required]
        [Display(Name = "Silver Package token amount")]
        public long SilverPackageTokenAmount { get; set; }

        [Required]
        [Display(Name = "Gold Package token amount")]
        public long GoldPackageTokenAmount { get; set; }

        [Required]
        [Display(Name = "Platinum Package token amount")]
        public long PlatinumPackageTokenAmount { get; set; }

        [Required]
        [Display(Name = "Currency of the system")]
        public decimal Currency { get; set; }
        [Required]
        [Display(Name = "Value of one (1) token")]
        public decimal TokenValue { get; set; }

    }
}