﻿using Microsoft.EntityFrameworkCore;
using ServerSide.DAL.Models;

namespace ServerSide.DAL
{

    public class TaskListContext : DbContext
    {
        public DbSet<Todo> Todo { get; set; }
        public DbSet<Attachment> Attachment { get; set; }

        public TaskListContext()
        {

        }

        public TaskListContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=todo;user=root;password=1234;SslMode=none;ConnectionReset=true");
            }

            Database.AutoTransactionsEnabled = false;
            //optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Heading).IsRequired();
                entity.ToTable("Todo");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(d => d.Todo).WithMany(e => e.Attachments);
                entity.ToTable("Attachment");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
