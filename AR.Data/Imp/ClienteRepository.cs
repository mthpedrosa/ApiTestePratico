using AR.Data.Interfaces;
using AR.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace AR.Data.Imp
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextoPrincipal db;

        public ClienteRepository(ContextoPrincipal db)
        {
            this.db = db;
        }

        public async Task Add(Cliente entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public IQueryable<Cliente> GetAll()
        {
            return db.Cliente;
        }
    }
}
