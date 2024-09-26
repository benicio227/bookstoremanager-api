using BookStoreManager.Domain.Entities;

namespace BookStoreManager.Domain.Repositories.Books;
public interface IBooksReadOnlyRepository
{
    Task<List<Book>> GetAll();
    Task<Book?> GetById(long id);
}
