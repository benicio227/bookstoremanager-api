using BookStoreManager.Communication.Requests;

namespace BookStoreManager.Application.UseCases.Books.Update;
public interface IUpdateBookUseCase
{
    Task Execute(long id, RequestBookJson request);
}
