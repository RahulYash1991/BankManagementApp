using Newtonsoft.Json;
using System.Globalization;

namespace BankApplication.RequestModel
{
    public class GetCustomerTransactionsRequest
    {
        public string? CustomerName { get; set; }

        public int Month { get; set; }

        public DateTime? Date { get; set; }
        
    }
}
