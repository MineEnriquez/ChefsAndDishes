using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Models
{
    public class SQLChefRepository : IChefRepository
    {
        private readonly AppDbContext context;

        public SQLChefRepository(AppDbContext context)
        {
            this.context = context;
        }
     

        public Chef Add(Chef chef){
          context.Chefs.Add(chef);
          context.SaveChanges();
          return chef;
        }
        public Chef Delete(int id)
        {
            Chef chef = context.Chefs.Find(id);
            if(chef!= null)
            {
                context.Chefs.Remove(chef);
                context.SaveChanges();
            }
            return chef;
        }
        public IEnumerable<Chef> GetAllChef()
        {
              var chefs = context.Chefs.Include(chef =>chef.CreatedDishes);
            return chefs;
        }


        public Chef GetChef(int id)
        {
            return context.Chefs.Find(id);
        }
        
        public Chef Update(Chef chefChanges)
        {
            var chef = context.Chefs.Attach(chefChanges);
            chef.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return chefChanges;
        }
    }
}