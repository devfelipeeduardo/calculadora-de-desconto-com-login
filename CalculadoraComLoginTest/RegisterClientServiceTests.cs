using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Services;
using Bogus;
using Fase5_CalculadoraDeDescontoComLogin.Models.Models;

namespace CalculadoraComLoginTest
{
    public class RegisterClientServiceTests
    {
        public List<Client> ReturnCorrectClientsFaker()
        {

            var fakeClient = new Faker<Client>("pt_BR")
                .RuleFor(c => c.Name, f => f.Person.UserName.ToLower())
                .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber());

            var fakeClientsList = fakeClient.Generate(10);

            return new List<Client>();
        }

        [Fact(DisplayName = "Dado um cliente com nome e números corretos, e não existindo esse cliente registrado, retornará sucesso")]
        public void Should_Success_When_Given_Correct_Args()
        {
            List<Client> fakeClients = ReturnCorrectClientsFaker();

            var service = new RegisterClientService();
            var results = new List<Result<Client>>();

            foreach (var fC in fakeClients)
            {
                var result = service.RegisterClient(fC.Name, fC.PhoneNumber,
                                            new List<Client>
                                            {
                                                new Client{ Name = "Jonathan",
                                                            PhoneNumber = "11933464218" }
                                            });

                results.Add(result);
            }

            foreach (var r in results)
            {
                Assert.True(r.Success);
                Assert.Empty(r.Errors);
                Assert.IsType<string>(r.Data.Name);
                Assert.IsType<string>(r.Data.PhoneNumber);
                Assert.IsType<List<Product>>(r.Data.Products);
            }
        }

        [Fact(DisplayName = "Dado um cliente com nome e números corretos, e existindo esse cliente registrado, deve falhar")]
        public void Should_Fail_If_Client_Already_Existis()
        {

            List<Client> fakeClients = ReturnCorrectClientsFaker();

            var service = new RegisterClientService();
            var results = new List<Result<Client>>();

            foreach (var fC in fakeClients)
            {
                var result = service.RegisterClient("jonathan",
                                                    "11933464218",
                                                    new List<Client>
                                                    {
                                                        new Client
                                                        { Name = "jonathan",
                                                          PhoneNumber = "11933464218"
                                                        }
                                                    });

                results.Add(result);
            }

            //Adicionei manualmente um cliente já registrado.


            foreach (var r in results)
            {
                Assert.False(r.Success);
                Assert.NotEmpty(r.Errors);
            }
        }

        [Fact(DisplayName = "Dado um cliente com nome e números vazios, deve falhar")]
        public void Should_Fail_Given_Empty_Or_Null_Args()
        {
            var service = new RegisterClientService();

            string clientName = "";
            string phoneNumber = "";
            List<Client> clientsRegistered = new List<Client> { };

            var result = service.RegisterClient(clientName, phoneNumber, clientsRegistered);

            Assert.False(result.Success);
            Assert.NotEmpty(result.Errors);
        }
    }
}