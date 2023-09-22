using System;
using System.Collections.Generic;

namespace BankApplication.Models;

public partial class CustomerMaster
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
