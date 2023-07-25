using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank;

[Table("User")]
public partial class User
{
    [Key]
    public long Id { get; set; }

    [Column(TypeName = "TEXT (50)")]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "TEXT (100)")]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "TEXT (25)")]
    public string? AcctOpenDate { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ICollection<Checking> Checkings { get; set; } = new List<Checking>();

    [InverseProperty("IdNavigation")]
    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    [InverseProperty("IdNavigation")]
    public virtual ICollection<Saving> Savings { get; set; } = new List<Saving>();
}
