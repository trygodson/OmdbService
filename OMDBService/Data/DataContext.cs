using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using OMDBService.Models;

namespace OMDBService.Data
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<SearchQueries> SearchQueries { get; set; }
    }
}

