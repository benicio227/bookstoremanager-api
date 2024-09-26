using AutoMapper;
using BookStoreManager.Communication.Requests;
using BookStoreManager.Domain.Repositories;
using BookStoreManager.Domain.Repositories.Books;
using BookStoreManager.Exception;
using BookStoreManager.Exception.ExceptionsBase;

namespace BookStoreManager.Application.UseCases.Books.Update;
public class UpdateBookUseCase : IUpdateBookUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookUpdateOnlyRepository _repository;
    public UpdateBookUseCase(IMapper mapper, IUnitOfWork unitOfWork, IBookUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long id, RequestBookJson request)
    {

        Validate(request);

        var book = await _repository.GetById(id);

        if(book is null)
        {
            throw new NotFoundException(ResourceErrorMessages.BOOK_NOT_FOUND);
        }

        _mapper.Map(request, book);

        _repository.Update(book);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestBookJson request)
    {
        var validator = new BookValidator();

        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    } 
}
