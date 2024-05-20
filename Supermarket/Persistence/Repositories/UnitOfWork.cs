using Supermarket.Domain.Repositories;
using Supermarket.Persistence.Contexts;

namespace Supermarket.Persistence.Repositories
{
    /// <summary>
    /// Essa implementação garante que as alterações só serão salvas no banco de dados
    /// após todas as modificações forem feitas.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) 
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
