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
    public class ClientController
    {
        PetsDbContext context = new PetsDbContext();

        public async Task<Client> GetClient(int id)
        {
            var client = await context.Clients.FindAsync(id);
            return client;
        }

        public async Task<string> CreateClient(string FName,string LName,string email,string phone)
        {
            Client c=new Client(); 
            c.FirstName = FName;
            c.LastName = LName;
            c.Email = email;
            c.PhoneNumber = phone;
            context.Clients.Add(c);
            await context.SaveChangesAsync();
            return "You create new Client";
        }

        public async Task<string> UpdateClient(int id, string fName, string lName, string email, string phone)
        {
            var c = await context.Clients.FindAsync(id);
            if (c != null)
            {
                c.FirstName = fName;
                c.LastName = lName;
                c.Email = email;
                c.PhoneNumber = phone;
                await context.SaveChangesAsync();
                return "Completed";
            }
            else
            {
                return "Non-existent Client!";
            }
        }

        public async Task<string> RemoveClient(int id)
        {
            var client = await context.Clients.FindAsync(id);
            if (client == null)
            {
                return "Non-existent Client!";
            }

            context.Clients.Remove(client);
            await context.SaveChangesAsync();

            return "Completed";
        }

        public async Task<List<Client>> AllClient()
        {
            return await context.Clients.ToListAsync();
        }
    }
}
