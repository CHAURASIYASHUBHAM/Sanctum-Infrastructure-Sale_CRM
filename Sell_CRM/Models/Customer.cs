using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmailSend.Models
{
    public class Customer
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Customer Name is required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only letters allowed")]
        public string CustomerName { get; set; }

        public string ProjectName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers allowed")]
        public string FlatNo { get; set; }

        public string CarpetArea { get; set; }
        public string FloorWing { get; set; }


        // 2. Cost Sheet Details
        [Required(ErrorMessage = "Agreement Value is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double? AgreementValue { get; set; }

        [Required(ErrorMessage = "Agreement Value is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double? OtherCharges { get; set; }

        [Required(ErrorMessage = "Agreement Value is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double? TotalConsiderationValue { get; set; }

        public string CostSheetFilePath { get; set; }

        // 3. Broker Details
        public string BrokerName { get; set; }

        public string BrokerMobileNumber { get; set; }


        public string BrokerEmailId { get; set; }

        // 4. Brokerage Details
        public double? BrokeragePercentage { get; set; }

        // 5. Promotional Scheme
        public string ModularKitchenType { get; set; } // Below / Full / Above

        public double? GoldCoinAmount { get; set; }

        public bool Television { get; set; }

        public bool AirConditioner { get; set; }

        public bool Refrigerator { get; set; }

        public string OtherScheme { get; set; }

        public bool NotApplicable { get; set; }
    }
}