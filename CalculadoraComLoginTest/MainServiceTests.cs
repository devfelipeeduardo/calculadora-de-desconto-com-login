using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Models.Models;
using Fase5_CalculadoraDeDescontoComLogin.Services;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Unity;


namespace CalculadoraComLoginTest
{
    public class MainServiceTests
    {
        public UnityContainer RegisterDependencies(UnityContainer unityContainer)
        {
            unityContainer.RegisterType<IRegisterUserService, RegisterUserService>();
            unityContainer.RegisterType<ILoginUserService, LoginUserService>();
            unityContainer.RegisterType<IRegisterClientService, RegisterClientService>();
            unityContainer.RegisterType<IProductByClientService, ProductByClientService>();
            return unityContainer;
        }

        [Fact]
        public void RegisterUser_Should_Success_When_Given_Correct_Args()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            Result<User> registerResult = mainService.ReturnRegisterUserResult("felipe",
                                     "123456789",
                                     "11933464218");

            Assert.True(registerResult.Success);
        }

        [Fact]
        public void RegisterUser_Should_Fail_When_Given_Incorrect_Args()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            Result<User> registerResult = mainService.ReturnRegisterUserResult("felipe",
                                                              "123456789",
                                                              "1193346421328");

            Assert.False(registerResult.Success);
        }

        [Fact]
        public void LoginUser_Should_Success_When_Given_Correct_Args()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );


            Result<User> registerResult = mainService.ReturnRegisterUserResult("felipe",
                                                                               "123456789",
                                                                               "11933464218");

            Result<User> loginResult = mainService.ReturnLoginUserResult("felipe",
                                                                         "123456789");

            Assert.True(registerResult.Success);
            Assert.True(loginResult.Success);
        }

        [Fact]
        public void LoginUser_Should_Fail_When_Given_Incorrect_Args()
        {
            var registerService = new RegisterUserService();
            var loginService = new LoginUserService();
            var userLogged = new User();

            var registeredUsers = new List<User>();

            Result<User> registerResult = registerService.RegisterUser("felipe",
                                                                       "12345678910",
                                                                       "11933464218",
                                                                       registeredUsers);

            Result<User> loginResult = loginService.LoginUser("felipe",
                                                              "123456789",
                                                              userLogged,
                                                              registeredUsers);

            Assert.True(registerResult.Success);
            Assert.False(loginResult.Success);
        }

        [Fact]
        public void LogoutUser_Should_Success_When_Has_User_Logged()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            Result<User> registerResult = mainService.ReturnRegisterUserResult("felipe",
                                                                               "123456789",
                                                                               "11933464218");

            Result<User> loginResult = mainService.ReturnLoginUserResult("felipe",
                                                                         "123456789");

            Assert.True(mainService.IsUserLogged());
        }

        [Fact]
        public void LogoutUser_Should_Fail_When_Has_Not_User_Logged()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            var userLogged = new User();
            var usersRegistered = new List<User>();

            Result<User> registerResult = mainService.ReturnRegisterUserResult("felipe",
                                                                               "123456789",
                                                                               "11933464218");

            Assert.False(mainService.IsUserLogged());
        }

        [Fact]
        public void RegisterClient_Should_Success_When_Given_Correct_Args()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            Result<Client> registerResult = mainService.ReturnRegisterClientResult("felipe",
                                                                                 "11933464218");

            Assert.True(registerResult.Success);
        }

        [Fact]
        public void RegisterClient_Should_Fail_When_Given_Incorrect_Args()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            Result<Client> registerResult = mainService.ReturnRegisterClientResult("felipe",
                                                                                   "11933464218876867");

            Assert.False(registerResult.Success);
        }

        [Fact]
        public void AddProduct_Should_Success_When_Given_Correct_Args()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            Result<Client> registerResult = mainService.ReturnRegisterClientResult("felipe",
                                                                     "11933464218");

            Result<Product> productResult = mainService.ReturnAddProductsByClientResult("felipe",
                                                                                        "caneta",
                                                                                        "bonita e esplendida",
                                                                                        "nilke",
                                                                                        "5.50");
            Assert.True(productResult.Success);
        }

        [Fact]
        public void AddProduct_Should_Fail_When_Given_Incorrect_Args()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            Result<Client> registerResult = mainService.ReturnRegisterClientResult("felipe",
                                                                                   "11933464218");

            Result<Product> productResult = mainService.ReturnAddProductsByClientResult("felipe",
                                                                                        "",
                                                                                        "bonita e esplendida",
                                                                                        "nilke",
                                                                                        "5.50");
            Assert.False(productResult.Success);
        }

        [Fact]
        public void DeleteProduct_Should_Success_When_Given_Correct_Args()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            Result<Client> registerResult = mainService.ReturnRegisterClientResult("felipe",
                                                                                   "11933464218");

            Result<Product> addProductResult = mainService.ReturnAddProductsByClientResult("felipe",
                                                                                           "caneta",
                                                                                           "bonita e esplendida",
                                                                                           "nilke",
                                                                                           "5.50");

            Result<Product> deleteProductResult = mainService.ReturnDeleteProductByClientResult("felipe",
                                                                                                "caneta");
            Assert.True(registerResult.Success);
            Assert.True(addProductResult.Success);
            Assert.True(deleteProductResult.Success);
        }

        [Fact]
        public void DeleteProduct_Should_Fail_When_Given_Incorrect_Args()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            Result<Client> registerResult = mainService.ReturnRegisterClientResult("felipe",
                                                                                   "11933464218");

            Result<Product> addProductResult = mainService.ReturnAddProductsByClientResult("felipe",
                                                                                           "caneta",
                                                                                           "bonita e esplendida",
                                                                                           "nilke",
                                                                                           "5.50");

            Result<Product> deleteProductResult = mainService.ReturnDeleteProductByClientResult("gabriel",
                                                                                                "caneta");
            Assert.True(registerResult.Success);
            Assert.True(addProductResult.Success);
            Assert.False(deleteProductResult.Success);
        }

        [Fact]
        public void ReturnCalculatedTotalValueofProducts_Should_Success_When_Given_Correct_Args_AND_HAS_Products()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            double precoCaneta = 5.50;
            double precoBola = 100;

            mainService.ReturnRegisterClientResult("felipe",
                                                   "11933464218");

            mainService.ReturnAddProductsByClientResult("felipe",
                                                        "caneta",
                                                        "bonita e esplendida",
                                                        "nilke",
                                                        precoCaneta.ToString());

            mainService.ReturnAddProductsByClientResult("felipe",
                                                        "bola",
                                                        "redonda e nao quadrada",
                                                        "adidas",
                                                        precoBola.ToString());

            DiscountResult discountResult = mainService.ReturnCalculatedTotalValueofProductsByClientResult("felipe");

            Assert.True(discountResult.TotalValueOfProducts == (precoCaneta + precoBola));
            Assert.True(discountResult.DiscountPercent == 10.0);
            Assert.True(discountResult.TotalValueofProductsWithDiscount == 94.95);
        }

        [Fact]
        public void ReturnCalculatedTotalValueofProducts_Should_Fail_When_Given_Incorrect_Args_AND_HAS_NOT_Products()
        {
            UnityContainer container = RegisterDependencies(new UnityContainer());
            MainService mainService = new MainService(
                    container.Resolve<IRegisterUserService>(),
                    container.Resolve<ILoginUserService>(),
                    container.Resolve<IRegisterClientService>(),
                    container.Resolve<IProductByClientService>()
                    );

            mainService.ReturnRegisterClientResult("felipe",
                                                   "11933464218");

            DiscountResult discountResult = mainService.ReturnCalculatedTotalValueofProductsByClientResult("felipe");

            Assert.True(discountResult.TotalValueOfProducts == 0);
            Assert.True(discountResult.DiscountPercent == 0);
            Assert.True(discountResult.TotalValueofProductsWithDiscount == 0);
        }

    }
}
