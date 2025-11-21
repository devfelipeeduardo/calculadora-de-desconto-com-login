using Bogus;
using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Models.Models;
using Fase5_CalculadoraDeDescontoComLogin.Services;

namespace CalculadoraComLoginTest
{
    public class ProductByClientServiceTests
    {

        public List<Product> ReturnCorrectProductsFaker()
        {
            var fakeProduct = new Faker<Product>("pt_BR")
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Lorem.Words().ToString())
                .RuleFor(p => p.Brand, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => double.Parse(f.Commerce.Price(1, 100, 2)));

            var fakeClientsList = fakeProduct.Generate(5);

            return fakeClientsList;
        }

        public List<Product> ReturnIncorrectProductsFaker()
        {
            var fakeProduct = new Faker<Product>("pt_BR")
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence(50))
                .RuleFor(p => p.Brand, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => double.Parse(f.Commerce.Price(1, 100, 2)));

            var fakeClientsList = fakeProduct.Generate(5);

            return fakeClientsList;
        }

        [Fact]
        public void Should_Success_Given_Correct_Args()
        {
            var service = new ProductByClientService();

            var clientsRegistered = new List<Client>();
            var productsRegistered = new List<Product>();

            var fakesProduct = ReturnCorrectProductsFaker();

            var results = new List<Result<Product>>();

            foreach (var fP in fakesProduct) 
            {
                var result = service.AddProducts(fP.Name,
                                                 fP.Description,
                                                 fP.Brand,
                                                 fP.Price.ToString(),
                                                 clientsRegistered,
                                                 productsRegistered);

                results.Add(result);
            }

            foreach (var r in results)
            {
                Assert.True(r.Success);
                Assert.Empty(r.Errors);
                Assert.IsType<string>(r.Data.Name);
                Assert.IsType<string>(r.Data.Description);
                Assert.IsType<string>(r.Data.Brand);
                Assert.IsType<double>(r.Data.Price);
            }
        }

        [Fact]
        public void Should_Fail_Given_Incorrect_Args()
        {
            var service = new ProductByClientService();

            var clientsRegistered = new List<Client>();
            var productsRegistered = new List<Product>();

            var fakesProduct = ReturnIncorrectProductsFaker();

            var results = new List<Result<Product>>();

            foreach (var fP in fakesProduct)
            {
                var result = service.AddProducts(fP.Name,
                                                 fP.Description,
                                                 fP.Brand,
                                                 fP.Price.ToString(),
                                                 clientsRegistered,
                                                 productsRegistered);

                results.Add(result);
            }

            foreach (var r in results)
            {
                Assert.False(r.Success);
                Assert.NotEmpty(r.Errors);
            }
        }
    }
}
