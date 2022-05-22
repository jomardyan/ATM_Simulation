using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATM_Simulation;

public class ATMContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Log> Log { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
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
    [Key]
    public int ClientID { get; set; }

    public int Ballance { get; set; }
    public string ClientName { get; set; }

    [MaxLength(6), MinLength(4)]
    public int PIN { get; set; }

    public List<Transaction> Transactions { get; } = new();
    public List<Log> Logs { get; } = new();
}

public class Transaction
{
    [Key]
    public int TransactionID { get; set; }

    public int Amount { get; set; }
    public DateTime TransactionDate { get; set; }

    public int ClientID { get; set; }
    public Client Client { get; set; }
}

public class Log
{
    [Key]
    public int LogID { get; set; }

    public string LogMessage { get; set; }
    public int ClientID { get; set; }
    public Client Client { get; set; }
}

public class CreditCard
{
    [Key]
    public int CardID { get; set; }

    [MaxLength(16), MinLength(16)]
    public string CardNumber { get; set; }

    public int CreditID { get; set; }
    public Client Client { get; set; }
}