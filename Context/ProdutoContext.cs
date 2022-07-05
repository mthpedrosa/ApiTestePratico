using Microsoft.EntityFrameworkCore;

namespace ApiTestePratico.Context
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) { }

        public object Produto { get; internal set; }
    }
}
