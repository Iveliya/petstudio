using Microsoft.EntityFrameworkCore;
using pets.Data;
using pets.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pets.Controller
{
    public class EmployeeController
    {
        PetsDbContext context=new PetsDbContext();
        public async Task<List<Employee>> AllEmployee()
        {
            return await context.Employees.ToListAsync();
        }

    }
}
