using RaZorWebxxx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaZorWebxxx.Services
{
    public class ProductServices : List<ProductModel>
    {
        public ProductServices()
        {
            this.AddRange(new ProductModel[]{
                    new ProductModel() { Id=1,Name="Iphone X",Price=1000},
                     new ProductModel() { Id = 2, Name = "Sam Sung", Price = 800 },
                     new ProductModel() { Id = 3, Name = "Sony", Price = 900 },
                });

        }
    }
}
