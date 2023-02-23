using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data
{
    internal class JujuTestContextFactory : IDesignTimeDbContextFactory<JujuTestContext>
    {
        public JujuTestContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<JujuTestContext>();
            OptionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=JujuTest");
            return new JujuTestContext(OptionBuilder.Options);
        }
    }
}
