using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appWrk.API.Model
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions options) : base(options) { }

        public DbSet<CashInOut> CashInOut { get; set; }
    }
}
