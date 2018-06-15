using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IEP_Project_Web.Models
{

    [System.ComponentModel.DataAnnotations.Schema.Table("TokenOrder")]
    public class TokenOrder
    {

        [System.ComponentModel.DataAnnotations.Key]
        public Guid TokenOrderId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public long Tokens { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Status { get; set; }
    }
}