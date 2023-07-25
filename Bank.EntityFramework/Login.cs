using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank;

[Table("Login")]
public partial class Login
{
    [Key]
    [Column(TypeName = "TEXT (50)")]
    public string Username { get; set; } = null!;

    [Column(TypeName = "TEXT (64)")]
    public string Password { get; set; } = null!;

    public long? Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Logins")]
    public virtual User? IdNavigation { get; set; }
}
