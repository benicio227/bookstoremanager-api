using BookStoreManager.Domain.Entities;

namespace BookStoreManager.Domain.Repositories.Books;
public interface IBooksWriteOnlyRepository
{
    Task Add(Book book);
    Task<bool> Delete(long id);
}
