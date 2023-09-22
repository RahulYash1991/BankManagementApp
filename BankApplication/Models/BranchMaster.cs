using System;
using System.Collections.Generic;

namespace BankApplication.Models;

public partial class BranchMaster
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public long BankId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual BankMaster Bank { get; set; } = null!;
}
