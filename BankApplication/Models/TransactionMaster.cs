using System;
using System.Collections.Generic;

namespace BankApplication.Models;

public partial class TransactionMaster
{
    public long Id { get; set; }

    public long CustomerId { get; set; }

    public long BranchId { get; set; }

    public long BankId { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreatedDate { get; set; }
}
