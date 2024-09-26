using BookStoreManager.Communication.Requests;
using BookStoreManager.Communication.Responses;

namespace BookStoreManager.Application.UseCases.Books.Register;
public interface IRegisterBookUseCase
{
    Task<ResponseRegisteredBookJson> Execute(RequestBookJson request);
}
