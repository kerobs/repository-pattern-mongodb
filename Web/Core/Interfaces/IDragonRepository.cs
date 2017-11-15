using Web.Core.Domain;

namespace Web.Core.Interfaces
{

    public interface IDragonRepository : IRepository<Dragon>
    {
        Dragon Spawn();
    }

}