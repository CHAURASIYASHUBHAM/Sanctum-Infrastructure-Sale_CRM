using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sell_CRM.Models
{
    public class CustomerEnquiry
    {

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only letters allowed")]
        public string CustomerName { get; set; }

        [Required]
        public string BuildingName { get; set; }

        [RegularExpression(@"^[1-9][0-9]{9}$", ErrorMessage = "Invalid mobile")]
        public string Mobile { get; set; }

        public string CountryCode { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required]
        public string Configuration { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Enter valid Flat No")]
        public int? FlatNo { get; set; }

        public string Budget { get; set; }

        [Required]
        public string PaymentMode { get; set; }

        [Required]
        public string Timeline { get; set; }

        [Required]
        public string SourceType { get; set; }

        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "Only letters allowed")]
        public string BrokerName { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter valid 10 digit mobile")]
        public string BrokerMobile { get; set; }
    }
}
