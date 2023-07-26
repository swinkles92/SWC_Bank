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
    {
        if(!optionsBuilder.IsConfigured)
        {
            string dir = Environment.CurrentDirectory;
            string path = string.Empty;

            if(dir.EndsWith("net7.0"))
            {
                // Running in the
                // <project>\bin\<Debug/Release>\net7.0 directory.
                path = Path.Combine("..", "..", "..", "..", "swcbank.db");
            }
            else
            {
                // Running in the <project> directory.
                path = Path.Combine("..", "swcbank.db");
            }
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
