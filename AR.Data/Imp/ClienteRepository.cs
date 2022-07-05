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

        // Adiciona os clientes
        public async Task Add(Cliente entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        // Busca todos os clientes
        public IQueryable<Cliente> GetAll()
        {
            return db.Cliente;
        }

        // Busca Cliente por ID
        public Cliente BuscaId (int Id)
        {
            var cliente_db = db.Cliente.Find(Id);    
            return cliente_db;
            
        }

        // Deleta Cliente por ID
        public bool Delete(int Id)
        {
            try
            {
                var cliente_db = db.Cliente.Find(Id);
                db.Remove(cliente_db);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Faz update no cliente
        public bool Update(Cliente cliente)
        {
            try
            {
                var cliente_db = db.Cliente.Find(cliente.Id);
                cliente_db.nome = cliente.nome;
                cliente_db.data_nascimento = cliente.data_nascimento;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
