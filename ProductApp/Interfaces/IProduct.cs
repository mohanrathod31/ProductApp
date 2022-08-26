using ProductApp.Data.Models;

namespace ProductApp.Interfaces
{
    public interface IProduct
    {
        void AddProduct(Product product);

        void AddColour(Colour colour);

        void AddSizeScale(SizeScale sizeScale);

        ProductViewModel GetProductById(Guid ProductId);
    }
}
