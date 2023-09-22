using BankApplication.RequestModel;
using BankApplication.ResponseModel;

namespace BankApplication.IRepository
{
    public interface IReportRepository
    {
        List<GetCustomers> GetCustomersReport();

        List<GetBankBranches> GetBankBranchesReport();

        List<GetCustomeBranchesTransactions> GetCustomeBranchesTransactionsReport();

        List<GetCustomerTransactions> GetCustomerTransactionReport(GetCustomerTransactionsRequest request);
    }
}
