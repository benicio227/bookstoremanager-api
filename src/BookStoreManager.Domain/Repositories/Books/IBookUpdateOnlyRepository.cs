using BookStoreManager.Domain.Entities;

namespace BookStoreManager.Domain.Repositories.Books;
public interface IBookUpdateOnlyRepository
{
    Task<Book?> GetById(long id);
    void Update(Book book);
}
