using AutoMapper;
using BookStoreManager.Communication.Requests;
using BookStoreManager.Communication.Responses;
using BookStoreManager.Domain.Entities;
using BookStoreManager.Domain.Repositories;
using BookStoreManager.Domain.Repositories.Books;
using BookStoreManager.Exception.ExceptionsBase;


namespace BookStoreManager.Application.UseCases.Books.Register;
public class RegisterBookUseCase : IRegisterBookUseCase
{
    private readonly IBooksWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterBookUseCase(
        IBooksWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredBookJson> Execute(RequestBookJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Book>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredBookJson>(entity);
    }

    private static void Validate(RequestBookJson request)
    {
        var validator = new BookValidator();

        var resulte = validator.Validate(request);

        if (resulte.IsValid == false)
        {
            var errorMessages = resulte.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
