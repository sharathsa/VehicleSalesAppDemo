using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle_Sales.Models
{
    public class VehicleModel
    {
        public int DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string Vehicle { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}