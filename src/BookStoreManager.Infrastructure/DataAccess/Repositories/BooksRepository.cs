using BookStoreManager.Domain.Entities;
using BookStoreManager.Domain.Repositories.Books;
using Microsoft.EntityFrameworkCore;

namespace BookStoreManager.Infrastructure.DataAccess.Repositories;
internal class BooksRepository : IBooksReadOnlyRepository, IBooksWriteOnlyRepository, IBookUpdateOnlyRepository
{
    private readonly BookStoreManagerDbContext _dbContext;
    public BooksRepository(BookStoreManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Book book)
    {
        await _dbContext.Books.AddAsync(book);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Books.FirstOrDefaultAsync(book => book.Id == id);
        if(result is null)
        {
            return false;
        }

        _dbContext.Books.Remove(result);

        return true;
    }

    public async Task<List<Book>> GetAll()
    {
        return await _dbContext.Books.AsNoTracking().ToListAsync();
    }

    async Task<Book?> IBooksReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(book => book.Id == id);
    }

    async Task<Book?> IBookUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Books.FirstOrDefaultAsync(book => book.Id == id);
    }

    public void Update(Book book)
    {
        _dbContext.Books.Update(book);
    }
}
