using AutoMapper;
using BookStoreManager.Communication.Responses;
using BookStoreManager.Domain.Repositories.Books;

namespace BookStoreManager.Application.UseCases.Books.GetAll;
public class GetAllBookUseCase : IGetAllBookUseCase
{
    private IBooksReadOnlyRepository _repository;
    private IMapper _mapper;
    public GetAllBookUseCase(IBooksReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseBooksJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseBooksJson
        {
            Books = _mapper.Map<List<ResponseShortBookJson>>(result)
        };
    }
}
