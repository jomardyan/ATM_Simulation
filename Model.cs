
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ATM_Simulation;

public class ATMContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public string DbPath { get; }

    public ATMContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "ATM.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Client
{
    public int ClientID { get; set; }
    public int Ballance { get; set; }

    public List<Transaction> Transactions { get; } = new();
}

public class Transaction
{
    public int TransactionID { get; set; }
    public int Amount { get; set; }
    public DateTime TransactionDate { get; set; }

    public int ClientID { get; set; }
    public Client Client { get; set; }
}
