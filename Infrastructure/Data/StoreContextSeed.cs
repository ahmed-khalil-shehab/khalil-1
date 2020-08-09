using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands= JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                    if (!context.ProductTypes.Any())
                {
                    var TypeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var Types= JsonSerializer.Deserialize<List<ProductType>>(TypeData);
                    foreach(var item in Types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                    if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var prod= JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach(var item in prod)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
                catch(Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                    logger.LogError(ex.Message);
                }
        }
    }
}