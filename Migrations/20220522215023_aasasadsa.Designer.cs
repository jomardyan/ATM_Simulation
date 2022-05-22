﻿// <auto-generated />
using System;
using ATM_Simulation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ATM_Simulation.Migrations
{
    [DbContext(typeof(ATMContext))]
    [Migration("20220522215023_aasasadsa")]
    partial class aasasadsa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("ATM_Simulation.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ballance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientName")
                        .HasColumnType("TEXT");

                    b.Property<int>("PIN")
                        .HasMaxLength(6)
                        .HasColumnType("INTEGER");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ATM_Simulation.CreditCard", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardNumber")
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CardID");

                    b.HasIndex("ClientID");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("ATM_Simulation.Log", b =>
                {
                    b.Property<int>("LogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LogMessage")
                        .HasColumnType("TEXT");

                    b.HasKey("LogID");

                    b.HasIndex("ClientID");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("ATM_Simulation.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.HasKey("TransactionID");

                    b.HasIndex("ClientID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ATM_Simulation.CreditCard", b =>
                {
                    b.HasOne("ATM_Simulation.Client", "Client")
                        .WithMany("CreditCard")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ATM_Simulation.Log", b =>
                {
                    b.HasOne("ATM_Simulation.Client", "Client")
                        .WithMany("Logs")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ATM_Simulation.Transaction", b =>
                {
                    b.HasOne("ATM_Simulation.Client", "Client")
                        .WithMany("Transactions")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ATM_Simulation.Client", b =>
                {
                    b.Navigation("CreditCard");

                    b.Navigation("Logs");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
