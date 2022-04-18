using MyWebApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.Services
{
    public interface IProductRepository
    {
        public List<ProductModel> searchProduct(string txtSearch, double? from, double? to, int? sortBy, int page = 1);
        public List<ProductModel> getAllProduct();
    }
}
