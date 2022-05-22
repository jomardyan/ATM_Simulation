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
    [Migration("20220521220716_InitialCreate2")]
    partial class InitialCreate2
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

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
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
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
