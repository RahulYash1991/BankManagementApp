using BankApplication.IRepository;
using BankApplication.Models;
using BankApplication.RequestModel;
using BankApplication.ResponseModel;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly BankManagementContext _context;
        public ReportRepository(BankManagementContext context)
        {
            _context = context;
        }
        public List<GetCustomers> GetCustomersReport()
        {
            try
            {
                List<GetCustomers> getCustomersResponse = new();
                getCustomersResponse = _context.GetCustomers.FromSqlInterpolated($"[dbo].[p_GetCustomers]").ToList();
                return getCustomersResponse;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<GetBankBranches> GetBankBranchesReport()
        {
            try
            {

                List<GetBankBranches> getBankBranchesResponse = new();
                getBankBranchesResponse = _context.GetBankBranches.FromSqlInterpolated($"[dbo].[p_GetBankBranches]").ToList();
                return getBankBranchesResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public List<GetCustomeBranchesTransactions> GetCustomeBranchesTransactionsReport()
        {
            try
            {
                List<GetCustomeBranchesTransactions> getCustomeBranchesTransactionsResponse = new();
                getCustomeBranchesTransactionsResponse = _context.GetCustomeBranchesTransactions.FromSqlInterpolated($"[dbo].[p_GetCustomerBranchesTransactions]").ToList();
                return getCustomeBranchesTransactionsResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GetCustomerTransactions> GetCustomerTransactionReport(GetCustomerTransactionsRequest request)
        {
            try
            {
                List<GetCustomerTransactions> getCustomerTransactions = new();
                var p1 = new SqliteParameter("@CustomerName", "Customer1");
                getCustomerTransactions = _context.GetCustomerTransactions.FromSqlInterpolated($"[dbo].[p_GetCustomerTransactionReport] {request.CustomerName},{request.Month},{request.Date}").ToList();
                return getCustomerTransactions;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
