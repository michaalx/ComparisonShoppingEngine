﻿using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DataContext() : base()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Record> Records { get; set; }

    }
}
