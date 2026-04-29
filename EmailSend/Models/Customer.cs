using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSend.Models
{
    public class Customer
    {

        public int Id { get; set; }


        public string CustomerName { get; set; }

        public string ProjectName { get; set; }

        public string FlatNo { get; set; }

        public string FloorWing { get; set; }

        public double? CarpetArea { get; set; }

        public DateTime? Date { get; set; }

        // 2. Cost Sheet Details
        public double? AgreementValue { get; set; }

        public double? OtherCharges { get; set; }

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