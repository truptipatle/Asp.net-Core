using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asp.Net_Core_App.Model;

namespace Asp.Net_Core_App.Data
{
    public class AspNet_Core_AppContext : DbContext
    {
        public AspNet_Core_AppContext (DbContextOptions<AspNet_Core_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Asp.Net_Core_App.Model.StudentReg> StudentReg { get; set; } = default!;
    }
}
