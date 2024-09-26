namespace BookStoreManager.Application.UseCases.Books.Delete;
public interface IDeleteBookUseCase
{
    Task Execute(long id);
}
