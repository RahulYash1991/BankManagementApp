namespace BankApplication.ResponseModel
{
    public class GetCustomerTransactions
    {
        public string? CustomerName { get; set; }

        public string? BranchName { get; set; }

        public int TransactionMonth { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

    }
}
