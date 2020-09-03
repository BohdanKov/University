﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.DAL
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Student> Students { get; set; }
    }
}
