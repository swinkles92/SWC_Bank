using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bank;

public partial class SwcbankContext : DbContext
{
    public SwcbankContext()
    {
    }

    public SwcbankContext(DbContextOptions<SwcbankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Checking> Checkings { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Saving> Savings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        => optionsBuilder.UseSqlite("Filename=/Users/samuelwinkles" +
            "/Documents/CSharpPrograms/swcbank.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
