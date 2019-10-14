using System;
using System.Collections.Generic;
using System.Linq;

namespace ChefsAndDishes.Models
{
    public interface IChefRepository
    {
        Chef GetChef(int Id);
        IEnumerable<Chef> GetAllChef();
        Chef Add(Chef chef);
        Chef Update(Chef chefChanges);
        Chef Delete(int id);
    }
}