using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllProductes();
        Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}