using BookStoreManager.Application.UseCases.Books.Delete;
using BookStoreManager.Application.UseCases.Books.GetAll;
using BookStoreManager.Application.UseCases.Books.GetById;
using BookStoreManager.Application.UseCases.Books.Register;
using BookStoreManager.Application.UseCases.Books.Update;
using BookStoreManager.Communication.Requests;
using BookStoreManager.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreManager.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] RequestBookJson request,
        [FromServices] IRegisterBookUseCase useCase)
    {

        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseBooksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<IActionResult> GetAllBooks([FromServices] IGetAllBookUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Books.Count != 0)
            return Ok(response);
        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

    public async Task<IActionResult> GetById(
        [FromServices] IGetBookByIdUseCase useCase,
        [FromRoute]  long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(
        [FromServices] IDeleteBookUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Update(
    [FromServices] IUpdateBookUseCase useCase,
    [FromRoute] long id,
    [FromBody] RequestBookJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}
