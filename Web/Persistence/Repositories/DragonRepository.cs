using System;
using System.Linq;
using Web.Core.Domain;
using Web.Core.Interfaces;

namespace Web.Persistence.Repositories
{
    public class DragonRepository : MongoRepository<Dragon>, IDragonRepository
    {
        public DragonRepository(string collectionName) 
            : base(collectionName)
        {   
        }

        public Dragon Spawn()
        {
            Dragon dragon = new Dragon() { Name = "Test", Age = 10, Gold = 100 };

            // Save object.
            if (!this.Add(dragon))
            {
                dragon = null;
            }
            return dragon;
        }


    }
}