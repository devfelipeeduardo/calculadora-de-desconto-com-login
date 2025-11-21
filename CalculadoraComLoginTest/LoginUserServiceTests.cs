using Bogus;
using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Models.Models;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    public class LoginUserServiceTests
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

        [Fact(DisplayName = "Ao dar os argumentos corretos e, existir registro, o login deve ter sucesso!")]
        public void Should_Success_When_Register_Existis()
        {
            var fakeUsers = ReturnCorrectUsersFaker();

            var loggedUser = new User();
            var registeredUsers = new List<User>();

            var registerService = new RegisterUserService();
            var loginService = new LoginUserService();

            var loginResults = new List<Result<User>>();

            foreach (var fU in fakeUsers)
            {
                var registerResult = registerService.RegisterUser(fU.Login,
                                                                  fU.Password,
                                                                  fU.PhoneNumber,
                                                                  registeredUsers);
                registeredUsers.Add(registerResult.Data);

                var loginResult = loginService.LoginUser(fU.Login,
                                                         fU.Password,
                                                         loggedUser,
                                                         registeredUsers);
                loginResults.Add(loginResult);
            }

            foreach (var lR in loginResults)
            {
                Assert.True(lR.Success);
                Assert.Empty(lR.Errors);
                Assert.IsType<string>(lR.Data.Login);
                Assert.IsType<string>(lR.Data.Password);
                Assert.IsType<string>(lR.Data.PhoneNumber);
            }
        }

        [Fact(DisplayName = "Ao dar os argumentos corretos e, e não existir registro, o login deve falhar!")]
        public void Should_Fail_Register_Is_Null_Or_Empty()
        {
            var fakeUsers = ReturnCorrectUsersFaker();

            var loginService = new LoginUserService();

            var registeredUsers = new List<User>();
            var loggedUser = new User();

            var loginResults = new List<Result<User>>();

            foreach (var fU in fakeUsers)
            {
                var loginResult = loginService.LoginUser(fU.Login,
                                                         fU.Password,
                                                         loggedUser,
                                                         registeredUsers);
                loginResults.Add(loginResult);
            }

            foreach (var lR in loginResults)
            {
                Assert.False(lR.Success);
                Assert.NotEmpty(lR.Errors);
                Assert.IsType<string>(lR.Data.Login);
                Assert.IsType<string>(lR.Data.Password);
                Assert.IsType<string>(lR.Data.PhoneNumber);
            }
        }
    }
}
