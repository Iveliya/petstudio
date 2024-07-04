using pets.Data.Entities;
using pets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pets.Controller
{
    public class ProcedureController
    {
        PetsDbContext context = new PetsDbContext();
 
        public async Task<List<Procedure>> AllProcedures()
        {
            return await context.Procedures.ToListAsync();
        }
    }
}
