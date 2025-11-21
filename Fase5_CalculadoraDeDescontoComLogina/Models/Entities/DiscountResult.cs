namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities
{
    public class DiscountResult
    {
        public double TotalValueOfProducts { get; set; }
        public double DiscountPercent { get; set; }
        public double TotalValueofProductsWithDiscount { get; set; }

        public DiscountResult(double totalValueOfProducts, double discountPercent, double totalValueofProductsWithDiscount)
        {
            TotalValueOfProducts = totalValueOfProducts;
            DiscountPercent = discountPercent;
            TotalValueofProductsWithDiscount = totalValueofProductsWithDiscount;
        }
    }
}
