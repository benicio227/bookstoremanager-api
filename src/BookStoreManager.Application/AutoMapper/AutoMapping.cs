using AutoMapper;
using BookStoreManager.Communication.Requests;
using BookStoreManager.Communication.Responses;
using BookStoreManager.Domain.Entities;

namespace BookStoreManager.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();

    }

    private void RequestToEntity()
    {
        CreateMap<RequestBookJson, Book>();
    }

    private void EntityToResponse()
    {
        CreateMap<Book, ResponseRegisteredBookJson>();
        CreateMap<Book, ResponseShortBookJson>();
        CreateMap<Book, ResponseBookJson>();

    }
}
