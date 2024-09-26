using AutoMapper;
using BookStoreManager.Communication.Responses;
using BookStoreManager.Domain.Repositories.Books;
using BookStoreManager.Exception;
using BookStoreManager.Exception.ExceptionsBase;

namespace BookStoreManager.Application.UseCases.Books.GetById;
public class GetBookByIdUseCase : IGetBookByIdUseCase
{
    private readonly IBooksReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetBookByIdUseCase(IBooksReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseBookJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.BOOK_NOT_FOUND);
        }

        return _mapper.Map<ResponseBookJson>(result);
    }
}
