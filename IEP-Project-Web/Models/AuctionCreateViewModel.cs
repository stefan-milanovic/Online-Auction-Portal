using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IEP_Project_Web.Models
{
    public class AuctionCreateViewModel
    {
        [Required(ErrorMessage = "The auction name field is required.")]
        [StringLength(50, ErrorMessage = "The First Name must be less than {1} characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The auction image file is required.")]
        [Display(Name = "Product Image")]
        public HttpPostedFileBase Image { get; set; }
        
        [Required(ErrorMessage = "The duration field is required.")]
        [Display(Name = "Duration (s)")]
        public long Duration { get; set; }

        [Required(ErrorMessage = "The starting price field is required.")]
        [Display(Name = "Starting Price ($)")]
        public decimal StartingPrice { get; set; }
        
    }
}