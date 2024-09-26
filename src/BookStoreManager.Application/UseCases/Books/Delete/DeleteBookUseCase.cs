using BookStoreManager.Domain.Repositories;
using BookStoreManager.Domain.Repositories.Books;
using BookStoreManager.Exception;
using BookStoreManager.Exception.ExceptionsBase;

namespace BookStoreManager.Application.UseCases.Books.Delete;
public class DeleteBookUseCase : IDeleteBookUseCase
{
    private readonly IBooksWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteBookUseCase(
        IBooksWriteOnlyRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if(result is false)
        {
            throw new NotFoundException(ResourceErrorMessages.BOOK_NOT_FOUND);
        }

        await _unitOfWork.Commit(); 
    }
}
