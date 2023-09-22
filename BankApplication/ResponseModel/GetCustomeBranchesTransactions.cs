namespace BankApplication.ResponseModel
{
    public class GetCustomeBranchesTransactions
    {
        public string? CustomerName { get; set; }

        public string? CustomerAddress { get; set; }

        public string? BranchName { get; set; }

        public string?  BranchAddress { get; set; }

        public string? BankName { get; set; }

        public decimal Amount { get; set; }
    }
}
