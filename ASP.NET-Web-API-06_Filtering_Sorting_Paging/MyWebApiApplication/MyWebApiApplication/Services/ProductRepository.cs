using Microsoft.EntityFrameworkCore;
using MyWebApiApplication.Models;
using MyWebApiApplication.MyDBC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.Services
{
    public class ProductRepository : IProductRepository
    {
        private MyDBContext _myDBContext;
        private static int PAGE_SIZE { get; set; } = 5;

        public ProductRepository(MyDBContext myDB)
        {
            _myDBContext = myDB;
        }

        public List<ProductModel> getAllProduct()
        {
            var products = _myDBContext.products.Select(pro => new ProductModel
            {
                productID = pro.productId,
                productName = pro.productName,
                price = pro.price,
                categoryName = pro.category.categoryName
            });

            return products.ToList();
        }

        public List<ProductModel> searchProduct(string txtSearch, double? from, double? to, int? sortby, int page)
        {
            var products = _myDBContext.products.Include(pro => pro.category).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(txtSearch))
            {
                products = products.Where(p => p.productName.Contains(txtSearch));
            }

            if (from.HasValue)
            {
                products = products.Where(pro => pro.price >= from);
            }
            if (to.HasValue)
            {
                products = products.Where(pro => pro.price <= to);
            }
            #endregion

            #region Sorting
            // default sorting by productName
            products = products.OrderBy(pro => pro.productName);

            if (sortby.HasValue)
            {
                switch (sortby)
                {
                    case 1:
                        products = products.OrderByDescending(pro => pro.productName);
                        break;
                    case 2:
                        products = products.OrderBy(pro => pro.price);
                        break;
                    case 3:
                        products = products.OrderByDescending(pro => pro.price);
                        break;
                    default:
                        products = products.OrderBy(pro => pro.productName);
                        break;
                }
            }
            #endregion

            #region Paging
            /* ----c1:
             * products = products.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
             * var result = products.Select(pro => new ProductModel
            {
                productID = pro.productId,
                productName = pro.productName,
                price = pro.price,
                categoryName = pro.category.categoryName
            });

            return result.ToList();
             */

            // -----c2:
            var result = PaginatedList<MyWebApiApplication.DataDB.Product>.crate(products, page, PAGE_SIZE);

            return result.Select(product => new ProductModel
            {
                productID = product.productId,
                productName = product.productName,
                price = product.price,
                categoryName = product.category?.categoryName
            }).ToList();
            #endregion
        }
    }
}
