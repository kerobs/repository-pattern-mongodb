

using System.Collections.Generic;
using System.Linq;
using Web.Core.Domain;
using Web.Core.Interfaces;

namespace Web.Persistence.Repositories
{

    public class BreathRepository : MongoRepository<Breath>, IBreathRepository
    {

        public BreathRepository(string collectionName) : base(collectionName)
        {
            collectionName = "Breath";
        }
    }
}