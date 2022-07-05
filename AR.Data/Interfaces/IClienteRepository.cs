using AR.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace AR.Data.Interfaces
{
    public interface IClienteRepository
    {
        
        IQueryable<Cliente> GetAll();

        Task Add(Cliente entity);

        public bool Delete(int id);

        public Cliente BuscaId(int id);

        public bool  Update(Cliente entity);
    }
}