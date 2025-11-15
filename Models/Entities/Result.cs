namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities
{
    //Eu criei uma model chamada Result para lidar com os retornos. Eu já vi um pouco de Clean code, e sei que isso pode ser uma má prática
    //Mas eu não sabia como fazer isso de outra forma, se não criando mais um método, então deixei tudo aqui mesmo.
    internal class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public static Result<T> Ok(T data)
        {
            return new Result<T> { Success = true, Data = data };
        }

        public static Result<T> Fail(params string[] errors)
        {
            return new Result<T> { Success = false, Errors = errors.ToList() };
        }
    }
}
