using Supermarket.Persistence.Contexts;
using System.Runtime.Intrinsics.X86;

namespace Supermarket.Domain.Repositories
{
    /// <summary>
    /// Padrão Unidade de Trabalho:
    /// Uma classe recebe uma instância do AppDbContext como dependência e expõe os métodos
    /// para iniciar, concluir ou abortar transações.Isso garante que as alterações são
    /// salvas no BD somente quando tudo termina.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Método CompleteAsync conclui de forma assíncrona as operações de gerenciamento de dados
        /// </summary>
        /// <returns></returns>
        Task CompleteAsync();

    }
}
