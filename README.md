
# Registro de Clientes

Um software de registro de clientes, produtos e cálculo de desconto.


## Stack utilizada

**Front-end:** Console do C#

**Back-end:** C#, Unity(DI), xUnit(Tests), Bogus(Faker Data for Tests)

## Arquitetura

📦CalculadoraDeDescontoComLogin
 ┣ 📂Models
 ┃ ┣ 📂Entities
 ┃ ┃ ┣ 📜DiscountResult.cs
 ┃ ┃ ┗ 📜Result.cs
 ┃ ┗ 📂Models
 ┃ ┃ ┣ 📜Client.cs
 ┃ ┃ ┣ 📜Product.cs
 ┃ ┃ ┗ 📜User.cs
 ┣ 📂Services
 ┃ ┣ 📂Interfaces
 ┃ ┃ ┣ 📜ILoginUserService.cs
 ┃ ┃ ┣ 📜IMainService.cs
 ┃ ┃ ┣ 📜IProductByClientService.cs
 ┃ ┃ ┣ 📜IRegisterClientService.cs
 ┃ ┃ ┗ 📜IRegisterUserService.cs
 ┃ ┣ 📜LoginUserService.cs
 ┃ ┣ 📜MainService.cs
 ┃ ┣ 📜ProductByClientService.cs
 ┃ ┣ 📜RegisterClientService.cs
 ┃ ┗ 📜RegisterUserService.cs
 ┣ 📜Fase5_CalculadoraDeDescontoComLogin.sln
 ┗ 📜Program.cs
📦Testes
 ┣ 📜LoginUserServiceTests.cs
 ┣ 📜MainServiceTests.cs
 ┣ 📜ProductByClientServiceTests.cs
 ┣ 📜RegisterClientServiceTests.cs
 ┗ 📜RegisterUserServiceTests.cs

## Instalação

Instale os pacotes: Unity no projeto principal
Instale os pacotes: xUnit e Bogus no projeto de testes
    
## Rodando os testes

Para rodar os testes, rode o seguinte comando

```powershell
  dotnet test
```


## Licença

[MIT](https://choosealicense.com/licenses/mit/)


## Autores

- [@devfelipeeduardo](https://github.com/devfelipeeduardo)
