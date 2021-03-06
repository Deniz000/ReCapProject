﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext:DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TbReCapProject;Trusted_Connection=true");
        }
        public DbSet<Car> TblCars { get; set; }
        public DbSet<Brand> TblBrands { get; set; }
        public DbSet<Color> TblColors { get; set; }
        public DbSet<User> TblUsers { get; set; }
        public DbSet<Customer> TblCustomers { get; set; }
        public DbSet<Rental> TblRentals { get; set; }
    }
}
