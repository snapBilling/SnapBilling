using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SnapBillingApp.Models;
using SnapBillingApp.Models.Database;
using SQLite.Net.Interop;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SnapBillingApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // FOR SQL Testing
            SnapSqLite.GetSqlConnection().CreateTable<Bill>();
            SnapSqLite.GetSqlConnection().CreateTable<BillItem>();

            int billNumber = (from row in SnapSqLite.GetSqlConnection().Table<Bill>() group row by true into r select r.Max(z => z.BillNumber)).FirstOrDefault();
            var id1 = billNumber + 1;
            SnapSqLite.GetSqlConnection().Insert(new Bill()
            {
                BillNumber = id1,
                Amount = 10,
                Date = DateTime.Today,
            });
            int billItemNumber = (from row in SnapSqLite.GetSqlConnection().Table<BillItem>() group row by true into r select r.Max(z => z.BillItemId)).FirstOrDefault();
            var id2 = billItemNumber + 1;
            SnapSqLite.GetSqlConnection().Insert(
                new BillItem()
                {
                    BillItemId = id2,
                    BillNumber = id1,
                    Amount = 100,
                    ProductBarcode = "Init",
                    ProductDescription = "Init",
                    ProductName = "Init",
                    SellingPrice = 20,
                    Quantity = 1,

                });
            var bills = SnapSqLite.GetSqlConnection().Table<Bill>();
            var f = bills?.FirstOrDefault(x => x.BillNumber == id1);
            var billItems = SnapSqLite.GetSqlConnection().Table<BillItem>();
            var i = f.BillNumber;
            var y = billItems?.Where(x => x.BillNumber == i);
            var z1 = y?.ToList();
            Debug.WriteLine(bills);
        }
    }
}
