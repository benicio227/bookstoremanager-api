﻿
using BookStoreManager.Application.AutoMapper;
using BookStoreManager.Application.UseCases.Books.Delete;
using BookStoreManager.Application.UseCases.Books.GetAll;
using BookStoreManager.Application.UseCases.Books.GetById;
using BookStoreManager.Application.UseCases.Books.Register;
using BookStoreManager.Application.UseCases.Books.Update;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreManager.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    private static void AddUseCases(IServiceCollection services)
    {
       services.AddScoped<IRegisterBookUseCase, RegisterBookUseCase>();
       services.AddScoped<IGetAllBookUseCase, GetAllBookUseCase>();
       services.AddScoped<IGetBookByIdUseCase, GetBookByIdUseCase>();
       services.AddScoped<IDeleteBookUseCase, DeleteBookUseCase>();
       services.AddScoped<IUpdateBookUseCase, UpdateBookUseCase>();
    }
}
