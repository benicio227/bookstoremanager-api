using BookStoreManager.Communication.Responses;

namespace BookStoreManager.Application.UseCases.Books.GetById;
public interface IGetBookByIdUseCase
{
    Task<ResponseBookJson> Execute(long id);
}
