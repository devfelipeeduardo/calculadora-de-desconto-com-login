using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Services;
using Bogus;
using Fase5_CalculadoraDeDescontoComLogin.Models.Models;

namespace CalculadoraComLoginTest
{
    public class RegisterUserServiceTests
    {
        public List<User> ReturnCorrectUsersFaker()
        {

            var fakeClient = new Faker<User>("pt_BR")
                .RuleFor(u => u.Login, f => f.Person.UserName.ToLower())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Role, f => "user");

            var fakeClientsList = fakeClient.Generate(10);

            return new List<User>();
        }

        [Fact(DisplayName = "Dado um usuário com nome e números corretos, e não existindo esse usuário registrado, retornará sucesso")]
        public void Should_Success_Given_Correct_Args()
        {
            List<User> fakeUsers = ReturnCorrectUsersFaker();

            var service = new RegisterUserService();
            var results = new List<Result<User>>();

            foreach (var fU in fakeUsers)
            {
                var result = service.RegisterUser(fU.Login, fU.PhoneNumber, fU.Password,
                                            new List<User>
                                            {
                                                new User{ Login = "Jonathan",
                                                          PhoneNumber = "11933464218",
                                                          Password = "123456789"}
                                            });

                results.Add(result);
            }

            foreach (var r in results)
            {
                Assert.True(r.Success);
                Assert.Empty(r.Errors);
                Assert.IsType<string>(r.Data.Login);
                Assert.IsType<string>(r.Data.Password);
                Assert.IsType<string>(r.Data.PhoneNumber);
            }
        }

        [Fact(DisplayName = "Dado um usuário com nome, senha e número correto, e existindo esse usuário registrado,  deve falhar")]
        public void Should_Fail_If_User_Already_Existis()
        {
            List<User> fakeUsers = ReturnCorrectUsersFaker();

            var service = new RegisterUserService();
            var results = new List<Result<User>>
            {
                //Adicionei manualmente um User já registrado.
            };

            foreach (var fU in fakeUsers)
            {
                var result = service.RegisterUser("jonathan",
                                                  "123456789",
                                                  "11933464218",
                                                  new List<User>
                                                  {
                                                      new User
                                                      {
                                                          Login = "jonathan",
                                                          Password = "123456789",
                                                          PhoneNumber = "11933464218"
                                                      }
                                                  });

                results.Add(result);
            }

            foreach (var r in results)
            {
                Assert.False(r.Success);
                Assert.NotEmpty(r.Errors);
            }
        }

        [Fact(DisplayName = "Dado um usuário com nome, senha e números vazios,  deve falhar")]
        public void Should_Fail_Given_Empty_Args()
        {
            var service = new RegisterUserService();

            string clientName = "";
            string password = "";
            string phoneNumber = "";
            List<User> clientsRegistered = new List<User> { };


            var result = service.RegisterUser(clientName, password, phoneNumber, clientsRegistered);

            Assert.False(result.Success);
            Assert.NotEmpty(result.Errors);
        }
    }
}