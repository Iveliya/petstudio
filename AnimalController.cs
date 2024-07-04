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
    public class AnimalController
    {
        PetsDbContext context=new PetsDbContext();

        public async Task<string> CreateAnimal(string name,string species,int clientId)
        {
            Animal a=new Animal();
            a.Name = name;
            a.Species = species;
            a.ClientId = clientId;
            context.Animals.Add(a);
            await context.SaveChangesAsync();
            return "Completed!";
        }
        public async Task<List<Animal>> AllAnimals()
        {
            return await context.Animals.ToListAsync();
        }
    }
}
