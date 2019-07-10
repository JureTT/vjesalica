using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjesalica
{
    class RijeciDbContext:DbContext
    {
        public DbSet<Pojam> Pojmovi { get; set; }
    }
}
