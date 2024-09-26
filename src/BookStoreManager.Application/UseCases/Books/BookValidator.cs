using BookStoreManager.Communication.Enums;
using BookStoreManager.Communication.Requests;
using BookStoreManager.Exception;
using FluentValidation;

namespace BookStoreManager.Application.UseCases.Books;
public class BookValidator : AbstractValidator<RequestBookJson>
{
    public BookValidator()
    {
        RuleFor(book => book.Title).NotEmpty().WithMessage(ResourceErrorMessages.THE_TITLE_IS_REQUIRED);
        RuleFor(book => book.Author).NotEmpty().WithMessage(ResourceErrorMessages.THE_AUTHOR_IS_REQUIRED);
        RuleFor(book => book.Price).GreaterThan(0).WithMessage(ResourceErrorMessages.THE_PRICE_MUST_BE_GREATER_THEN_ZERO);
        RuleFor(book => book.Stock).GreaterThanOrEqualTo(0).WithMessage(ResourceErrorMessages.THE_STOCK_CANNOT_BE_NEGATIVE);
        RuleFor(book => book.GenderType).Must(gender => Enum.TryParse(typeof(GenderType), gender, true, out _))
            .WithMessage(ResourceErrorMessages.A_VALID_GENDER_MUST_BE_SELECTED);
    }
}
