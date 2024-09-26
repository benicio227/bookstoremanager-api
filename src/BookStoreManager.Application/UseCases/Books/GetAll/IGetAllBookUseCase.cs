using BookStoreManager.Communication.Responses;

namespace BookStoreManager.Application.UseCases.Books.GetAll;
public interface IGetAllBookUseCase
{
    Task<ResponseBooksJson> Execute();
}
