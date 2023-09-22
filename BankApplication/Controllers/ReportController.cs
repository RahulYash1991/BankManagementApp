using BankApplication.IRepository;
using BankApplication.Models;
using BankApplication.RequestModel;
using BankApplication.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _repository;

        public ReportController(IReportRepository repository)
        {
            _repository = repository;
        }


        // Customer details report.
        [HttpGet("GetCustomersReport")]
        public IActionResult Get()
        {
            var response = _repository.GetCustomersReport();
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NoContent();
            }

        }

        // All the branches with Head office report.
        [HttpGet("GetBankBranchesReport")]
        public IActionResult GetBankBranchesReport()
        {
            var response = _repository.GetBankBranchesReport();
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NoContent();
            }

        }

        // Customer and related branches who did the transactions with the amount report.
        [HttpGet("GetCustomeBranchesTransactionsReport")]
        public IActionResult GetCustomeBranchesTransactionsReport()
        {
            var response = _repository.GetCustomeBranchesTransactionsReport();
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NoContent();
            }
        }


        //	Report of a customer based on the customer/Name/Month/Date-wise report about the transaction based on the branch.

        [HttpPost("GetCustomerTransactionReport")]
        public IActionResult GetCustomerTransactionReport([FromBody]GetCustomerTransactionsRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var response = _repository.GetCustomerTransactionReport(request);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
