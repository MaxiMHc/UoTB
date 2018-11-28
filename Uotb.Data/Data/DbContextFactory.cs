using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Uotb.Data.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private static string DataConnectionString => new DatabaseConfiguration().GetDataConnectionString();
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            optionsBuilder.UseSqlServer(DataConnectionString);
            return new DataContext(optionsBuilder.Options);
        }
    }
}
