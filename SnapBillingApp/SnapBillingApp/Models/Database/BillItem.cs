
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.Net.Attributes;

namespace SnapBillingApp.Models.Database
{
    public class BillItem
    {
        [ForeignKey(nameof(BillNumber))]
        public int BillNumber { get; set; }
        [PrimaryKey]
        public int BillItemId { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public double SellingPrice { get; set; }
        public double Amount { get; set; }
    }
}
