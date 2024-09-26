using BookStoreManager.Application.UseCases.Books;
using BookStoreManager.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Test.Books.Register;
public class RegisterBookValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new BookValidator();
        var request = RequestRegisterBookJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Error_Title_Empty(string title)
    {
        var validator = new BookValidator();
        var request = RequestRegisterBookJsonBuilder.Build();
        request.Title = title;
        

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.THE_TITLE_IS_REQUIRED));
    }

    [Fact]
    public void Error_Author_Empty()
    {
        var validator = new BookValidator();
        var request = RequestRegisterBookJsonBuilder.Build();
        request.Author = string.Empty;

        var result = validator.Validate(request); 

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.THE_AUTHOR_IS_REQUIRED));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Error_Price_Invalid(decimal price)
    {
        var validator = new BookValidator();
        var request = RequestRegisterBookJsonBuilder.Build();
        request.Price = price;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.THE_PRICE_MUST_BE_GREATER_THEN_ZERO));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-3)]
    public void Error_Stock_Invalid(int stock)
    {
        var validator = new BookValidator();
        var request = RequestRegisterBookJsonBuilder.Build();
        request.Stock = stock;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.THE_STOCK_CANNOT_BE_NEGATIVE));
    }

    [Fact]
    public void Error_Gender_Type_Invalid()
    {
        var validator = new BookValidator();
        var request = RequestRegisterBookJsonBuilder.Build();
        request.GenderType = "Medo";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.A_VALID_GENDER_MUST_BE_SELECTED));
    }

}
