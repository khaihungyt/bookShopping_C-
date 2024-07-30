using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
internal class PayMent1
{
    public class VNPayPayment
    {
        private string vnp_TmnCode = "8C0SUG2Q"; // Terminal ID do VNPay cung cấp
        private string vnp_HashSecret = "2J4Q4FV8R3Z95L0JPBJUZE4TKQD7TE6S"; // Secret Key do VNPay cung cấp
        private string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html"; // URL của VNPay
        private string returnUrl = "http://localhost:9000/vnpay_return"; // URL để VNPay gọi lại khi giao dịch hoàn tất

        public string CreatePaymentUrl(decimal amount, string orderInfo)
        {
            var vnpay = new Dictionary<string, string>();
            vnpay["vnp_Version"] = "2.1.0";
            vnpay["vnp_Command"] = "pay";
            vnpay["vnp_TmnCode"] = vnp_TmnCode;
            vnpay["vnp_Amount"] = ((int)(amount * 100)).ToString(); // VNPay yêu cầu số tiền là số nguyên (đơn vị: VND * 100)
            vnpay["vnp_CurrCode"] = "VND";
            vnpay["vnp_TxnRef"] = DateTime.Now.Ticks.ToString();
            vnpay["vnp_OrderInfo"] = orderInfo;
            vnpay["vnp_Locale"] = "vn";
            vnpay["vnp_ReturnUrl"] = returnUrl;
            vnpay["vnp_IpAddr"] = GetLocalIPAddress();
            vnpay["vnp_CreateDate"] = DateTime.Now.ToString("yyyyMMddHHmmss");

            string query = BuildQueryString(vnpay);
            string signData = vnp_HashSecret + query;
            string vnp_SecureHash = ComputeSha256Hash(signData);
            vnpay["vnp_SecureHash"] = vnp_SecureHash;

            string paymentUrl = vnp_Url + "?" + BuildQueryString(vnpay);

            return paymentUrl;
        }

        private string BuildQueryString(Dictionary<string, string> vnpay)
        {
            StringBuilder data = new StringBuilder();
            foreach (var kv in vnpay)
            {
                if (!string.IsNullOrEmpty(kv.Value))
                {
                    data.Append(HttpUtility.UrlEncode(kv.Key) + "=" + HttpUtility.UrlEncode(kv.Value) + "&");
                }
            }
            return data.ToString().TrimEnd('&');
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }

    // Phương thức để mở URL trong trình duyệt
    public void OpenPaymentUrl(string url)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            // Xử lý lỗi
            MessageBox.Show("Có lỗi xảy ra khi mở URL: " + ex.Message);
        }
    }

    // Phương thức để bắt đầu lắng nghe phản hồi từ VNPay
    public void StartHttpListener()
    {
        Task.Run(() =>
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:16262/vnpay_return.aspx/");
            listener.Start();
            while (true)
            {
                var context = listener.GetContext();
                var request = context.Request;
                var response = context.Response;

                // Xử lý dữ liệu phản hồi từ VNPay
                if (request.HttpMethod == "GET")
                {
                    string responseString = "<html><body>Payment successful. You can close this window.</body></html>";
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    var output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();

                    // Cập nhật giao diện người dùng của ứng dụng WPF
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show("Thanh toán thành công!");
                    });
                }
            }
        });
    }

    // Gọi phương thức để tạo URL thanh toán và mở trong trình duyệt
    public void MakePayment()
    {
        MessageBox.Show("Hello");
        var payment = new VNPayPayment();
        string paymentUrl = payment.CreatePaymentUrl(2500, "Thanh toan don hang:638571283705234589");

        OpenPaymentUrl(paymentUrl);
        StartHttpListener();
    }
}

