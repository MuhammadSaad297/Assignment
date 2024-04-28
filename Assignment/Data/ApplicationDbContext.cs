using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;

namespace Assignment.Data
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            }

            public DbSet<Student> student { get; set; }
        }
    }

