using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using static PayMent1;
namespace PRN212_Assignment
{
    /// <summary>
    /// Interaction logic for PayMent.xaml
    /// </summary>
    public partial class PayMent : Window
    {
        Double TotalCostFound;
        public PayMent(Double TotalCost)
        {
            InitializeComponent();
            TotalCostFound = TotalCost;
            TotalCostTextBox.Text= TotalCost.ToString();
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            //// Get Config Info
            //string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"];
            //string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"];
            //string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"];
            //string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"];

            //// Get payment input
            //OrderInfo order = new OrderInfo();
            //order.OrderId = DateTime.Now.Ticks; // Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
            //order.Amount = (int)TotalCostFound; // Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY 100,000 VND
            //order.Status = "0"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending" khởi tạo giao dịch chưa có IPN
            //order.CreatedDate = DateTime.Now;
            ////Save order to db

            //// Build URL for VNPAY
            //VnPayLibrary vnpay = new VnPayLibrary();
            //vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            //vnpay.AddRequestData("vnp_Command", "pay");
            //vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            //vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());

            //if (bankcode_Vnpayqr.IsChecked == true)
            //{
            //    vnpay.AddRequestData("vnp_BankCode", "VNPAYQR");
            //}
            //else if (bankcode_Vnbank.IsChecked == true)
            //{
            //    vnpay.AddRequestData("vnp_BankCode", "VNBANK");
            //}
            //else if (bankcode_Intcard.IsChecked == true)
            //{
            //    vnpay.AddRequestData("vnp_BankCode", "INTCARD");
            //}

            //vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            //vnpay.AddRequestData("vnp_CurrCode", "VND");
            //vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());

            //if (locale_Vn.IsChecked == true)
            //{
            //    vnpay.AddRequestData("vnp_Locale", "vn");
            //}
            //else if (locale_En.IsChecked == true)
            //{
            //    vnpay.AddRequestData("vnp_Locale", "en");
            //}

            //vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.OrderId);
            //vnpay.AddRequestData("vnp_OrderType", "other");
            //vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            //vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());

            //string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);

            //// Open the URL in the default web browser
            //System.Diagnostics.Process.Start(paymentUrl);

            PayMent1 pay = new PayMent1();
            pay.MakePayment();
        }
    }
}
