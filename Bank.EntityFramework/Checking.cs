using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank;

public partial class Checking
{
    [Key]
    public long AcctNo { get; set; }

    public long? Total { get; set; }

    public long? Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Checkings")]
    public virtual User? IdNavigation { get; set; }
}
