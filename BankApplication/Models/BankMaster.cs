using System;
using System.Collections.Generic;

namespace BankApplication.Models;

public partial class BankMaster
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<BranchMaster> BranchMasters { get; set; } = new List<BranchMaster>();
}
