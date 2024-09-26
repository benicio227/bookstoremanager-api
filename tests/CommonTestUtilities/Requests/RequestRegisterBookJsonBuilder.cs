using Bogus;
using BookStoreManager.Communication.Enums;
using BookStoreManager.Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RequestRegisterBookJsonBuilder
{
    public static RequestBookJson Build()
    {
        var faker = new Faker();

        var request = new RequestBookJson
        {
            Title = faker.Commerce.ProductName(),
            Author = faker.Person.FullName,
            GenderType = faker.PickRandom<GenderType>().ToString(),
            Price = decimal.Parse(faker.Commerce.Price(10, 100)),
            Stock = faker.Random.Int(1, 100),
        };

        return request;

    }
}
