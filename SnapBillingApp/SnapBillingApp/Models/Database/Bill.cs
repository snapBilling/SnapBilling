using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace SnapBillingApp.Models.Database
{
    public class Bill
    {
        [PrimaryKey]
        public int BillNumber { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}