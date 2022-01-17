using System;
using System.Collections.Generic;

#nullable disable

namespace ItServiceApp.Models
{
    public partial class GenisTablo
    {
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CusName { get; set; }
        public string Shipper { get; set; }
        public string City { get; set; }
        public string MusteriUlke { get; set; }
        public string SupplierName { get; set; }
        public string SatıcıUlke { get; set; }
        public string SalesMan { get; set; }
    }
}
